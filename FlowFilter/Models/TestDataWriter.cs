using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class TestDataWriter
    {
        private readonly RedisManager _redisManager;
        public TestDataWriter(RedisManager redisManager)
        {
            _redisManager = redisManager;
            Task.Run(async () =>
            {
                int i = 1;
                while (true)
                {
                    _redisManager.Instance.GetDatabase().StringSet("PORT_1", $"{i*2000},{i*1000},{i*200},{i*100},{i*300},{i*400}");
                    _redisManager.Instance.GetDatabase().StringSet("PORT_2", $"{i * 2000},{i * 1000},{i * 200},{i * 100},{i * 300},{i * 400}");
                    i++;
                    await Task.Delay(1000);
                }
            });
        }
    }
}
