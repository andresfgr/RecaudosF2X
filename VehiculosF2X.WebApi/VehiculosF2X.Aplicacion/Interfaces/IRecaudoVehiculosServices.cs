using System.Collections.Generic;
using VehiculosF2X.Dominio.Dto;

namespace VehiculosF2X.Aplicacion.Interfaces
{
    public interface IRecaudoVehiculosServices
    {
        public List<RecaudosDto> GetAll();
        public List<RecaudosDto> ExpotarRecaudos();
    }
}
