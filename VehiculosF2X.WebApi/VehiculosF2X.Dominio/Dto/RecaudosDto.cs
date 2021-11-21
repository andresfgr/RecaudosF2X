using System;

namespace VehiculosF2X.Dominio.Dto
{
    public class RecaudosDto
    {
        public int IdRecaudos { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public int ValorTabulado { get; set; }
        public string Fecha { get; set; }
    }
}
