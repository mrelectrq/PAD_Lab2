using Microsoft.Extensions.Configuration;
using Proxy_Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxy_Server.Services
{
    public class ServerStorage : IServerStorage
    {
        private readonly IConfiguration _config;
        private Dictionary<string, Server> storage;
        public ServerStorage(IConfiguration configuration)
        {
            _config = configuration;
            storage = new Dictionary<string, Server>();
            ParseServerList();
        }

        public Server GetServer()
        {


            return null;
        }

        private void ParseServerList()
        {
            
        }
    }
}
