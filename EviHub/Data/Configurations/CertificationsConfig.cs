using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class CertificationConfig : IEntityTypeConfiguration<Certification>
    {
       

        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.HasKey(c => c.CertificationId);
            builder.Property(d => d.CertificationName).IsRequired().HasMaxLength(100);
            builder.HasIndex(d => d.CertificationName).IsUnique(); // Ensure unique Certification names
        }
    }


}


