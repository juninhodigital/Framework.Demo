using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Framework.Core;

using Demo.BES;
using Demo.Contracts;

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
        [ProducesResponseType(typeof(List<ClientBES>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult<List<ClientBES>> Get()
        {
            Track();

            try
            {
                var output = UnitOfWork.Cliente.Get().ToList();

                return output;
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ ClientController.GetAll", ex);

                return InternalError(ex);
            }
            
        }

        /// <summary>
        /// Get a client based on the identification
        /// </summary>
        /// <returns>Returns a client list</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientBES), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public ActionResult<ClientBES> GetByID(int ID)
        {
            Track();

            try
            {
                var output = UnitOfWork.Cliente.GetByID(ID);

                if(output.IsNotNull())
                {
                    return output; 
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ ClientController.GetByID", ex);

                return InternalError(ex);
            }
        }

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ClientBES input)
        {
            Track();

            try
            {
                input.ID = this.UnitOfWork.Cliente.Save(input);

                var link = $"api/{ControllerName}/{input.ID}";

                return Created(link, input);
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ ClientController.Save", ex);

                return InternalError(ex);
            }
        }

        #endregion
    }
}