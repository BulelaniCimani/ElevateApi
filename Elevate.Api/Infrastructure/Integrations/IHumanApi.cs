using System.Threading.Tasks;
using Elevate.Api.Application.ValueObjects;
using Elevate.Api.Infrastructure.Integrations.Models;

namespace Elevate.Api.Infrastructure.Integrations
{
    public interface IHumanApi
    {
        Task<UserResponse> RegisterOnHumanApi(UserRegistration userRegistration);
        Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest accessToken);
    }
}
