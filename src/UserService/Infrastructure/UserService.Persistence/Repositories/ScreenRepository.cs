using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Entities.ScreenEntity;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories
{
    public class ScreenRepository:GenericRepository<Screen>, IScreenRepository
    {
        public ScreenRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
