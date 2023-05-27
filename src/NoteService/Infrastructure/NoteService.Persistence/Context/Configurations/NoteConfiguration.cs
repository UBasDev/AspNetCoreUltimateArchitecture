using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteService.Domain.Entities.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Context.Configurations
{
    public class NoteConfiguration:IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);

        }        
    }
}
