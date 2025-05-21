using EviHub.EviHub.Core.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Data.Configurations
{
    public class EmployeeProjectConfig : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(ep => ep.EmpProjectId);

            //builder.HasOne<Employee>()
            //    .WithMany()
            //    .HasForeignKey(ep => ep.EmpId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Project>()
            //    .WithMany()
            //    .HasForeignKey(ep => ep.ProjectId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }

    
    }

