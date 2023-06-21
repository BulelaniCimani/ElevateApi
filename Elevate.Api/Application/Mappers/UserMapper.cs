using Elevate.Api.Application.Commands.Messages;
using Elevate.Api.Application.ValueObjects;
using Elevate.Api.Domain;
using Elevate.Api.Infrastructure.Integrations.Models;


namespace Elevate.Api.Application.Mappers
{
    public static class UserMapper
    {

        public static UserEntity Map(this RegistrationCommandRequest request)
        {


            return new UserEntity
            {
                UserName = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password
            };


        }

        public static UserRegistration MapUserRegistration(this RegistrationCommandRequest request)
        {
            return new UserRegistration
            {
                ClientUserId = request.Username,
                ClientUserEmail = request.Email

            };

        }

        public static UserResponse MapUserResponse(this UserSession response)
        {
            return new UserResponse
            {
                ExpiresIn = response.ExpiresIn,
                HumanId = response.HumanId,
                SessionToken = response.SessionToken

            };

        }
    }
}
