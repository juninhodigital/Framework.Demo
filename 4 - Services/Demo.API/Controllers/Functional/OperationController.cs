using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    /// <summary>
    /// This is the client controller
    /// </summary>
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        #region| Fields |

        private readonly IConfiguration configuration;

        #endregion

        #region| Constructor |

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public OperationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Reload the configuration file
        /// </summary>
        /// <returns></returns>
        [HttpOptions("reloadConfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = configuration as IConfigurationRoot;

                root.Reload();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion
    }
}
