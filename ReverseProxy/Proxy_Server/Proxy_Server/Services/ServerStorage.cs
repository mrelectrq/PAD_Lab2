using Microsoft.Extensions.Configuration;
using Proxy_Server.Helpers;
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
        private RoundRobin _load_balancing;
        public ServerStorage(IConfiguration configuration, IServiceProvider _serviceProvider)
        {
            _config = configuration;
            storage = new Dictionary<string, Server>();
            ParseServerList();

        }

        public Server GetServer()
        {
            var selectedServer = _load_balancing.GetServer();
            return selectedServer;
        }

        private void ParseServerList()
        {

            List<Server> serverlist = new List<Server>();
            _config.GetSection("servers").Bind(serverlist);

            foreach (var item in serverlist)
            {
                storage.Add(item.ID, item);
            }
            _load_balancing = new RoundRobin(serverlist);
        }


    }
}
