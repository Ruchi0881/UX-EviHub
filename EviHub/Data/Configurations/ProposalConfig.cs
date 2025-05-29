using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class ProposalConfig : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.HasKey(p => p.ProposalId);
            builder.Property(p => p.ProposalName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.ProposalDescription).HasMaxLength(1000);
            builder.Property(p => p.ProposalDate).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true).IsRequired();

           
        }
    }

    
    }

