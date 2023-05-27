using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Interfaces.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();
        Task SaveAsync();
        INoteRepository NoteRepository { get; }
    }
}
