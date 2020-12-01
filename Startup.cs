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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
            });

            //#1
            services.AddScoped<ProdutoDAO>();
            services.AddScoped<CategoriaDAO>();
            services.AddScoped<ItemVendaDAO>();
            services.AddScoped<Secao>();

            services.AddHttpContextAccessor();

            //#2
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddIdentity<Usuario, IdentityRole>().
                AddEntityFrameworkStores<Context>().
                AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });

            //#3
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
    Cria o servico de instanciar um obj ( pex: ProdutoDAO ) que est� sendo chamado no ctor do ProdutoController pex
    
 */

/* #2
    Configuracao do Context
    <Context> � o nome da classe criada
    .UseSqlServer � para o MSSqlServer
    "Connection" � a string de conex�o definida como Json l� no appsettings.json
 */

/* #3
    Para trabalhar com a Session configurar 3 pontos
    services.AddHttpContextAccessor(); cria um objeto injetado para trabalhar com a session
    services.AddSession();
    app.UseSession();

    Serve para n�o dar erro ao gerar Json
    services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    
 */