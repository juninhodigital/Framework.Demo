using System;
using System.Collections.Generic;

using Framework.Data;

using Demo.Model;
using Demo.DAL;
using Demo.Contracts;

namespace Demo.BLL
{
    /// <summary>
    /// Business Layer class to get/set the user info
    /// </summary>
    public sealed class UserBLL : DatabaseHub<UserDAL>, IUser, IDisposable
    {
        #region| Constructor |

        public UserBLL(ContainerDI container) : base(container)
        {

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>list of User</returns>
        public IEnumerable<User> Get()
        {
            return DAL.Get();
        }

        /// <summary>
        /// Get a User based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>User</returns>
        public User GetByID(int ID)
        {
            return DAL.GetByID(ID);
        }

        /// <summary>
        /// Save a new User
        /// </summary>
        /// <param name="input">User</param>
        /// <returns>identification</returns>
        public int Save(User input)
        {
            return DAL.Save(input);
        }

        /// <summary>
        /// Update an existing User
        /// </summary>
        /// <param name="input">User</param>
        public void Update(User input)
        {
            DAL.Update(input);
        }

        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="input">User</param>
        public int Delete(User input)
        {
            return DAL.Delete(input);
        }

        #endregion
    }
}
