﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SessionNetCore
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
                // Se marcado CheckConsentNeeded como true , o cookie , session só irão funcionar caso o usuário aceite os temos.
                // Se marcado como False cookie e session irão funcionar sem concentimento do usuário.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>(); //  O objeto injetado é criado na primeira vez que são solicitados.

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true; //HttpOnly : define se o cookie é acessível por meio do JavaScript. O padrão é true, o que significa que 
                // não pode ser acessado via scripts no lado do cliente.
                options.Cookie.Name = ".Fiver.Session"; // Name : usado para substituir o nome do cookie padrão.
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // SecurePolicy : determina se o cookie de sessão é transmitido somente por meio de solicitações HTTPS.
                options.IdleTimeout = TimeSpan.FromMinutes(10); // IdleTimeout : define o tempo de expiração da sessão, cada solicitação redefine o tempo limite. O padrão é 20 minutos.
                options.Cookie.IsEssential = true; //  Torne o cookie da sessão essencial
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default" ,
                    template: "{controller=Home}/{action=Inicio}/{id?}");
            });
        }
    }
}
