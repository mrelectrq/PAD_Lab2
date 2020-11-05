using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Proxy_Server.Interfaces;
using Proxy_Server.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Server.Middlewares
{
    public class ProxyMiddleware
    {
        private static HttpClient _httpClient = new HttpClient();
        private readonly RequestDelegate _nextMiddleware;
        private readonly IServerStorage _storage;
        private readonly IContentAdapter _adapter;
        private static IClient _graphQlClient;
        public ProxyMiddleware(RequestDelegate next, IServiceProvider serviceScope)
        {
            _storage = serviceScope.GetRequiredService<IServerStorage>();
            _adapter = serviceScope.GetRequiredService<IContentAdapter>();
            _nextMiddleware = next;
            _graphQlClient = new GraphQLClient();
        }


        public async Task Invoke(HttpContext context)
        {
            var request_destination = BuildUri(context.Request);
            var message = FormateMessage(context, request_destination);


            if (_adapter.IsAdaptable(context.Request.Path, context.Request.ContentType)
                && context.Request.Method=="GET")
            {


                var response = _graphQlClient.SendRequest(message);
                var adapted = _adapter.Adapt(response.Content.Headers.ContentType.MediaType,ref context,
                    response.Content.ReadAsStringAsync().Result);
                if(adapted==false)
                {
                  _= context.Response.Body.WriteAsync(response.Content.ReadAsByteArrayAsync().Result);
                }
               
                ConcatenateResponseToContext(context,response);
            }
            else
            {
                try
                {
                    {
                        using (var responseMessage = await _httpClient.SendAsync(message, HttpCompletionOption.ResponseContentRead))
                        {
                            // context.Response.StatusCode = (int)responseMessage.StatusCode;
                            ConcatenateResponseToContext(context, responseMessage);

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }


            await _nextMiddleware(context);
        }

        private HttpRequestMessage FormateMessage(HttpContext context, Uri uri)
        {
            var message = new HttpRequestMessage()
            {
                Method = GetRequestMethod(context.Request),
                RequestUri = uri,
                Content = new StreamContent(context.Request.Body)
            };

            foreach (var item in context.Request.Headers)
            {
                message.Content.Headers.TryAddWithoutValidation(item.Key, item.Value.ToArray());
            }

            return message;
        }

        private HttpMethod GetRequestMethod(HttpRequest request)
        {
            var method = request.Method;
            return new HttpMethod(method);
        }
        private Uri BuildUri(HttpRequest request)
        {

            var server = _storage.GetServer();

            var uri = new Uri(server.Location + request.Path);
            return uri;
        }

        private void ConcatenateResponseToContext(HttpContext context, HttpResponseMessage message)
        {

            context.Response.StatusCode = (int)message.StatusCode;
            //HttpHeaders
            foreach (var item in message.Headers)
            {
                context.Request.Headers[item.Key] = item.Value.ToArray();
            }
            //Content Header RFC 2616
            foreach (var item in message.Content.Headers)
            {
                context.Response.Headers[item.Key] = item.Value.ToArray();
            }
            context.Response.Headers.Remove("transfer-encoding");
            context.Response.Body.WriteAsync(message.Content.ReadAsByteArrayAsync().Result);


        }
    }
}
