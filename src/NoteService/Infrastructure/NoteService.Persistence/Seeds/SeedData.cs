using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteService.Domain.Entities.Note;
using NoteService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Seeds
{
    public static class SeedData
    {
        public static async Task InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context == null) return;
            await context?.Database.MigrateAsync();

            /*
            if (!context.Notes.Any())
            {
                var newNotes = new List<Note>()
                {
                    //Some seed Notes here
                };
                await context.Notes.AddRangeAsync(newNotes);
            }
            */

            await context.SaveChangesAsync();
        }
    }
}
