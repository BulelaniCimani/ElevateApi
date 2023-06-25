namespace Elevate.Api.Infrastructure.Integrations.Models
{
    public class UserSession
    {
        public int ExpiresIn { get; set; }
        public string HumanId { get; set; }
        public string SessionToken { get; set; }
    }
}
