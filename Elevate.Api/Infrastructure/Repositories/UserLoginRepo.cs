using System.Linq;
using System.Threading.Tasks;
using Elevate.Api.Domain;
using Elevate.Api.Domain.Repositories;

namespace Elevate.Api.Infrastructure.Repositories
{
    public class UserLoginRepo : IUserLoginRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserLoginRepo(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task<bool> Login(UserEntity userEntity)
        {
            var response = applicationDbContext.Users.Where(c => c.UserName == userEntity.UserName &&  c.Password == userEntity.Password);
            return Task.FromResult(response.Any());
        }
    }
}
