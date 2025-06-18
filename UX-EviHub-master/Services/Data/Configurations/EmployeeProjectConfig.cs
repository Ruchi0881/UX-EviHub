using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.Entities;

namespace EviHub.Data.Configurations
{
    public class EmployeeProjectConfig : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
           // builder.HasKey(ep => ep.EmpProjectId);

           // builder
           //.HasOne(ep => ep.Employee) // Each EmployeeProject is linked to one Employee
           //.WithMany(e => e.EmployeeProjects) // An Employee can have many EmployeeProjects
           //.HasForeignKey(ep => ep.EmpId) // Foreign key on EmployeeId
           //.OnDelete(DeleteBehavior.Cascade); // Cascade delete if the Employee is deleted

           // builder
           //     .HasOne(ep => ep.Project) // Each EmployeeProject is linked to one Project
           //     .WithMany(p => p.EmployeeProject) // A Project can have many EmployeeProjects
           //     .HasForeignKey(ep => ep.ProjectId) // Foreign key on ProjectId
           //     .OnDelete(DeleteBehavior.NoAction); // Cascade delete if the Project is deleted

        }
    }

    
    }

