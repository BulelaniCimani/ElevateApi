using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elevate.Api.Infrastructure.Integrations.Models
{
    public class HttpClientBase
    {
        protected readonly HttpClient httpClient;
        public HttpClientBase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetResponse<T>(HttpResponseMessage httpResponse) where T : class
        {
            var contentStream = await httpResponse.Content.ReadAsStreamAsync();

            try
            {
                return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
            }
            catch (JsonException)
            {
                throw;
            }
        }
    }

    
}
