using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities.UserEntity;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
