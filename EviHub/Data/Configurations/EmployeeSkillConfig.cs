using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class EmployeeSkillConfig:IEntityTypeConfiguration<EmployeeSkill>
{
    public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
    {
        builder.HasKey(es => es.EmployeeSkillId);

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(es => es.EmpId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Skills>()
            .WithMany()
            .HasForeignKey(es => es.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


}

