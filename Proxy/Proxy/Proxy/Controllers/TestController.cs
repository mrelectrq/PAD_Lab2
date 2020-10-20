using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proxy.Models;

namespace Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public void Get()
        {
            List<Server> servers = new List<Server>();
            for (int i = 0; i < 10; i++)
            {
                servers.Add(new Server(i));
            }
            ConsistentHash<Server> ch = new ConsistentHash<Server>();
            ch.Init(servers);

            int search = 10;

            SortedList<int, int> ay1 = new SortedList<int, int>();
            for (int i = 0; i < search; i++)
            {
                int temp = ch.GetNode(i.ToString()).ID;

                ay1[i] = temp;
            }

            ch.Remove(servers[1]);
        }
    }
}
