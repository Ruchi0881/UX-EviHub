using EviHub.EviHub.Core.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class ProjectProgressConfig : IEntityTypeConfiguration<ProjectProgress>
    {
        public void Configure(EntityTypeBuilder<ProjectProgress> builder)
        {
            builder.HasKey(pp => pp.EmpProjectProgressId);
            builder.Property(cp => cp.StartDate)
                .IsRequired();

            builder.Property(cp => cp.EndDate)
                .IsRequired(false);//Nullable



            //builder.HasOne<EmployeeProject>()
            //    .WithMany()
            //    .HasForeignKey(pp => pp.ProjectId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne<Employee>()
            //    .WithMany()
            //    .HasForeignKey(pp => pp.EmpId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
    }

