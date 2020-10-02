using System;
using System.Security;

namespace Mirecad.Veeam.O365.Sharp
{
    public class VeeamO365ClientOptions
    {
        /// <summary>
        /// The base URL address of the client
        /// </summary>
        /// <example>
        /// https://veeamserver.com:4443
        /// </example>
        public Uri BaseAddress { get; }

        /// <summary>
        /// Username used for authentication
        /// </summary>
        /// <example>
        /// TECH\Administrator
        /// </example>
        public string Username { get; }

        /// <summary>
        /// Password of user for authentication
        /// </summary>
        public SecureString Password { get; }

        /// <summary>
        /// Timeout for http requests. Default is one minute.
        /// </summary>
        public TimeSpan HttpTimeout { get; }

        public VeeamO365ClientOptions(Uri baseAddress, string username, SecureString password, TimeSpan? httpTimeout = null)
        {
            BaseAddress = baseAddress;
            Username = username;
            Password = password;
            HttpTimeout = httpTimeout ?? TimeSpan.FromMinutes(1);
        }
    }
}