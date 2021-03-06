﻿using Microsoft.Extensions.Logging;
using SmartSql;
using SmartSql.Abstractions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SmartSqlExtensions
    {
        public static void AddSmartSql(this IServiceCollection services)
        {
            services.AddSingleton<ISmartSqlMapper>(sp =>
            {
                var options = new SmartSqlOptions
                {
                    LoggerFactory = sp.GetService<ILoggerFactory>(),
                    ServiceProvider = sp
                };
                return MapperContainer.Instance.GetSqlMapper(options);
            });
        }

        public static void AddSmartSql(this IServiceCollection services, Func<IServiceProvider, SmartSqlOptions> setupOptions)
        {
            services.AddSingleton<ISmartSqlMapper>((sp =>
            {
                var options = setupOptions(sp);
                options.ServiceProvider = sp;
                return MapperContainer.Instance.GetSqlMapper(options);
            }));
        }
    }
}
