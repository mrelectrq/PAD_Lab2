using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proxy.Models
{
    public class Server
    {
        public int ID { get; set; }

        public Server(int id)
        {
            ID = id;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
