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
        public ServerStorage(IConfiguration configuration, IServiceProvider _serviceProvider)
        {
            _config = configuration;
            storage = new Dictionary<string, Server>();
            ParseServerList();
        }

        public Server GetServer()
        {

            // need to implement something ballance
           var selected = storage.FirstOrDefault(m => m.Key == "MN00001");
            return selected.Value;
        }

        private void ParseServerList()
        {
            List<Server> serverlist = new List<Server>();
            _config.GetSection("servers").Bind(serverlist);

            foreach(var item in serverlist)
            {
                storage.Add(item.ID, item);
            }
        }
    }
}
