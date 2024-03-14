using App.Infrastructure.Persistence;
using App.Infrastructure.Persistence.Repositories;
//using App.Infrastructure.Persistence.UnitOfWork;
using App.Infrastructure.ServiceAgents;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class InfrastructureDIConfig
    {
        public static void AddConfig(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceAgent, ServiceAgent>();
        }
    }
}
