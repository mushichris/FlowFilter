using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class BusinessStatisticsReceiver
    {
        private readonly RedisManager _redisManager;
        public DateTime LastDataTime { get; set; }
        public ulong Port1RxPackets { get; set; }
        public ulong Port1TxPackets { get; set; }
        public ulong Port1RxBytes { get; set; }
        public ulong Port1TxBytes { get; set; }
        public ulong Port1AppProtocolPacket { get; set; }
        public ulong Port1DropPacket { get; set; }
        public ulong Port2RxPackets { get; set; }
        public ulong Port2TxPackets { get; set; }
        public ulong Port2RxBytes { get; set; }
        public ulong Port2TxBytes { get; set; }
        public ulong Port2AppProtocolPacket { get; set; }
        public ulong Port2DropPacket { get; set; }
        public SortedList<DateTime, BusinessStatistics> BusinessStatisticsList { get; }

        public BusinessStatisticsReceiver(RedisManager redisManager)
        {
            _redisManager = redisManager;
            BusinessStatisticsList = new SortedList<DateTime, BusinessStatistics>(3604);
            Task.Run(() =>
            {
                while (true)
                {
                    //Test();
                    BusinessStatistics businessStatistics = new BusinessStatistics();
                    string port1Statistics = _redisManager.Instance.GetDatabase().StringGet("PORT_1");
                    string port2Statistics = _redisManager.Instance.GetDatabase().StringGet("PORT_2");
                    businessStatistics.Time = DateTime.Now;
                    double intervalSeconds = (businessStatistics.Time - LastDataTime).TotalSeconds;
                    LastDataTime = businessStatistics.Time;
                    if (!string.IsNullOrEmpty(port1Statistics))
                    {
                        string[] port1StatisticsStrings =
                            port1Statistics.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                        ulong.TryParse(port1StatisticsStrings[0], out ulong rxBytes);
                        ulong.TryParse(port1StatisticsStrings[1], out ulong txBytes);
                        ulong.TryParse(port1StatisticsStrings[2], out ulong rxPackets);
                        ulong.TryParse(port1StatisticsStrings[3], out ulong txPackets);
                        ulong.TryParse(port1StatisticsStrings[4], out ulong appProtocolPacket);
                        ulong.TryParse(port1StatisticsStrings[5], out ulong dropPacket);

                        businessStatistics.Port1RxBytesPerSecond =
                            (ulong)Math.Floor((rxBytes - Port1RxBytes) / intervalSeconds);
                        businessStatistics.Port1TxBytesPerSecond =
                            (ulong)Math.Floor((txBytes - Port1TxBytes) / intervalSeconds);
                        businessStatistics.Port1RxPacketPerSecond =
                            (ulong)Math.Floor((rxPackets - Port1RxPackets) / intervalSeconds);
                        businessStatistics.Port1TxPacketPerSecond =
                            (ulong)Math.Floor((txPackets - Port1TxPackets) / intervalSeconds);
                        businessStatistics.Port1AppProtocolPacket = appProtocolPacket;
                        businessStatistics.Port1DropPacket = dropPacket;

                        Port1RxBytes = rxBytes;
                        Port1TxBytes = txBytes;
                        Port1RxPackets = rxPackets;
                        Port1TxPackets = txPackets;
                        Port1AppProtocolPacket = appProtocolPacket;
                        Port1DropPacket = dropPacket;
                    }
                    if (!string.IsNullOrEmpty(port2Statistics))
                    {
                        string[] port2StatisticsStrings =
                            port2Statistics.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        ulong.TryParse(port2StatisticsStrings[0], out ulong rxBytes);
                        ulong.TryParse(port2StatisticsStrings[1], out ulong txBytes);
                        ulong.TryParse(port2StatisticsStrings[2], out ulong rxPackets);
                        ulong.TryParse(port2StatisticsStrings[3], out ulong txPackets);
                        ulong.TryParse(port2StatisticsStrings[4], out ulong appProtocolPacket);
                        ulong.TryParse(port2StatisticsStrings[5], out ulong dropPacket);

                        businessStatistics.Port2RxBytesPerSecond =
                            (ulong)Math.Floor((rxBytes - Port2RxBytes) / intervalSeconds);
                        businessStatistics.Port2TxBytesPerSecond =
                            (ulong)Math.Floor((txBytes - Port2TxBytes) / intervalSeconds);
                        businessStatistics.Port2RxPacketPerSecond =
                            (ulong)Math.Floor((rxPackets - Port2RxPackets) / intervalSeconds);
                        businessStatistics.Port2TxPacketPerSecond =
                            (ulong)Math.Floor((txPackets - Port2TxPackets) / intervalSeconds);
                        businessStatistics.Port2AppProtocolPacket = appProtocolPacket;
                        businessStatistics.Port2DropPacket = dropPacket;

                        Port2RxBytes = rxBytes;
                        Port2TxBytes = txBytes;
                        Port2RxPackets = rxPackets;
                        Port2TxPackets = txPackets;
                        Port2AppProtocolPacket = appProtocolPacket;
                        Port2DropPacket = dropPacket;
                    }
                    if (BusinessStatisticsList.Count >= 3600)
                    {
                        BusinessStatisticsList.RemoveAt(0);
                    }
                    BusinessStatisticsList.Add(businessStatistics.Time, businessStatistics);
                    Thread.Sleep(1000);
                }
            });
        }

        private void Test()
        {
            var random = new Random();
            _redisManager.Instance.GetDatabase().StringSet("PORT_1", $"{random.Next((int)Port1RxBytes,           (int)Port1RxBytes + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port1TxBytes,           (int)Port1TxBytes + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port1RxPackets,         (int)Port1RxPackets + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port1TxPackets,         (int)Port1TxPackets + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port1AppProtocolPacket, (int)Port1AppProtocolPacket + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port1DropPacket,        (int)Port1DropPacket + random.Next(10000))}");
            _redisManager.Instance.GetDatabase().StringSet("PORT_2", $"{random.Next((int)Port2RxBytes,           (int)Port2RxBytes + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port2TxBytes,           (int)Port2TxBytes + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port2RxPackets,         (int)Port2RxPackets + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port2TxPackets,         (int)Port2TxPackets + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port2AppProtocolPacket, (int)Port2AppProtocolPacket + random.Next(10000))}," +
                                                                     $"{random.Next((int)Port2DropPacket,        (int)Port2DropPacket + random.Next(10000))}");
        }
    }

    public class BusinessStatistics
    {
        public DateTime Time { get; set; }
        public ulong Port1RxBytesPerSecond { get; set; }
        public ulong Port1TxBytesPerSecond { get; set; }
        public ulong Port1RxPacketPerSecond { get; set; }
        public ulong Port1TxPacketPerSecond { get; set; }
        public ulong Port1AppProtocolPacket { get; set; }
        public ulong Port1DropPacket { get; set; }
        public ulong Port2RxBytesPerSecond { get; set; }
        public ulong Port2TxBytesPerSecond { get; set; }
        public ulong Port2RxPacketPerSecond { get; set; }
        public ulong Port2TxPacketPerSecond { get; set; }
        public ulong Port2AppProtocolPacket { get; set; }
        public ulong Port2DropPacket { get; set; }
    }
}
