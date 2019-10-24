using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Framework.Data;
using Framework.Data.SQL;

using Demo.Contracts;

namespace Demo.API
{
    /// <summary>
    /// Dependency injection bootstraper
    /// </summary>
    public static class Bootstrapper
    {
        #region| Fields |

        private static IServiceProvider ServiceProvider { get; set; }
        private static IServiceCollection Services { get; set; }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        /// <summary>
        /// Register Services
        /// </summary>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterServices()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            return RegisterServices(new ServiceCollection(), configuration);
        }

        /// <summary>
        /// Register Services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;

            //Inject here
            services.AddSingleton<IConfiguration>(configuration);

            // Dependency injectiion
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //services.AddTransient<IDatabaseRepository, SQLDatabaseRepository>();
            //services.AddTransient<IDatabaseContext, SQLDatabaseContext>();

            return Services;
        }

        #endregion
    }
}
