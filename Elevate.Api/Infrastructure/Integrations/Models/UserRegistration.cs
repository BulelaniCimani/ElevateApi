using System;
using System.Text.Json.Serialization;

namespace Elevate.Api.Infrastructure.Integrations.Models
{
    public class UserRegistration : TokenBase
    {

        [JsonPropertyName("client_user_id")]
        public string ClientUserId { get; set; }

        [JsonPropertyName("client_user_email")]
        public string ClientUserEmail { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "session";

    }
}
