using GraphQL;
using GraphQL.Client.Http;
using Proxy_Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proxy_Server.Services
{
    public class GraphQLClient : IClient
    {
        private readonly GraphQLHttpClient _client;

        public GraphQLClient()
        {
                  
        }

        public HttpResponseMessage SendRequest(HttpRequestMessage httpRequest)
        {
            //GraphQLHttpClientOptions options = new GraphQLHttpClientOptions();
            //options.EndPoint = httpRequest.RequestUri;

            //var trRequest = new GraphQLRequest
            //{
            //    Query = @"
            //    query Transaction(client_id :  )
            //        {
            //            client_id
            //        }
            //    "
            //};



            //_client.SendQueryAsync()

            throw new NotImplementedException();
        }
    }
}
