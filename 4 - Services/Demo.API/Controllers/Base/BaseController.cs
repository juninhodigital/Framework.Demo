using System;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Framework.WebAPI.Cache;

using Demo.Contracts;
using Microsoft.AspNetCore.Http;

namespace Demo.API
{
    /// <summary>
    /// Abrastract class used as a base controller
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        #region| Properties |

        /// <summary>
        /// Represents a set of key/value application configuration properties
        /// </summary>
        protected readonly IConfiguration Configuration = null;

        /// <summary>
        /// Unit of work
        /// </summary>
        protected readonly UnitOfWork Repository;

        /// <summary>
        /// Controller name
        /// </summary>
        protected string ControllerName => $"{ControllerContext.ActionDescriptor.ControllerName}";

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="unitOfWork">IUnitOfWork</param>
        protected BaseController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.Configuration = configuration;
            this.Repository = (UnitOfWork)unitOfWork;
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get element(s) from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected T GetFromCache<T>(string cacheKey, Action action)
        {
            T output = default(T);

            if (CacheEngine.Exists(cacheKey))
            {
                output = CacheEngine.Get<T>(cacheKey);
            }
            else
            {
                action();
            }

            return output;
        }

        /// <summary>
        /// Returns an internal server error message
        /// </summary>
        /// <param name="message">exception message</param>
        /// <returns>ObjectResult</returns>
        protected ObjectResult InternalError(string message)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, message);
        }
        /// <summary>
        /// Returns an internal server error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>ObjectResult</returns>
        protected ObjectResult InternalError(Exception exception)
        {
            return InternalError(exception.Message);
        }

        /// <summary>
        /// Log information about the method triggered by a HTTP event
        /// </summary>
        protected void Track()
        {
            Logger.log.Info($"Track: {HttpContext.Request.Method} - {HttpContext.Request.Path}");
        }

        /// <summary>
        /// Set the log error message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        protected string Message(string message = "", [CallerMemberName] string memberName = "")
        {
            return $"An exception occurred @ {ControllerName}.{memberName}" + message;
        }
        
        #endregion
    }
}