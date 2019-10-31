using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using Demo.Model;
using Demo.Contracts;

namespace Demo.API.Controllers
{
    /// <summary>
    /// This is the user controller
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        #region| Constructor |

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public UserController(IConfiguration configuration, IUnitOfWork unitOfWork) : base(configuration, unitOfWork)
        {

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get all active users
        /// </summary>
        /// <returns>Returns a user list</returns>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            Track();

            try
            {
                var output = Repository.Usuario.Get().ToList();

                return output;
;
            }
            catch (System.Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
            
        }

        /// <summary>
        /// Get all users from cache
        /// </summary>
        [HttpGet("GetFromCache")]
        public ActionResult<List<User>> GetUsersFromCache()
        {
            List<User> output = null;

            var users = Repository.Usuario.Get().ToList();

            GetFromCache<List<User>>("USERS", () => output = users);
            
            // Returns a 304 status code that says the content was not modified
            return StatusCode(StatusCodes.Status304NotModified, users);
        }

        #endregion
    }
}