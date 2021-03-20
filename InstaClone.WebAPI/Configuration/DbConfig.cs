using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using InstaClone.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace InstaClone.WebAPI.Configuration
{
    public static class DbConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //TODO TIRAR ip quando for

            services.AddDbContext<InstaContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b =>
                {
                    b.MigrationsAssembly("InstaClone.WebAPI");
                    b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));

        }
    }
}
