using System.Linq;
using System.Threading.Tasks;
using Elevate.Api.Domain;
using Elevate.Api.Domain.Repositories;

namespace Elevate.Api.Infrastructure.Repositories
{
    public class UserRegistrationRepo : IUserRegistrationRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
       
        public UserRegistrationRepo(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task<bool> CheckUserExist(UserEntity user)
        {
            var response = applicationDbContext.Users.Where(c => c.Email == user.Email || c.UserName == c.UserName);
            return Task.FromResult(response.Any());
        }

        public async Task Register(UserEntity userEntity)
        {
            applicationDbContext.Add(userEntity);
            applicationDbContext.SaveChanges();

        }
    }
}
