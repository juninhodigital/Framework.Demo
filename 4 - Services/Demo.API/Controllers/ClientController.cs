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
        [HttpGet("getall")]
        [ProducesResponseType(typeof(List<ClientBES>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll()
        {
            Track();

            try
            {
                var clients = UnitOfWork.Cliente.Get().ToList();

                return Ok(clients);
            }
            catch (System.Exception ex)
            {
                Logger.log.Error("An exception occurred @ ClientController.GetAll", ex);

                return BadRequest(ex);
            }
            
        }

        #endregion
    }
}