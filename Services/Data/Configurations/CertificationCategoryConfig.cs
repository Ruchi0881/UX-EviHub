
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EviHub.Models.Entities;

namespace Evihub.Controllers
{
    public class CertificationCategoryConfig : IEntityTypeConfiguration<CertificationCategory>
    {
        public void Configure(EntityTypeBuilder<CertificationCategory> builder)
        {
            builder.HasKey(cc => cc.CategoryId);
            builder.Property(cc => cc.CategoryName).IsRequired().HasMaxLength(255);
            builder.HasMany(cc => cc.Certifications).WithOne(x => x.CertificationCategory)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
