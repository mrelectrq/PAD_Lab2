using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proxy_Server.Interfaces
{
    public interface IClient
    {
        public HttpResponseMessage SendRequest(HttpRequestMessage httpRequest);
    }
}

