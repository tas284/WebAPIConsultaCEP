using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPIConsultaCEP.Interfaces;

namespace WebAPIConsultaCEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string cep)
        {
            var response = await _service.GetCepAsync(cep);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return Ok(result);
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest("Cep inválido! Verifique o CEP informado.");


            return NotFound();
        }
    }
}