using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;

using Demo.Model;

namespace Demo.API.Controllers
{
    /// <summary>
    /// This is the client controller
    /// </summary>        
    public partial class ClientController : BaseController
    {
        #region| Methods |

        /// <summary>
        /// Get all active clients
        /// </summary>
        /// <returns>Returns a client list</returns>
        //[HttpGet, MapToApiVersion("1.1")]
        //[ProducesResponseType(typeof(List<Client>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        //public ActionResult<List<Client>> Get11()
        //{
        //    Track();

        //    try
        //    {
        //        var output = Repository.Cliente.Get().ToList();

        //        output.Insert(0, new Client { ID = 10000, Name = "Junior" });

        //        return output;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Log(this.ControllerName);

        //        return InternalError(ex);
        //    }
        //}

        #endregion
    }
}