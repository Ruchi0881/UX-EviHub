namespace EviHub.DTOs
{
    public class CertificationprogressDTO
    {
        public int CertificationProgressId { get; set; }
        public int CertificationId { get; set; }//FK
        public int EmpId { get; set; }//FK
        //public DateTime StartDate { get; set; }
        public DateTime? completionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
    public class CreateCertificationprogressDTO
    {
        
        public int CertificationId { get; set; }//FK
        public int EmpId { get; set; }//FK
        //public DateTime StartDate { get; set; }
        public DateTime? completionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
    public class UpdateCertificationprogressDTO
    {
        //public DateTime StartDate { get; set; }
        public DateTime? completionDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }

    }
