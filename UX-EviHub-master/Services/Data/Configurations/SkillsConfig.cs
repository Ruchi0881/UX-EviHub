using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class SkillsConfig : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasKey(s => s.SkillId);
            builder.Property(s => s.SkillName).IsRequired().HasMaxLength(255);
            builder.HasIndex(d => d.SkillName).IsUnique(); // Ensure unique Skill names
        }
    }

    

    }

