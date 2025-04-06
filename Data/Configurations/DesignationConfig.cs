using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class DesignationConfig : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(d => d.DesignationId);
            builder.Property(d => d.DesignationName).IsRequired().HasMaxLength(100);
            builder.HasIndex(d => d.DesignationName).IsUnique(); // Ensure unique Designation names
        }
    }

    
    }

