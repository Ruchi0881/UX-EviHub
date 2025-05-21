using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class ProposalWorkConfig: IEntityTypeConfiguration<ProposalWork>
    {
        public void Configure(EntityTypeBuilder<ProposalWork> builder)
        {
            builder.HasKey(pw => pw.ProposalWorkId);
            builder.Property(p => p.IsActive).HasDefaultValue(true);

            //builder.HasOne<Proposal>()
            //    .WithMany()
            //    .HasForeignKey(pw => pw.ProposalId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Employee>()
            //    .WithMany()
            //    .HasForeignKey(pw => pw.EmpId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }

    
    }

