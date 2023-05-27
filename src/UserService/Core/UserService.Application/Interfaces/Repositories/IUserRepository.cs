using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.UserEntity;

namespace UserService.Application.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
    }
}
