using System;
using System.Threading;
using System.Threading.Tasks;
using Elevate.Api.Application.Helpers;
using Elevate.Api.Application.Queries.Messages;
using Elevate.Api.Application.ValueObjects;
using Elevate.Api.Domain.Repositories;
using Elevate.Api.Infrastructure.Integrations;
using Elevate.Api.Infrastructure.Integrations.Models;
using MediatR;

namespace Elevate.Api.Application.Queries
{
    public class LoginQueryHandler :IRequestHandler<LoginQueryRequest, AccessResponse>
    {
        private readonly IUserLoginRepo userLoginRepo;
        private readonly IHumanApi humanApi;
        public LoginQueryHandler(IUserLoginRepo userLoginRepo , IHumanApi humanApi)
        {
            this.userLoginRepo = userLoginRepo;
            this.humanApi = humanApi;
        }

        public async Task<AccessResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            request.Password = request.Password.GetPasswordHash();
            try
            {
                var succesful = await userLoginRepo.Login(new Domain.UserEntity { UserName = request.Username, Password = request.Password });
                if (!succesful)
                    return new AccessResponse();

                 var response = await humanApi.GetAccessToken(new AccessTokenRequest { ClientUserId = request.Username });
                return new AccessResponse { IsAuthorezed = succesful, Token = response.AccessToken };

            }catch(Exception)
            {
                throw;
            }

        }
    }
}
