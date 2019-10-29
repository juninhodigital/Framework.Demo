using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Demo.BES;
using Demo.Contracts;
using Microsoft.AspNetCore.Http;

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
        [HttpGet("getall")]
        [ProducesResponseType(typeof(List<UserBES>), (int)HttpStatusCode.OK)]
        public ActionResult<List<UserBES>> GetAll()
        {
            Track();

            try
            {
                var output = UnitOfWork.Usuario.Get().ToList();

                return output;
;
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ UserController.GetAll", ex);

                return InternalError(ex);
            }
            
        }

        /// <summary>
        /// Get all users from cache
        /// </summary>
        [HttpGet("GetFromCache")]
        [ProducesResponseType(typeof(List<UserBES>), (int)HttpStatusCode.OK)]
        private ActionResult<List<UserBES>> GetUsersFromCache()
        {
            List<UserBES> output = null;

            var users = UnitOfWork.Usuario.Get().ToList();

            GetFromCache<List<UserBES>>("USERS", () => output = users);
            
            // Returns a 304 status code that says the content was not modified
            return StatusCode(StatusCodes.Status304NotModified, users);
        }

        #endregion
    }
}