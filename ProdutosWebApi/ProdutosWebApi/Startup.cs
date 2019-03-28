using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProdutosWebApi.Models;

namespace ProdutosWebApi
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

            // Adicionando o meu serviço personalizado como dependência.
            // services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();  ** O objeto injetado é criado uma vez por solicitação
            // services.AddSingleton<IProdutoRepositorio , ProdutoRepositorio>(); ** O objeto injetado é criado na primeira vez que são solicitados.
            // Cada solicitação subsequente usa a instância que foi criada na primeira vez.

            // services.AddTransient<IProdutoRepositorio , ProdutoRepositorio>(); ** O objeto injetado é criado a cada vez que são solicitados.

            services.AddSingleton<IProdutoRepositorio , ProdutoRepositorio>();


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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
