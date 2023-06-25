using System.Threading.Tasks;

namespace Elevate.Api.Domain.Repositories
{
    public interface IUserRegistrationRepo
    {
        Task Register(UserEntity userEntity);
        Task<bool> CheckUserExist(UserEntity user);
    }
}
