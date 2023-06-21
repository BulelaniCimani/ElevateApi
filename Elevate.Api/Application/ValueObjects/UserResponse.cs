using System.Text.Json.Serialization;

namespace Elevate.Api.Application.ValueObjects
{
    public class UserResponse
    {
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("human_id")]
        public string HumanId { get; set; }
        [JsonPropertyName("session_token")]
        public string SessionToken { get; set; }
    }
}
