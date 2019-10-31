using System;
using System.Collections.Generic;

using Framework.Data;

using Demo.Model;
using Demo.DAL;
using Demo.Contracts;

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
        public IEnumerable<Client> Get()
        {
            return DAL.Get();
        }

        /// <summary>
        /// Get all clients (compact version)
        /// </summary>
        /// <returns>list of ClientBES</returns>
        public IEnumerable<ClientCompact> GetCompact()
        {
            return DAL.GetCompact();
        }

        /// <summary>
        /// Get a client based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>ClientBES</returns>
        public Client GetByID(int ID)
        {
            return DAL.GetByID(ID);
        }

        /// <summary>
        /// Save a new client
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns>identification</returns>
        public int Save(Client input)
        {
            return DAL.Save(input);
        }

        /// <summary>
        /// Update an existing client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public void Update(Client input)
        {
            DAL.Update(input);
        }

        /// <summary>
        /// Delete the client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public int Delete(Client input)
        {
            return DAL.Delete(input);
        }

        #endregion
    }
}
