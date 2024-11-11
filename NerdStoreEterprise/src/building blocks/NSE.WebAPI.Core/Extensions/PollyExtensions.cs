using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebAPI.Core.Extensions
{
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retry = HttpPolicyExtensions
                   .HandleTransientHttpError()
                   .WaitAndRetryAsync(new[]
                   {
                                       TimeSpan.FromSeconds(1), // Após o primeiro erro, esperar 1 segundo
                                       TimeSpan.FromSeconds(5), // Após. esperar 5 segundos ...
                                       TimeSpan.FromSeconds(10)
                   });

            return retry;
        }
    }
}
