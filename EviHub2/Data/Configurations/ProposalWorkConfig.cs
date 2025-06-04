using EviHub2.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub2.Data.Configurations
{
    public class ProposalWorkConfig : IEntityTypeConfiguration<ProposalWork>
    {
        public void Configure(EntityTypeBuilder<ProposalWork> builder)
        {

            builder.HasKey(pw => pw.ProposalWorkId);
            builder.Property(p => p.IsActive).HasDefaultValue(false);
            //builder.HasOne(pw => pw.Employee)
            //    .WithMany(e => e.ProposalWorks)
            //    .HasForeignKey(pw => pw.EmpId);

            //builder.HasOne(pw => pw.Proposal)
            //    .WithMany(p => p.ProposalWorks)
            //    .HasForeignKey(pw => pw.ProposalId);
        }
    }
}
