using System;
using System.ComponentModel.DataAnnotations;

namespace VehiculosF2X.Dominio.Entidades
{
    public class Recaudos
    {
        [Key]
        public int IdRecaudos { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public int ValorTabulado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
