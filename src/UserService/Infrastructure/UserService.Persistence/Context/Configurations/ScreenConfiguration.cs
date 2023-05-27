using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.ScreenEntity;

namespace UserService.Persistence.Context.Configurations
{
    public class ScreenConfiguration:IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> modelBuilder)
        {
            modelBuilder.HasKey(screen => screen.Id);
            modelBuilder.HasMany(screen => screen.Users).WithMany(user => user.Screens);
            modelBuilder.HasIndex(screen => screen.Name).IsUnique();
            modelBuilder.HasIndex(screen => screen.Value).IsUnique();
            modelBuilder.HasIndex(screen => screen.OrderNumber).IsUnique();
        }
    }
}
