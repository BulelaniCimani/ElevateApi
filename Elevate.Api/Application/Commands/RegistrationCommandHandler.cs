using System;
using System.Threading;
using System.Threading.Tasks;
using Elevate.Api.Application.Commands.Messages;
using Elevate.Api.Application.Helpers;
using Elevate.Api.Application.Mappers;
using Elevate.Api.Application.ValueObjects;
using Elevate.Api.Domain.Repositories;
using Elevate.Api.Infrastructure.Integrations;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Elevate.Api.Application.Commands
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommandRequest, RegistrationResponse>
    {
        private readonly IUserRegistrationRepo _userRegistrationRepo;
        private readonly IHumanApi _humanApi;
        private IMemoryCache _cache;
        private string userCacheKey = string.Empty;

        public RegistrationCommandHandler(IUserRegistrationRepo userRegistrationRepo, IHumanApi humanApi, IMemoryCache cache)
        {
            _userRegistrationRepo = userRegistrationRepo;
            _humanApi = humanApi;
            _cache = cache;
        }

        public async Task<RegistrationResponse> Handle(RegistrationCommandRequest request, CancellationToken cancellationToken)
        {

            
            var userExist = await _userRegistrationRepo.CheckUserExist(request.Map());

            if (userExist)
                throw new Exception("User with the same username or email address already exist");

            request.Password = request.Password.GetPasswordHash();
            try
            {
                await _userRegistrationRepo.Register(request.Map());
                var response = await _humanApi.RegisterOnHumanApi(request.MapUserRegistration());

                if (!_cache.TryGetValue(response.HumanId, out UserResponse userResponse))
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                       .SetAbsoluteExpiration(TimeSpan.FromSeconds(response.ExpiresIn))
                       .SetPriority(CacheItemPriority.Normal);

                    _cache.Set(response.HumanId, response, cacheEntryOptions);
                }

                return new RegistrationResponse
                {
                    HumanId = response.HumanId

                };

            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
