using NoteService.Application.Interfaces.Repositories;
using NoteService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private INoteRepository _noteRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
        }
        public INoteRepository NoteRepository
        {
            get
            {
                _noteRepository ??= new NoteRepository(_context);
                return _noteRepository;
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
