using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowFilter.Data;
using FlowFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FlowFilter.Controllers
{
    [Authorize(Roles = "Log")]
    public class LogController : Controller
    {
        private readonly FlowFilterContext db;
        private readonly BusinessStatisticsReceiver _statisticsReceiver;
        public LogController(FlowFilterContext context, BusinessStatisticsReceiver statistics)
        {
            db = context;
            _statisticsReceiver = statistics;
        }

        public IActionResult BusinessLog()
        {
            return View();
        }

        public IActionResult SystemLog()
        {
            return View();
        }

        public IActionResult BusinessStatistics()
        {
            return View();
        }

        public async Task<IActionResult> GetBusinessLogList(string startTime, string endTime, string mac, string ruleId, int page = 1, int limit = 10)
        {
            startTime = string.IsNullOrEmpty(startTime) ? "" : startTime;
            endTime = string.IsNullOrEmpty(endTime) ? "2999-12-31" : endTime;
            mac = string.IsNullOrEmpty(mac) ? "" : mac;
            DateTime.TryParse(startTime, out DateTime startDateTime);
            DateTime.TryParse(endTime, out DateTime endDateTime);
            var logs = await db.BusinessLogs.AsNoTracking().Where(s =>
                s.LogTime > startDateTime && s.LogTime < endDateTime &&
                (s.SrcMAC.Contains(mac) || s.DstMAC.Contains(mac))).OrderByDescending(s=>s.LogTime).Select(s => new
            {
                Id = s.Id,
                RuleId = s.RuleId.ToString(),
                LogTime = s.LogTime.ToString("yyyy-MM-dd HH:mm:ss"),
                SrcMAC = s.SrcMAC,
                DstMAC = s.DstMAC
            }).ToListAsync();
            if (!string.IsNullOrEmpty(ruleId))
            {
                logs = logs.Where(s => s.RuleId == ruleId).ToList();
            }
            var retList = new
            {
                code = 0,
                msg = "",
                count = logs?.Count(),
                data = logs?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        public async Task<IActionResult> GetBusinessStatistics(double jsMilliseconds)
        {
            DateTime dataStartTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local) +
                                     TimeSpan.FromMilliseconds(jsMilliseconds);
            //DateTime.TryParse(lastTime, out DateTime dataStartTime);
            var data = _statisticsReceiver.BusinessStatisticsList.Where(s => s.Key > dataStartTime.AddSeconds(1)).Select(s=>new
            {
                Time = (long)(s.Value.Time - TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local)).TotalMilliseconds,
                //Time = s.Value.Time.ToString("yyyy-MM-dd HH:mm:ss"),
                s.Value.Port1AppProtocolPacket,
                s.Value.Port1DropPacket,
                s.Value.Port1RxBytesPerSecond,
                s.Value.Port1RxPacketPerSecond,
                s.Value.Port1TxBytesPerSecond,
                s.Value.Port1TxPacketPerSecond,
                s.Value.Port2AppProtocolPacket,
                s.Value.Port2DropPacket,
                s.Value.Port2RxBytesPerSecond,
                s.Value.Port2RxPacketPerSecond,
                s.Value.Port2TxBytesPerSecond,
                s.Value.Port2TxPacketPerSecond
            });
            return Content(JsonConvert.SerializeObject(data));
        }
    }
}