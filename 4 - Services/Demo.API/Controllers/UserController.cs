using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Demo.BES;
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
        /// <returns>Returns a user lista</returns>
        [HttpGet("getall")]
        [ProducesResponseType(typeof(List<UserBES>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            Track();

            try
            {
                var users = UnitOfWork.Usuario.Get().ToList();

                return Ok(users);
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ UserController.GetAll", ex);

                return BadRequest(ex);
            }
            
        }

        /// <summary>
        /// Get all users from cache
        /// </summary>
        private List<UserBES> GetUsersFromCache()
        {
            List<UserBES> output = null;

            var users = UnitOfWork.Usuario.Get().ToList();

            GetFromCache<List<UserBES>>("USERS", () => output = users);

            return output;
        }

        #endregion
    }
}