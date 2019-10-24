using System.Data;
using System.Collections.Generic;
using System.Linq;

using Framework.Data;
using Framework.Core;

using Demo.BES;
using Demo.Contracts;

namespace Demo.DAL
{
    /// <summary>
    /// Data access class to get user information
    /// </summary>
    public sealed class UserDAL : DatabaseCore, IUser
    {
        #region| Constructor |

        public UserDAL(ContainerDI container) : base(container)
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
            this.Run("SP_USER_S");

            return this.GetList<UserBES>();
        }

        /// <summary>
        /// Get a User based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>UserBES</returns>
        public UserBES GetByID(int ID)
        {
            this.Run("SP_USER_S_BY_ID");

            this.In("P_ID", ID);

            var output = new UserBES();

            using(var reader = GetReader())
            {
                output = this.Map<UserBES>(reader, true);

                if(reader.NextResult())
                {
                    output.Addresses = this.GetList<AddressBES>(reader).ToList();
                }
            }

            return output;
        }

        /// Save a new User
        /// </summary>
        /// <param name="input">UserBES</param>
        /// <returns>identification</returns>
        public int Save(UserBES input)
        {
            this.Run("SP_USER_I");

            var table = GetTable(input.Addresses, 0);

            this.InOut("P_ID", DbType.Int32);
            In("P_Name", input.Name);
            In("P_Nickname", input.Nickname);
            In("P_RG", input.RG);
            In("P_CPF", input.CPF);
            In("P_Enabled", input.Enabled);
            In("P_TVP_ADDRESS", table);

            this.Execute();

            var output = GetValue<int>("P_ID");

            return output;
        }

        /// <summary>
        /// Update an existing User
        /// </summary>
        /// <param name="input">UserBES</param>
        public void Update(UserBES input)
        {
            this.Run("SP_USER_U");

            var table = GetTable(input.Addresses, input.ID);

            In("P_ID", input.ID);
            In("P_Name", input.Name);
            In("P_Nickname", input.Nickname);
            In("P_RG", input.RG);
            In("P_CPF", input.CPF);
            In("P_Enabled", input.Enabled);
            In("P_TVP_ADDRESS", table);

            this.Execute();
        }

        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="input">UserBES</param>
        public void Delete(UserBES input)
        {
            this.Run("SP_USER_D");

            this.In("P_ID", input.ID);

            this.Execute();
        }
        
        /// <summary>
        /// Get a datatable based on user
        /// </summary>
        /// <param name="input">list of AddressBES</param>
        /// <returns>DataTable</returns>
        private DataTable GetTable(List<AddressBES> input, int userCode)
        {
            var output = new DataTable("TVP_WORKSPACE_SHARE");

            if(input.IsNotNull())
            {
                output.Columns.Add("ID", typeof(int));
                output.Columns.Add("Address", typeof(int));
                output.Columns.Add("UserCode", typeof(int));
                output.Columns.Add("Enabled", typeof(bool));

                foreach(var item in input)
                {
                    var row = output.NewRow();

                    row["ID"]           = userCode == 0 ? 0 : item.ID;
                    row["Address"]      = item.Address;
                    row["UserCode"]     = userCode;
                    row["Enabled"]      = item.Enabled;

                    output.Rows.Add(row);
                }
            }

            return output;
        }

        #endregion
    }
}
