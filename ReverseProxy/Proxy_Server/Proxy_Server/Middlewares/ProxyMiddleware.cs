using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Proxy_Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proxy_Server.Middlewares
{
    public class ProxyMiddleware
    {
        private static HttpClient _httpClient = new HttpClient();
        private readonly RequestDelegate _nextMiddleware;
        private readonly IServerStorage _storage;
        public ProxyMiddleware(RequestDelegate next, IServiceProvider serviceScope)
        {
            _storage = serviceScope.GetRequiredService<IServerStorage>();
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
           var request_destination = BuildUri(context.Request);

            await _nextMiddleware(context);
        }


        private Uri BuildUri(HttpRequest request)
        {

            var server = _storage.GetServer();

            var uri = new Uri(server.Location+request.Path);
            return uri;
        }
    }
}
