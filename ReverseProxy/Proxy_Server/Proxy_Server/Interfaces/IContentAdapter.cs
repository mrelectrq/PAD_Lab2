using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proxy_Server.Interfaces
{
    public interface IContentAdapter
    {
        public bool IsAdaptable(string response_type, string content_type);
        public bool Adapt(string service, ref HttpContext context, string content);  
    }
}
