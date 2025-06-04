namespace EviHub.DTOs
{
    public class CertificationDTO
    {
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
