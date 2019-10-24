using System;
using System.IO;
using System.Reflection;
using System.Xml;

using log4net;

namespace Demo.API
{
    /// <summary>
    /// Log4Net class
    /// </summary>
    public static class Logger
    {
        #region| Fields |

        private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        internal static readonly ILog log = GetLogger(typeof(Logger));

        #endregion

        #region| Methods |

        private static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        internal static void SetLog4NetConfiguration()
        {
            var log4netConfig = new XmlDocument();

            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        } 

        #endregion
    }
}
