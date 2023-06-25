using MediatR;

namespace Elevate.Api.Application.Queries.Messages
{
    public sealed class GetTokenQueryRequest :IRequest<string>
    {
        public GetTokenQueryRequest(string humanId)
        {
            HumanId = humanId;

        }
        public string HumanId { get; set; }
    }
}
