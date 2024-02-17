using System.Net.Http;
using System.Net;
using WebAPIConsultaCEP.Interfaces;
using WebAPIConsultaCEP.Models;

namespace WebAPIConsultaCEP.Services
{
    public class ViaCEPService : ICep
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ViaCEPService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = GetBaseAddress(_configuration);
        }
        public async Task<CepViewModel> GetCepAsync(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync(GetUri(cep));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadFromJsonAsync<CepViewModel>().Result!;
                }
                throw new Exception();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static Uri GetBaseAddress(IConfiguration configuration) => new Uri(configuration.GetSection("API:Endpoint").Value);
        private Uri GetUri(string cep) => new Uri(_httpClient.BaseAddress!.ToString().Replace("CEP", cep));
    }
}
