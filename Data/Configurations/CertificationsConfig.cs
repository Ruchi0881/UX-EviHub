using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class CertificationsConfig: IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.HasKey(c => c.CertificationId);
            builder.Property(c => c.CertificationName).IsRequired().HasMaxLength(255);
            

            builder.HasOne<CertificationCategory>()
                .WithMany(cat=>cat.Certifications)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

   
    }

