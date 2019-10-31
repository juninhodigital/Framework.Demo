using System;
using System.Runtime.CompilerServices;
using FluentValidation.Results;
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
        /// Get a message string based on a FluentValidation result list
        /// </summary>
        /// <param name="validationResult">ValidationResult</param>
        /// <returns>string</returns>
        public static string GetMessage(this ValidationResult validationResult)
        {
            var output = string.Empty;

            if (validationResult.IsValid == false && validationResult.Errors.IsNotNull())
            {
                output = $"Please, take a look at the validation error list.{Environment.NewLine}";

                foreach (var item in validationResult.Errors)
                {
                    output += item.ErrorMessage + Environment.NewLine;
                }
            }

            return output;
        }


        #endregion
    }
}
