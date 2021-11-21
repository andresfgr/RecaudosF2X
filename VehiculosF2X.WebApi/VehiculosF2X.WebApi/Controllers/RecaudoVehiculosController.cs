using ClosedXML.Excel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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

        [HttpPost("ExportExcel")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult ExportExcel()
        {
            var result = _IVehiculosServices.ExpotarRecaudos();
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Recaudos");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "Estación";
                worksheet.Cell(currentRow, 2).Value = "Fecha";
                worksheet.Cell(currentRow, 3).Value = "Cantidad";
                worksheet.Cell(currentRow, 4).Value = "Valor Tavulado";

                foreach (var user in result)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.Estacion;
                    worksheet.Cell(currentRow, 2).Value = user.Fecha;
                    worksheet.Cell(currentRow, 3).Value = user.Cantidad;
                    worksheet.Cell(currentRow, 4).Value = user.ValorTabulado;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RecaudosF2X.xlsx");
                }
            }
        }
    }
}
