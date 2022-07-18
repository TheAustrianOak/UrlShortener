using System;
using InforceTask.Areas.Identity.Data;
using InforceTask.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(InforceTask.Areas.Identity.IdentityHostingStartup))]
namespace InforceTask.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MainDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShortenerDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddEntityFrameworkStores<MainDbContext>();
            });
        }
    }
}