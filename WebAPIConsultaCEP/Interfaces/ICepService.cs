using WebAPIConsultaCEP.Models;

namespace WebAPIConsultaCEP.Interfaces
{
    public interface ICep
    {
        public Task<CepViewModel> GetCepAsync(string cep);
    }
}
