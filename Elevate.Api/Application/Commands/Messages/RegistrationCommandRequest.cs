using System;
using Elevate.Api.Application.ValueObjects;
using MediatR;

namespace Elevate.Api.Application.Commands.Messages
{
    public class RegistrationCommandRequest :IRequest<RegistrationResponse>
    {
        public RegistrationCommandRequest(string fullname , string email , string username, string password)
        {

            FullName = fullname;
            Email = email;
            Username = username;
            Password = password;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
