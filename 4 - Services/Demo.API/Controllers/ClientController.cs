using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Framework.Core;

using Demo.Model;
using Demo.Contracts;
using Demo.Validation;

namespace Demo.API.Controllers
{
    /// <summary>
    /// This is the client controller
    /// </summary>
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        #region| Constructor |

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public ClientController(IConfiguration configuration, IUnitOfWork unitOfWork) : base(configuration, unitOfWork)
        {

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get all active clients
        /// </summary>
        /// <returns>Returns a client list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Client>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult<List<Client>> Get()
        {
            Track();

            try
            {
                var output = Repository.Cliente.Get().ToList();

                return output;
            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Get all active clients (compact version)
        /// </summary>
        /// <returns>Returns a client list</returns>
        [HttpGet("compact")]
        public ActionResult<List<ClientCompact>> GetCompact()
        {
            Track();

            try
            {
                var output = Repository.Cliente.GetCompact().ToList();

                return output;
            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Get a client based on the identification
        /// </summary>
        /// <returns>Returns a client list</returns>
        [HttpGet("{id}")]
        public ActionResult<Client> GetByID(int ID)
        {
            Track();

            try
            {
                var output = Repository.Cliente.GetByID(ID);

                if(output.IsNotNull())
                {
                    return output; 
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns>Client</returns>
        [HttpPost]
        public IActionResult Post(Client input)
        {
            Track();

            var validationResult = Validate(input);

            if (validationResult.IsNotNull())
            {
                return BadRequest(validationResult);
            }

            try
            {
                input.ID = this.Repository.Cliente.Save(input);

                var link = $"api/{ControllerName}/{input.ID}";

                return Created(link, input);

            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Update an existing client 
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<Client> Put(Client input)
        {
            Track();

            var validationResult = Validate(input);

            if (validationResult.IsNotNull())
            {
                return BadRequest(validationResult);
            }

            try
            {
                Repository.Cliente.Update(input);

                return input;
            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Delete an existing client
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                var affectedRows = Repository.Cliente.Delete(new Client { ID = ID });

                return Ok();

            }
            catch (Exception ex)
            {
                ex.Log(this.ControllerName);

                return InternalError(ex);
            }
        }

        #endregion

        #region| Validation |

        /// <summary>
        /// Validate the parameters information
        /// </summary>
        private string Validate(Client input, bool IsUpdate = false)
        {
            var modelValidator   = new ClientValidator(IsUpdate);
            var validationResult = modelValidator.Validate(input);

            return validationResult.GetMessage();
        }

        #endregion
    }
}