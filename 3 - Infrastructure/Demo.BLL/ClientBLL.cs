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
        /// Get all Users
        /// </summary>
        /// <returns>list of UserBES</returns>
        public IEnumerable<UserBES> Get()
        {
            return DAL.Get();
        }

        /// <summary>
        /// Get a User based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>UserBES</returns>
        public UserBES GetByID(int ID)
        {
            return DAL.GetByID(ID);
        }

        /// <summary>
        /// Save a new User
        /// </summary>
        /// <param name="input">UserBES</param>
        /// <returns>identification</returns>
        public int Save(UserBES input)
        {
            Validate(input);

            return DAL.Save(input);
        }

        /// <summary>
        /// Update an existing User
        /// </summary>
        /// <param name="input">UserBES</param>
        public void Update(UserBES input)
        {
            Validate(input, true);

            DAL.Update(input);
        }

        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="input">UserBES</param>
        public void Delete(UserBES input)
        {
            DAL.Delete(input);
        }

        #endregion

        #region| Validation |

        /// <summary>
        /// Validate the parameters information
        /// </summary>
        private void Validate(UserBES input, bool IsUpdate = false)
        {
            var validator = new UserValidator(IsUpdate);
            var result = validator.Validate(input);

            if(result.IsValid==false)
            {
                throw new Exception("Please, take a look at the validation error list");
            }
        }

        #endregion
    }
}
