namespace WebAPIConsultaCEP.Interfaces
{
    public interface ICepService
    {
        public Task<HttpResponseMessage> GetCepAsync(string cep);
    }
}
