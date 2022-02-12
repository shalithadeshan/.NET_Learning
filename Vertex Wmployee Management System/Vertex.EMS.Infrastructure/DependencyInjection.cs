using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vertex.EMS.Infrastructure.Data;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Infrastructure.Data.Repositories;

namespace Vertex.EMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // getting connection string from appSettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Adding EF
            services.AddDbContext<AppDbContext>(config =>
            {
                // tell EF that we are going to use SQLServer as th DB for our project
                config.UseSqlServer(connectionString);
                config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            // services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
