namespace EviHub2.DTOs
{
    public class CertificationCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName {  get; set; }
    }
    public class CreateCertificationCategoryDTO
    {
        public string CategoryName { get; set; }
    }
    public class UpdateCertificationCategoryDTO
    {
        public string CategoryName { get; set; }
    }
}
