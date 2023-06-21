using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Elevate.Api.Application.ValueObjects;
using Elevate.Api.Infrastructure.Integrations.Models;
using Microsoft.Extensions.Options;

namespace Elevate.Api.Infrastructure.Integrations
{
    public class HumanApi : HttpClientBase, IHumanApi
    {
        private readonly HumanApiSettings humanApiSettings;
        private const string connectEndpoint = "v1/connect/token";

        public HumanApi(HttpClient httpClient, IOptions<HumanApiSettings> options): base(httpClient)
        {
            humanApiSettings = options.Value;
        }

        public async Task<UserResponse> RegisterOnHumanApi(UserRegistration userRegistration)
        {
            userRegistration.ClientId = humanApiSettings.ClientId;
            userRegistration.ClientSecret = humanApiSettings.ClientSecret;

            var data = JsonContent.Create(userRegistration);

            var httpResponse = await httpClient.PostAsync(connectEndpoint, data);

            httpResponse.EnsureSuccessStatusCode();

            if (IsHttpResponseValid(httpResponse))
            { 
                return await GetResponse<UserResponse>(httpResponse);
            }
            return default;
        }


        public async Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest accessToken)
        {
            accessToken.ClientId = humanApiSettings.ClientId;
            accessToken.ClientSecret = humanApiSettings.ClientSecret;

            var data = JsonContent.Create(accessToken);

            var httpResponse = await httpClient.PostAsync(connectEndpoint, data);

            httpResponse.EnsureSuccessStatusCode();

            if (IsHttpResponseValid(httpResponse))
            {
                return await GetResponse<AccessTokenResponse>(httpResponse);
            }
            return default;
        }


        private static bool IsHttpResponseValid(HttpResponseMessage httpResponse)
        {
            return httpResponse.Content is object
                    && httpResponse.Content.Headers.ContentType.MediaType == "application/json";
        }
    }
}
