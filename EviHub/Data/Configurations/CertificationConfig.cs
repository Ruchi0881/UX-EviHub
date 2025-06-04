using EviHub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EviHub.Data.Configurations
{
    public class CertificationConfig : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.HasKey(c => c.CertificationId);
            builder.Property(c => c.CertificationName).IsRequired().HasMaxLength(255);

            //builder.HasOne(c => c.CertificationCategory)
            //    .WithMany(cat => cat.Certifications)
            //    .HasForeignKey(c => c.CategoryId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
        
    }
}
