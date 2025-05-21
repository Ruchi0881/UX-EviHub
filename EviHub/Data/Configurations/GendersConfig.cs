using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EviHub.EviHub.Core.Entities;

namespace EviHub.Data.Configurations
{
    public class GendersConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.GenderId);
            builder.Property(g => g.GenderName).IsRequired().HasMaxLength(50);
            //    builder.HasMany<Employee>()
            //        .WithMany(g => g.Gender)
            //        .HasForeignKey(e => e.EmpId)
            //        .OnDelete(DeleteBehavior.Restrict);
            //}
        }



    }
}

