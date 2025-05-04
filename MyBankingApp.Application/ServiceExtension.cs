using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(new[] { typeof(MyBankingApp.Application.AssemblyReference).Assembly });
            services.AddValidatorsFromAssembly(typeof(MyBankingApp.Application.AssemblyReference).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(MyBankingApp.Application.AssemblyReference).Assembly);
            });

            return services;
        }
    }
}
