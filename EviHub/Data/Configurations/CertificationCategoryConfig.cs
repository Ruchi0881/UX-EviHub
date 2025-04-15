using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class CertificationCategoryConfig: IEntityTypeConfiguration<CertificationCategory>
    {
        public void Configure(EntityTypeBuilder<CertificationCategory> builder)
        {
            builder.HasKey(cc => cc.CategoryId);
            builder.Property(cc => cc.CategoryName).IsRequired().HasMaxLength(255);
        }
    }

    
    }

