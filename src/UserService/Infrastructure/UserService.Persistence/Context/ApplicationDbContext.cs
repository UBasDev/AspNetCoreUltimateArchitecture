using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Models;
using UserService.Domain.Entities.Common;
using UserService.Domain.Entities.ProfileEntity;
using UserService.Domain.Entities.RoleEntity;
using UserService.Domain.Entities.ScreenEntity;
using UserService.Domain.Entities.UserEntity;
using UserService.Persistence.Context.Configurations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UserService.Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        private readonly AppSettings _appSettings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AppSettings appSettings):base(options)
        {
            _appSettings= appSettings;
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Screen> Screens => Set<Screen>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Profile> Profiles =>Set<Profile>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new ScreenConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)  //Eğer context başka bir yerde zaten configure edilmemişse geçerlidir
            {
                options.UseNpgsql(_appSettings.DatabaseConnectionString, m => { m.EnableRetryOnFailure(); }); //Postgre için connection stringdir
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
