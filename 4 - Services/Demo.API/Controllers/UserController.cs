using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using Framework.Core;

using Demo.Model;
using Demo.Contracts;
using Demo.Validation;

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
        /// Add a new user to the database
        /// </summary>
        /// <param name="input">User</param>
        /// <returns>User</returns>
        [HttpPost]
        public ActionResult<User> Post(User input)
        {
            Track();

            var validationResult = Validate(input);

            if(validationResult.IsNotNull())
            {
                return BadRequest(validationResult);
            }

            try
            {
                input.ID = this.Repository.Usuario.Save(input);

                var link = $"api/{ControllerName}/{input.ID}";

                return Created(link, input);

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
            Track();

            List<User> output = null;

            var users = Repository.Usuario.Get().ToList();

            GetFromCache<List<User>>("USERS", () => output = users);
            
            // Returns a 304 status code that says the content was not modified
            return StatusCode(StatusCodes.Status304NotModified, users);
        }

        #endregion
        
        #region| Validation |

        /// <summary>
        /// Validate the parameters information
        /// </summary>
        private string Validate(User input, bool IsUpdate = false)
        {
            var modelValidator = new UserFullValidator(IsUpdate);
            var validationResult = modelValidator.Validate(input);

            return validationResult.GetMessage();
        }

        #endregion
    }
}