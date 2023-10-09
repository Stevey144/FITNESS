using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pos8Company.Web.RepositoryLayer
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient();
           // Client.BaseAddress = new Uri(Microsoft.IdentityModel.Protocols.ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, HttpContent model)
        {
            return Client.PutAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, HttpContent model)
        {
            return Client.PostAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
