using Microsoft.AspNetCore.Mvc;
using WebAPIConsultaCEP.Interfaces;
using WebAPIConsultaCEP.Models;

namespace WebAPIConsultaCEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICep _service;

        public CepController(ICep service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string cep)
        {
            try
            {
                var response = await _service.GetCepAsync(cep);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Cep inválido! Verifique o CEP informado.");
            }
        }
    }
}