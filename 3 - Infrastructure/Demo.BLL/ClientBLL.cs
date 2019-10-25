using System;
using System.Collections.Generic;

using Framework.Data;

using Demo.BES;
using Demo.DAL;
using Demo.Contracts;
using Demo.Validation;

namespace Demo.BLL
{
    /// <summary>
    /// Business Layer class to get/set the client info
    /// </summary>
    public sealed class ClientBLL : DatabaseHub<ClientDAL>, IClient, IDisposable
    {
        #region| Constructor |

        public ClientBLL(ContainerDI container) : base(container)
        {

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>list of ClientBES</returns>
        public IEnumerable<ClientBES> Get()
        {
            return DAL.Get();
        }

        /// <summary>
        /// Get a client based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>ClientBES</returns>
        public ClientBES GetByID(int ID)
        {
            return DAL.GetByID(ID);
        }

        /// <summary>
        /// Save a new client
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns>identification</returns>
        public int Save(ClientBES input)
        {
            Validate(input);

            return DAL.Save(input);
        }

        /// <summary>
        /// Update an existing client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public void Update(ClientBES input)
        {
            Validate(input, true);

            DAL.Update(input);
        }

        /// <summary>
        /// Delete the client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public void Delete(ClientBES input)
        {
            DAL.Delete(input);
        }

        #endregion

        #region| Validation |

        /// <summary>
        /// Validate the parameters information
        /// </summary>
        private void Validate(ClientBES input, bool IsUpdate = false)
        {
            var validator = new ClientValidator(IsUpdate);
            var result = validator.Validate(input);

            if(result.IsValid==false)
            {
                throw new Exception("Please, take a look at the validation error list");
            }
        }

        #endregion
    }
}
