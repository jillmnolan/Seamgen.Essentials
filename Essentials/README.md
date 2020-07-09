# Usage

Examples on how to use the components contained in this package are below.

## Seamgen.Essentials.RetryHandler

The RetryHandler can be used to wrap another HttpClientHandler in a simple retry logic like so:

    public RestService(IProxyService proxyService, IApiConfiguration configuration, IEventAggregator eventAggregator)
    {
        var proxy = proxyService?.Proxy;

        var clientHandler = proxy != null ? new HttpClientHandler
        {
            Proxy = proxy
        } : new HttpClientHandler();

        DelegatingHandler httpClientHandler = new RetryHandler(clientHandler);

        _client = new HttpClient(httpClientHandler)
        {
            BaseAddress = configuration.BaseAddress,
        };
        _client.DefaultRequestHeaders.Add(configuration.AuthenticationKeyName, configuration.AuthenticationKeyValue);
        _eventAggregator = eventAggregator;
    }

## Seamgen.Essentils.ProxyService

Use the proxy service with Prism, for example:

    using System;
    using Prism;
    using Prism.Ioc;
    using Seamgen.Essentials;
    using Seamgen.Essentials.Android;

    public class AndroidPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IProxyService, ProxyService>();
        }
    }
