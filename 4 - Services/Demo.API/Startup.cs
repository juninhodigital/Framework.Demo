using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

using Framework.Core;

namespace Demo.API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        #region| Properties |

        public IConfiguration Configuration { get; }

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region| Methods |

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the dependency injection 
            Bootstrapper.RegisterServices(services, Configuration);

            // Initialize the log4Net
            Logger.SetLog4NetConfiguration();

            if (Configuration["USE.API.VERSION"].ToBool())
            {
                // Add the API Versioning
                services.AddApiVersioning(opt =>
                {
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.DefaultApiVersion = new ApiVersion(1, 0);
                    opt.ReportApiVersions = true;
                    opt.ApiVersionReader  = ApiVersionReader.Combine
                    (
                        new QueryStringApiVersionReader("ver", "version"),
                        new HeaderApiVersionReader("X-Version")
                    );

                #region| Url Versioning |

                // Uncomment the code below in case you need to use the API version in the Url (Example: www.yourapi.com/v1/clients)
                // opt.ApiVersionReader  = new UrlSegmentApiVersionReader(); 

                // Thereafter, change every existing controllers by adding the code below
                // [Route("api/v{version:ApiVersion}/[controller]")]

                #endregion

            });

            }
            // Add gzip-deflate compression
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "API Demo application",
                    Version = "1.0",
                    Description = "This is a ASP.NET Core API demo application",

                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

            });

            services.AddMvcCore().AddApiExplorer();

            services.AddMvc(opt => opt.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            // Configure Log4net            
            loggerFactory.AddLog4Net();

            // Configure gzip/deflate compression in the api layer
            app.UseResponseCompression();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API");

            });
        } 
        
        #endregion
    }
}
