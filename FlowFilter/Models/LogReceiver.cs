using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FlowFilter.Data;

namespace FlowFilter.Models
{
    public class LogReceiver
    {
        private readonly FlowFilterContext db;
        private readonly RedisManager _redisManager;
        private readonly List<BusinessLog> _logList;
        private readonly Timer _timer;
        public LogReceiver(FlowFilterContext context, RedisManager redisManager)
        {
            db = context;
            _redisManager = redisManager;
            _logList = new List<BusinessLog>(8192);
            _timer = new Timer(async (o) =>
            {
                int count = _logList.Count;
                await db.BusinessLogs.AddRangeAsync(_logList.GetRange(0,count));
                await db.SaveChangesAsync();
                _logList.RemoveRange(0, count);

            }, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            Task.Run(async ()=>
            {
                await _redisManager.Instance.GetSubscriber().SubscribeAsync("BUSINESSLOG", async (channel, redisValue) =>
                {
                    var redisValueArray = redisValue.ToString()
                        .Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    BusinessLog log = new BusinessLog()
                    {
                        LogTime = DateTime.Parse(redisValueArray[0]),
                        RuleId = int.Parse(redisValueArray[1]),
                        SrcMAC = redisValueArray[2],
                        DstMAC = redisValueArray[3]
                    };
                    _logList.Add(log);
                    //db.BusinessLogs.Add(log);
                    //await db.SaveChangesAsync();
                });
            });
        }
    }
}
