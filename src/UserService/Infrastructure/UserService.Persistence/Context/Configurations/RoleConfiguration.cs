using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.RoleEntity;

namespace UserService.Persistence.Context.Configurations
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
          public void Configure(EntityTypeBuilder<Role> modelBuilder)
        {
            modelBuilder.HasKey(role => role.Id);
            modelBuilder.HasMany(role => role.Screens).WithMany(screen => screen.Roles);
            modelBuilder.HasMany(role => role.Users).WithOne(user => user.Role);
            modelBuilder.HasIndex(role => role.Name).IsUnique();
            modelBuilder.HasIndex(role => role.Code).IsUnique();
            modelBuilder.HasIndex(role => role.Value).IsUnique();
        }
    }
}
