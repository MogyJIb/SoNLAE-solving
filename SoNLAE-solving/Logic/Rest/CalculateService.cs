using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SoNLAE_solving.Logic.Models;

namespace SoNLAE_solving.Logic.Rest
{
    public class CalculateService : ICalculateService
    {
        private HttpClient httpClient;

        public CalculateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RestDTO> Calculate(RestDTO restDTO)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("",restDTO);

            return (response.IsSuccessStatusCode)
                 ? await response.Content.ReadAsAsync<RestDTO>()
                 : throw new Exception(response.StatusCode.ToString());
        }
    }
}
