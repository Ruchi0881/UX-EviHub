namespace EviHub.Models.DTO_s
{
    public class EmployeeProjectDTO
    {
        public int EmpProjectId { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; } 
        public bool IsActive { get; set; }
        public int AssignedBy { get; set; }
    }
}
