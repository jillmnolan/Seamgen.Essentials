using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Seamgen.Essentials
{
    /// <summary>
    /// See: https://stackoverflow.com/questions/19260060/retrying-httpclient-unsuccessful-requests
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {
        // Strongly consider limiting the number of retries - "retry forever" is
        // probably not the most user friendly way you could respond to "the
        // network cable got pulled out."
        private const int MaxRetries = 3;

        /// <summary>
        /// The inner handler can be any standard <c>HttpMessageHandler</c>
        /// </summary>
        /// <param name="innerHandler"></param>
        public RetryHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        { }

        /// <summary>
        /// Execute send asynchronous
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < MaxRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }

            return response;
        }
    }
}
