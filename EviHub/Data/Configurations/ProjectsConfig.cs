using EviHub.EviHub.Core.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Data.Configurations
{
    public class ProjectsConfig : IEntityTypeConfiguration <Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.HasKey(pp => pp.ProjectId);

            builder.Property(p => p.ProjectName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(p => p.ProjectName)
                   .IsUnique();

            builder.Property(p => p.ProjectDescription)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                   .IsRequired();

            
        }
    }

    
    }

