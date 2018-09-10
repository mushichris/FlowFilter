using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace FlowFilter.Models
{
    public class RedisManager : IDisposable
    {
        public string IpAndPort { get; } = "127.0.0.1";
        public RedisManager() { }
        public RedisManager(string ipAndPort)
        {
            this.IpAndPort = ipAndPort;
        }
        private ConnectionMultiplexer instance;
        private readonly object locker = new object();
        public ConnectionMultiplexer Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null || instance.IsConnected == false)
                    {
                        instance = ConnectionMultiplexer.Connect(IpAndPort);
                    }
                }
                return instance;
            }
        }
        public void Dispose()
        {
            lock (locker)
            {
                if (instance != null)
                {
                    try
                    {
                        instance.Close(true);
                    }
                    catch { }
                }
            }
        }
    }
}
