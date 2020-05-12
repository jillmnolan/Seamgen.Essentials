using System;
using System.Net;

namespace Seamgen.Essentials.Android
{
    public class ProxyService : IProxyService
    {
        public IWebProxy Proxy => GetAndroidWebProxy();

        WebProxy GetAndroidWebProxy()
        {
            string host = Java.Lang.JavaSystem.GetProperty("http.proxyHost");
            string port = Java.Lang.JavaSystem.GetProperty("http.proxyPort");

            if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(port))
            {
                WebProxy proxy = new WebProxy($"{host.TrimEnd('/')}:{port}", true);
                return proxy;
            }

            return null;
        }
    }
}
