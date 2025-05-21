using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class CertificationProgressConfig:IEntityTypeConfiguration<CertificationProgress>
{
    public void Configure(EntityTypeBuilder<CertificationProgress> builder)
    {
        builder.HasKey(cp => cp.CertificationProgressId);

        builder.Property(cp => cp.StartDate)
            .IsRequired();

        builder.Property(cp => cp.EndDate)
            .IsRequired(false);//Nullable
        

        //builder.HasOne<Certification>()
        //    .WithMany()
        //    .HasForeignKey(cp => cp.CertificationId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne<Employee>()
        //    .WithMany()
        //    .HasForeignKey(cp => cp.EmpId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}


}

