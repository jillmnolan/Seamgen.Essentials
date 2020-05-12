using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CoreFoundation;

namespace Seamgen.Essentials.iOS
{
    public class ProxyService : IProxyService
    {
        public IWebProxy Proxy => CFNetwork.GetDefaultProxy() ?? WebRequest.GetSystemWebProxy();
    }
}
