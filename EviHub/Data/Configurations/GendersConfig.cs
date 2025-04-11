using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class GendersConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.GenderId);
            builder.Property(g => g.GenderName).IsRequired().HasMaxLength(50);
        }
    }

    
    }

