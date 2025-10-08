using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaAplicacion.CasosUso.CUEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.CasosUso.CUAgencia;

namespace Obligatorio.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.
            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //DI - REPOS
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

            //DI - CASOS USO
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuarios, CUObtenerUsuarios>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
            builder.Services.AddScoped<ICUEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<ICUEliminarUsuario, CUEliminarUsuario>();
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvios, CUObtenerEnvios>();
            builder.Services.AddScoped<ICUObtenerAgencias, CUObtenerAgencias>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUAgregarSeguimiento, CUAgregarSeguimiento>();
            builder.Services.AddScoped<ICUObtenerComentarios, CUObtenerComentarios>();
            builder.Services.AddScoped<ICUObtenerEnvioPorTracking, CUObtenerEnvioPorTracking>();
            builder.Services.AddScoped<ICUObtenerEnviosPorMail, CUObtenerEnviosPorMail>();
            builder.Services.AddScoped<ICUCambiarContrasenia, CUCambiarContrasenia>();
            builder.Services.AddScoped<ICUObtenerEnviosDeClienteEntreFechas, CUObtenerEnviosDeClienteEntreFechas>();
            builder.Services.AddScoped<ICUObtenerEnviosPorMailYEstado, CUObtenerEnviosPorMailYEstado>();


            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
