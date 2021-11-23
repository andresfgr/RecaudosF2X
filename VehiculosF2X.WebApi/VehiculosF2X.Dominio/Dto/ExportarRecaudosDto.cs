using System.Collections.Generic;

namespace VehiculosF2X.Dominio.Dto
{
    public class ExportarRecaudosDto
    {
        public List<string> Estaciones { get; set; }
        public List<string> Fechas { get; set; }
        public List<RecaudosDto> Recaudos { get; set; }
    }
}
