using System.ComponentModel.DataAnnotations;

namespace EviHub.Contracts_DTO_S_
{
    public class SkillsDTO
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
    }

    public class CreateSkillsDTO
    {

        [Required(ErrorMessage ="Skill name is required.")]
        [MaxLength(255,ErrorMessage ="Skill name cant exceed 255 characters.")]
        public string? SkillName { get; set; }//dont need skillId since db will automatically generate

    }

    public class UpdateSkillDTO
    {
        public required int SkillId { get; set; }
        [Required(ErrorMessage = "Skill name is required.")]
        [MaxLength(255, ErrorMessage = "Skill name cant exceed 255 characters.")]
        public string? SkillName { get; set; }
    }

}

