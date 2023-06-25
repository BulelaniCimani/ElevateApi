using System.Text.Json.Serialization;

namespace Elevate.Api.Infrastructure.Integrations.Models
{
    public class AccessTokenRequest : TokenBase
    {

        [JsonPropertyName("client_user_id")]
        public string ClientUserId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "access";
    }
}
