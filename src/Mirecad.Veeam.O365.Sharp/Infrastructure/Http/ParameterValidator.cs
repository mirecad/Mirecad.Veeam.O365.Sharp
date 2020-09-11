using System;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public static class ParameterValidator
    {
        public static void ValidateNotNull(object value, string argumentName)
        {
            var isEmptyString = value is string s && string.IsNullOrEmpty(s);

            if (value == null || isEmptyString)
            {
                throw new ArgumentException($"No value provided for parameter {argumentName}");
            }
        }
    }
}