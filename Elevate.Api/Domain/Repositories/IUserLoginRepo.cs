using System.Threading.Tasks;

namespace Elevate.Api.Domain.Repositories
{
    public interface IUserLoginRepo
    {
        Task<bool> Login(UserEntity userEntity);
    }
}
