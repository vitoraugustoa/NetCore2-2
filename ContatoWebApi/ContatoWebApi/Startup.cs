using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContatoWebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace ContatoWebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Registrar o meu DbContext como um serviço
            services.AddDbContext<ContatoDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("ConexaoMySql")));

            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1" , new OpenApiInfo { Title = "ContatosWebApi" , Version = "v1" , Description = "Web Api .net core"});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app , IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseSwagger();
            // Usar <url da api>/swagger  para obter a interface da sua web API
            // Usar <url da api>/swagger/v1/swagger.json   ** Para obter a documentação da sua web Api 
            // Para a que a documentação funcione corretamente utilzar [Https<method>] e [Form] exemplo em ContatoController nas actions
            // Para mais informações acessar a documentação -> https://github.com/domaindrivendev/Swashbuckle.AspNetCore
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json" , "ContatosWebApi V1");

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Teste}/{action=Index}/{id?}");            
            });
        }
    }
}
