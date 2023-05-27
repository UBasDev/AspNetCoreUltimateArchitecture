using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Repositories;
using UserService.Persistence.Context;

namespace UserService.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRoleRepository _roleRepository;
        private IScreenRepository _screenRepository;
        private IUserRepository _userRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
        }

        public IRoleRepository RoleRepository { get {
                _roleRepository ??= new RoleRepository(_context);
                return _roleRepository;
            } }

        public IScreenRepository ScreenRepository
        {
            get
            {
                _screenRepository ??= new ScreenRepository(_context);
                return _screenRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository??= new UserRepository(_context);
                return _userRepository;
            }
        }

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
