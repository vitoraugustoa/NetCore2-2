using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspnCore22Empty_NetCli.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AspnCore22Empty_NetCli
{
    public class Startup
    {
        public IConfiguration _config { get; set;}

        public Startup()
        {
            // This is a middleware that read the archive of configuration. 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                _config = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adding the service IMensageSerivce
            //services.AddSingleton<IMensageService,TextoMensagemService>(); 

            //Setting the object _config through a provider LAMBDA.
            services.AddSingleton(provider => _config);
            services.AddSingleton<IMensageService, ConfigurationMensagemService>();
            
            //Add services to use Session
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // And here i'm do a dependency inject 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMensageService msg)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler();
                //app.UseStatusCodePages("text/html","<h1> deu ruim! </h1>");
                //app.UseStatusCodePagesWithRedirects("/MinhaPaginaErro/{0}");
                //app.UseStatusCodePagesWithRedirects("/MinhaPaginaErro/{0}");
            }
           

            //Configuration to use static files on wwwroot folder
            //app.UseStaticFiles();

            //Using FileProvider to acess archives on diferents folders than wwwroot
             app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Arquivos")),
                RequestPath = "/Arquivos"
            });
            
            //middleware to use Session in ASP .NET CORE
            app.UseSession();
        
            app.Run(async (context) =>
            {
                var mensagem = _config["Mensagem"];
                await context.Response.WriteAsync(msg.GetMensagem());
            });
        }
    }
}
