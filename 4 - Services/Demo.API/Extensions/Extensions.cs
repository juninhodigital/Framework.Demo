using System;
using System.Runtime.CompilerServices;

using Framework.Core;

namespace Demo.API
{
    /// <summary>
    /// This class contains useful extension methods
    /// </summary>
    internal static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Log a message to a file using log4net
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="message">additional message</param>
        /// <param name="memberName">Method name</param>
        public static void Log(this Exception exception, string controllerName, string message = "", [CallerMemberName] string memberName = "")
        {
            var errorMessage = $"An exception occurred @ { controllerName}.{ memberName}.";

            if (message.IsNotNull())
            {
                errorMessage += $"Details:{message}";
            }

            Logger.log.Error(errorMessage, exception);
        }

        #endregion
    }
}
