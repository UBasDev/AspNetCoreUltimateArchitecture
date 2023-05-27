using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.ProfileEntity;

namespace UserService.Persistence.Context.Configurations
{
    public class ProfileConfiguration:IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> modelBuilder)
        {
            modelBuilder.HasKey(profile => profile.Id);
        }
    }
}
