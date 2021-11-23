using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosF2X.Aplicacion;
using VehiculosF2X.Aplicacion.Interfaces;
using VehiculosF2X.Infraestrcutura;

namespace VehiculosF2X.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:4200", "http://mywebsite.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            services.AddDbContext<DbContextRecaudoVehiculo>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings:VehiculoDbContext").Value));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Versión 1.0",
                    Title = "Recaudo Vihiculos FX2",
                    Description = "La api fue desarrollada en .NET Core 3.1, se hizo uso de Sql Server como gestor de base de datos para almacenar los datos obtenidos a través de la api http://190.145.81.67:5200/documentation/. \n \n Para más información: https://github.com/andresfgr/RecaudosF2X"
                });
            });
            services.AddTransient<IRecaudoVehiculosServices, RecaudoVehiculoService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vihiculos FX2"));
            app.UseRouting();
            app.UseCors("CorsApi");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
