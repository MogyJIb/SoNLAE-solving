using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Rest
{
    public class RestApi
    {
        private string base_url;
        private static HttpClient httpClient;
        
        public RestApi() : this ("http://127.0.0.1/") { }

        public RestApi(string base_url)
        {
            this.base_url = base_url;

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(base_url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ICalculateService CalculateService
        {
            get { return new CalculateService(httpClient); }
        }
    }
}
