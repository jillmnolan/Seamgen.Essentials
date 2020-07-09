using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CoreFoundation;

namespace Seamgen.Essentials.iOS
{
    /// <summary>
    /// Get the currently registered proxy information
    /// </summary>
    public class ProxyService : IProxyService
    {
        /// <summary>
        /// Proxy
        /// </summary>
        public IWebProxy Proxy => CFNetwork.GetDefaultProxy() ?? WebRequest.GetSystemWebProxy();
    }
}
