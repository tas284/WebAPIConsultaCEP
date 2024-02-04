using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebAPIConsultaCEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {

        [HttpGet("version")]
        public ActionResult<string> Version()
        {
            return Ok(new AssemblyTitleAttribute("1.0").Title);
        }
    }
}