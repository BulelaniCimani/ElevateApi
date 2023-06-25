using Elevate.Api.Application.ValueObjects;
using MediatR;

namespace Elevate.Api.Application.Queries.Messages
{
    public sealed class LoginQueryRequest :IRequest<AccessResponse>
    {
        public LoginQueryRequest( string username, string password)
        {
            Username = username;
            Password = password;

        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
