using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities.RoleEntity;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories
{
    public class RoleRepository: GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
