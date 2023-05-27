using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.ProfileEntity;
using UserService.Domain.Entities.UserEntity;

namespace UserService.Persistence.Context.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(user => user.Id);
            modelBuilder.HasOne(user => user.Profile).WithOne(profile => profile.User).HasForeignKey<Profile>(profile => profile.UserId);
            modelBuilder.HasIndex(role => role.Email).IsUnique();
            modelBuilder.HasIndex(role => role.Phone).IsUnique();
        }
    }
}
