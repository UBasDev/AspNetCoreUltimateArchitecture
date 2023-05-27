using Microsoft.EntityFrameworkCore;
using NoteService.Application.Models;
using NoteService.Domain.Entities.Common;
using NoteService.Domain.Entities.Note;
using NoteService.Persistence.Context.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        private readonly AppSettings _appSettings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AppSettings appSettings):base(options)
        {
            _appSettings= appSettings;
        }
        public DbSet<Note> Notes => Set<Note>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql(_appSettings.DatabaseConnectionString, m => { m.EnableRetryOnFailure(); });
            }
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            addedEntities.ForEach(e =>
            {
                if (e.Metadata.FindProperty("CreatedDate") != null)
                    e.Property("CreatedDate").CurrentValue = DateTimeOffset.UtcNow;
            });
            var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            editedEntities.ForEach(e =>
            {
                if (e.Metadata.FindProperty("UpdatedDate") != null)
                    e.Property("UpdatedDate").CurrentValue = DateTimeOffset.UtcNow;
            });

            var deletedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();
            deletedEntities.ForEach(e =>
            {
                if (e.Entity is not ISoftDelete) return;
                e.State = EntityState.Modified;
                e.Property("DeletedDate").CurrentValue = DateTimeOffset.UtcNow;
                e.Property("IsDeleted").CurrentValue = true;
                e.Property("IsActive").CurrentValue = false;
            });

        }
    }
}
