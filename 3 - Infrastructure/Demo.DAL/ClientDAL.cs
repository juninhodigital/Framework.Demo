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
    /// Data access class to get client information
    /// </summary>
    public sealed class ClientDAL : DatabaseCore, IClient
    {
        #region| Constructor |

        public ClientDAL(ContainerDI container) : base(container)
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
            this.Run("SP_USER_S");

            return this.GetList<ClientBES>();
        }

        /// <summary>
        /// Get a client based on its identification
        /// </summary>
        /// <param name="ID">identification</param>
        /// <returns>ClientBES</returns>
        public ClientBES GetByID(int ID)
        {
            this.Run("SP_USER_S_BY_ID");

            this.In("P_ID", ID);

            var output = new ClientBES();

            using(var reader = GetReader())
            {
                output = this.Map<ClientBES>(reader, true);

                if(reader.NextResult())
                {
                    output.Addresses = this.GetList<AddressBES>(reader).ToList();
                }
            }

            return output;
        }

        /// Save a new client
        /// </summary>
        /// <param name="input">ClientBES</param>
        /// <returns>identification</returns>
        public int Save(ClientBES input)
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
        /// Update an existing client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public void Update(ClientBES input)
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
        /// Delete the client
        /// </summary>
        /// <param name="input">ClientBES</param>
        public void Delete(ClientBES input)
        {
            this.Run("SP_USER_D");

            this.In("P_ID", input.ID);

            this.Execute();
        }
        
        /// <summary>
        /// Get a datatable based on client
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
