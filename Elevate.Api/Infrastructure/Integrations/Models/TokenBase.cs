using System.Text.Json.Serialization;

namespace Elevate.Api.Infrastructure.Integrations.Models
{
    public class TokenBase
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }
    }
}
