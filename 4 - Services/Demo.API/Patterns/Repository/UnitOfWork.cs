using Microsoft.Extensions.Configuration;

using Framework.Core;
using Framework.Cryptography;
using Framework.Data;
using Framework.Data.SQL;

using Demo.BLL;
using Demo.Contracts;

namespace Demo.API
{
    /// <summary>
    /// Unit of work class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region| Fields |

        /// <summary>
        /// Represents a set of key/value application configuration properties
        /// </summary>
        protected readonly IConfiguration Configuration = null;

        /// <summary>
        /// Container for dependency injection
        /// </summary>
        internal ContainerDI container;

        private IUser usuario { get; set; } = null;
        private IClient cliente { get; set; } = null;

        #endregion

        #region| Constructor | 

        public UnitOfWork(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region| Properties | 

        public IUser Usuario
        {
            get
            {
                SetContainer();

                usuario = usuario ?? new UserBLL(this.container);

                return usuario;
            }

        }

        public IClient Cliente
        {
            get
            {
                SetContainer();

                cliente = cliente ?? new ClientBLL(this.container);

                return cliente;
            }
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Gets the database manager to execute T-SQL statements against it
        /// </summary>
        /// <returns></returns>
        protected void SetContainer(DatabaseServers dBServer = DatabaseServers.DB_DEMO)
        {
            var configurationName = this.Configuration["ENVIRONMENT"];

            var keyName           = $"{configurationName}:{dBServer.ToString()}";
            var connection        = this.Configuration[keyName];
            var commandTimeout    = this.Configuration["FRAMEWORK.COMMAND.TIMEOUT"].ToInt();
            var connectionTimeout = this.Configuration["FRAMEWORK.CONNECTION.TIMEOUT"].ToInt();
            var traceEnabled      = this.Configuration["FRAMEWORK.TRACE.ENABLED"].ToBool();
            var traceFilePath     = this.Configuration["FRAMEWORK.TRACE.PATH"];

            if (!traceEnabled)
            {
                traceFilePath = string.Empty;
            }

            connection = Cryptography.DecryptUsingTripleDES(connection);

            var databaseContext    = new SQLDatabaseContext(connection, commandTimeout, connectionTimeout);
            var databaseRepository = new SQLDatabaseRepository(false, traceFilePath);

            container = new ContainerDI(databaseContext, databaseRepository);
        }

        #endregion
    }
}
