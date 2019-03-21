using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projetoFirstIdentity21.Models;

[assembly: HostingStartup(typeof(projetoFirstIdentity21.Areas.Identity.IdentityHostingStartup))]
namespace projetoFirstIdentity21.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("ConexaoMySql")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}