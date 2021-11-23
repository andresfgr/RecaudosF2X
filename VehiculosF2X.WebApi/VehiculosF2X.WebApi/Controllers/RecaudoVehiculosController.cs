using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VehiculosF2X.Aplicacion.Interfaces;

namespace VehiculosF2X.WebApi.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudoVehiculosController : ControllerBase
    {
        private readonly IRecaudoVehiculosServices _IVehiculosServices;

        public RecaudoVehiculosController(IRecaudoVehiculosServices vehiculosServices)
        {
            _IVehiculosServices = vehiculosServices;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var result = _IVehiculosServices.GetAll();
            return Ok(result);
        }

        [HttpPost("ExportarRecaudos")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult ExportarRecaudos()
        {
            var result = _IVehiculosServices.ExpotarRecaudos();
            return Ok(result);
        }
    }
}
