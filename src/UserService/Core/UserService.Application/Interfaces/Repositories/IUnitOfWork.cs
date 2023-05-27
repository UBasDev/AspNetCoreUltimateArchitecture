using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        IRoleRepository RoleRepository { get; }
        IScreenRepository ScreenRepository { get; }
        IUserRepository UserRepository { get; }
        
    }
}
