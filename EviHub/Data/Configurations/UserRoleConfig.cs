using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EviHub.EviHub.Core.Entities;

namespace EviHub.Data.Configurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(r => r.UserRoleId);
            builder.Property(r => r.RoleName).IsRequired().HasMaxLength(100);
            //builder.HasMany(u=>u.Employees).WithMany(x=>x.)
        }
    }

    
    }

