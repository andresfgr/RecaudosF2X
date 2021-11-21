using System.Collections.Generic;
using System.Linq;
using VehiculosF2X.Aplicacion.Interfaces;
using VehiculosF2X.Dominio.Dto;
using VehiculosF2X.Infraestrcutura;
using VehiculosF2X.Aplicacion.ClientApi;
using System;
using Newtonsoft.Json;
using RestSharp;
using VehiculosF2X.Dominio.Entidades;

namespace VehiculosF2X.Aplicacion
{
    public class RecaudoVehiculoService : IRecaudoVehiculosServices
    {
        private readonly DbContextRecaudoVehiculo _DbContextVehiculo;

        public RecaudoVehiculoService(DbContextRecaudoVehiculo contexto)
        {
            _DbContextVehiculo = contexto;
        }

        public List<RecaudosDto> GetAll()
        {
            List<RecaudosDto> recaudoDtos = new List<RecaudosDto>();
            List<Recaudos> recaudosList = _DbContextVehiculo.Recaudos.ToList();

            if (recaudosList == null || recaudosList.Count == 0)
            {
                InsercionRecaudos();
                recaudosList = _DbContextVehiculo.Recaudos.ToList();
            }

            foreach (var item in recaudosList)
            {
                recaudoDtos.Add(new RecaudosDto
                {
                    IdRecaudos = item.IdRecaudos,
                    Estacion = item.Estacion,
                    Sentido = item.Sentido,
                    Hora = item.Hora,
                    Categoria = item.Categoria,
                    ValorTabulado = item.ValorTabulado,
                    Cantidad = item.Cantidad,
                    Fecha = item.Fecha.ToString("dd/MM/yyyy")
                });
            }

            return recaudoDtos
                .OrderBy(x => x.Sentido)
                .OrderBy(x => x.Fecha)
                .OrderBy(x => x.Estacion).ToList();
        }

        public List<RecaudosDto> ExpotarRecaudos()
        {
            var recaudosList = _DbContextVehiculo.Recaudos.GroupBy(t => new { t.Fecha, t.Estacion })
                .Select(s => new RecaudosDto
                {
                    Fecha = s.Key.Fecha.ToString("dd/MM/yyyy"),
                    Estacion = s.Key.Estacion,
                    Cantidad = s.Sum(x => x.Cantidad),
                    ValorTabulado = s.Sum(x => x.ValorTabulado),
                }).ToList();

            return recaudosList.OrderBy(x => x.Fecha)
                .OrderBy(x => x.Estacion).ToList();
        }

        public bool InsercionRecaudos()
        {
            int dias = 90;
            DateTime fecha = DateTime.Now;
            string url = "http://190.145.81.67:5200/api/Login";
            ClientServices clientServices = new ClientServices();
            string jsonToSend = JsonConvert.SerializeObject(new LoginRequestDTO { UserName = "user", Password = "1234" });
            var resultadoToken = clientServices.ExecuteAPI(Method.POST, url, null, jsonToSend);
            LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(resultadoToken.Content);
            string token = loginResponseDTO.Token;

            for (int i = 1; i < dias; i++)
            {
                fecha = fecha.AddDays(-1);

                url = String.Format("http://190.145.81.67:5200/api/ConteoVehiculos/{0}", fecha.ToString("yyyy-MM-dd"));
                var resultado = clientServices.ExecuteAPI(Method.GET, url, token, null);

                List<Recaudos> recaudoDtoList = JsonConvert.DeserializeObject<List<Recaudos>>(resultado.Content);
                if (recaudoDtoList != null)
                {
                    url = String.Format("http://190.145.81.67:5200/api/RecaudoVehiculos/{0}", fecha.ToString("yyyy-MM-dd"));
                    var resultadoRecaudoVehiculos = clientServices.ExecuteAPI(Method.GET, url, token, null);

                    List<Recaudos> recaudoVehiculos = JsonConvert.DeserializeObject<List<Recaudos>>(resultadoRecaudoVehiculos.Content);
                    if (recaudoVehiculos != null)
                    {
                        foreach (var item in recaudoDtoList)
                        {
                            item.ValorTabulado = recaudoVehiculos.Where(x => x.Estacion == item.Estacion && x.Sentido == item.Sentido && x.Hora == item.Hora && x.Categoria == item.Categoria).First().ValorTabulado;
                            item.Fecha = fecha;
                        }
                        _DbContextVehiculo.Recaudos.AddRange(recaudoDtoList);
                    }
                }
            }

            _DbContextVehiculo.SaveChanges();
            return true;
        }
    }
}
