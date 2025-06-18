namespace EviHub.DTOs
{
    public class AddEmployeeSkillsDTO
    { 
        public int EmpId { get; set; }
        public List<int> SkillId { get; set; } = new();
    }
}
