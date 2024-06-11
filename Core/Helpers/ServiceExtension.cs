using FluentValidation;
using Services.A.Core.Events;
using Services.A.Core.Interfaces;
using Services.A.Core.Models;
using Services.A.Core.Repositories;
using Services.A.Infrastructure;
using Services.A.Infrastructure.DB;
using Services.A.Infrastructure.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace Services.A.Core.Helpers
{
    public static class ServiceExtension
    {
        [Conditional("DEBUG")]
        static void AddDebugModeRepositories(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
                return new RabbitMQBus(scopeFactory, appSettings);
            });

            services.AddScoped<IDBRepo, DBRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<ILoggerRepo, LoggerRepo>();
            services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<ServiceExceptions>();
        }

        [Conditional("RELEASE")]
        static void AddReleaseModeRepositories(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
                return new RabbitMQBus(scopeFactory, appSettings);
            });
            services.AddScoped<IDBRepo, DBRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<ILoggerRepo, LoggerRepo>();
            services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<ServiceExceptions>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            AddDebugModeRepositories(services);
            AddReleaseModeRepositories(services);
        }
    }
}
