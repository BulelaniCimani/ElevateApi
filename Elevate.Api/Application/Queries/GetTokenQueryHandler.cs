using System.Threading;
using System.Threading.Tasks;
using Elevate.Api.Application.Queries.Messages;
using Elevate.Api.Application.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Elevate.Api.Application.Queries
{
    public class GetTokenmQueryHandler : IRequestHandler<GetTokenQueryRequest, string>
    {
        private readonly IMemoryCache memoryCache;
        public GetTokenmQueryHandler(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public Task<string> Handle(GetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            if (memoryCache.TryGetValue(request.HumanId, out UserResponse userResponse))
            {
                return Task.FromResult(userResponse.SessionToken);
            }
            return default;
        }
    }
}
