using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HormonaCrecimiento.App.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace HormonaCrecimiento.App.Presentacion
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

            // AGREGAR CADA REPOSITORIO MEMORIA
            services.AddSingleton<IRepositorioPacienteMemoria,RepositorioPacienteMemoria>();
            services.AddSingleton<IRepositorioMedicoMemoria,RepositorioMedicoMemoria>();
            services.AddSingleton<IRepositorioFamiliarMemoria,RepositorioFamiliarMemoria>();
            
            //REPOSITORIO BASE DE DATOS
            services.AddScoped<IRepositorioPaciente,RepositorioPaciente>();
            services.AddScoped<IRepositorioMedico,RepositorioMedico>();
            services.AddScoped<IRepositorioFamiliar,RepositorioFamiliar>();
            services.AddScoped<IRepositorioHistoriaClinica,RepositorioHistoriaClinica>();

            services.AddDbContext<Persistencia.AppContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HormonaCrecimientoContext")));

            
            

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
