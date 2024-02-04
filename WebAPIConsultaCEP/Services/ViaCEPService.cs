using WebAPIConsultaCEP.Interfaces;

namespace WebAPIConsultaCEP.Services
{
    public class ViaCEPService : ICepService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _endpoint;

        public ViaCEPService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _endpoint = this._configuration.GetSection("API").GetSection("Endpoint").Value;
        }

        public async Task<HttpResponseMessage> GetCepAsync(string cep)
        {
            try
            {
                SetUri(cep);
                var response = await this._httpClient.GetAsync(_httpClient.BaseAddress);
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception on ViaCEPService: " + ex.Message);

                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }

        private void SetUri(string cep) => this._httpClient.BaseAddress = new Uri($"{this._endpoint}{cep}/json/");
    }
}
