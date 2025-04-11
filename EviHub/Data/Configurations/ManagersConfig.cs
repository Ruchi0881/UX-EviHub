using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class ManagersConfig : IEntityTypeConfiguration<Managers>
    {
        public void Configure(EntityTypeBuilder<Managers> builder)
        {
            builder.HasKey(m => m.ManagerId);

            builder.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(m => m.EmpId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
    }
