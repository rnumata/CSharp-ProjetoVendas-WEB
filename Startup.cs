using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendasWEB.DAL;
using VendasWEB.Models;
using VendasWEB.Utils;

namespace VendasWEB
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
            // #1
            services.AddScoped<ProdutoDAO>();
            services.AddScoped<CategoriaDAO>();
            services.AddScoped<ItemVendaDAO>();
            // #3
            services.AddHttpContextAccessor();
            services.AddScoped<Secao>();

            // #2
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            services.ConfigureExternalCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });

            // #3
            services.AddSession();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //#3
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}



/* #1
    vai criar um objs DAOs para cada cliente que acessa a app
    Cria o servico de instanciar um obj ( pex: ProdutoDAO ) que está sendo chamado no ctor do ProdutoController pex
    
 */

/* #2
    Configuracao do Context
    <Context> é o nome da classe criada
    .UseSqlServer é para o MSSqlServer
    "Connection" é a string de conexão definida como Json lá no appsettings.json
 */

/* #3
    Para trabalhar com a Session configurar 3 pontos
    services.AddHttpContextAccessor(); cria um objeto injetado para trabalhar com a session
    services.AddSession();
    app.UseSession();
 */