using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VariableHelpers
{
    public static class StringHelper
    {
        public static string Random(int length)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public static string ToStringOrEmpty(this object value)
        {
            return string.Concat(value, "");
        }

        public static string FromCamelCase(this string propertyName, string strip = " ")
        {
            string returnValue = null;
            returnValue = propertyName.ToStringOrEmpty();

            //Strip leading "_" character
            returnValue = Regex.Replace(returnValue, "^_", "").Trim();
            //Add a space between each lower case character and upper case character
            returnValue = Regex.Replace(returnValue, "([a-z])([A-Z])", "$1" + strip + "$2").Trim();
            //Add a space between 2 upper case characters when the second one is followed by a lower space character
            returnValue = Regex.Replace(returnValue, "([A-Z])([A-Z][a-z])", "$1" + strip + "$2").Trim();

            return returnValue;
        }
    }
}
