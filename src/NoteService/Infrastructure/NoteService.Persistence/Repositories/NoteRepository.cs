using NoteService.Application.Interfaces.Repositories;
using NoteService.Domain.Entities.Note;
using NoteService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Repositories
{
    public class NoteRepository: GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
