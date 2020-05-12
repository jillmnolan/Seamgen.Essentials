using System;
using System.Net;

namespace Seamgen.Essentials
{
    /// <summary>
    /// Get the current proxy configuration
    /// </summary>
    public interface IProxyService
    {
        /// <summary>
        /// Default proxy
        /// </summary>
        IWebProxy Proxy { get; }
    }
}
