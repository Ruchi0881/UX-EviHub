namespace EviHub.DTOs
{
    public class CertificationprogressDTO
    {
        public int CertificationProgressId { get; set; }
        public int CertificationId { get; set; }//FK
        public int EmpId { get; set; }//FK
        //public int CategoryId { get; set; }//FK
        public string CertificationName { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
    public class CreateCertificationprogressDTO
    {
        
        public int CertificationId { get; set; }//FK
        public int EmpId { get; set; }//FK
  
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
    public class UpdateCertificationprogressDTO
    {
        
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }

    }
