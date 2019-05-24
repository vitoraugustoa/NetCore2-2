﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WepApi_JWT
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
            //Poderia Injetar o singinConfiguration desta forma 
             var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Account/Login/");
                options.LoginPath = new PathString("/Account/Login/");
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme , options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false ,
                    ValidateIssuer = false ,
                    ValidateIssuerSigningKey = true ,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecretaparaauth")) ,
                    // Ou IssuerSinginKey = signingConfigurations.key, 
                    ValidateLifetime = true ,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
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

            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default" ,
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
