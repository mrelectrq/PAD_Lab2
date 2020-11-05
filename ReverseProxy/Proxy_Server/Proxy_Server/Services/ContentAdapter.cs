using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Proxy_Server.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Serialization;

namespace Proxy_Server.Services
{
    public class ContentAdapter : IContentAdapter
    {
        public bool Adapt(string response_type, ref HttpContext context, string content)
        {
            if (response_type == context.Request.ContentType)
            {
                return false;
            }

            if (context.Request.Path.ToString().Contains("transaction"))
            {
                if (context.Request.ContentType == "application/xml" || context.Request.ContentType == "text/xml")
                {
                    var data = JsonConvert.DeserializeObject<List<Transaction>>(content);

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>));
                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            serializer.Serialize(writer, data);
                            var converted = sww.ToString();

                            context.Response.Body.WriteAsync(new MemoryStream(Encoding.UTF8.GetBytes(converted)).ToArray());
                            return true;
                        }
                    }

                }
                else return false;
            }
            else return false;
        }

        public bool IsAdaptable(string service, string content_type)
        {

            if (service.Contains("transaction") && (content_type == "application/xml" || content_type == "text/xml"))
                return true;
            else

                return false;
        }
    }
}
