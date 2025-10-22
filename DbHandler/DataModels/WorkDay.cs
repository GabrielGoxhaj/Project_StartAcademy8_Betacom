using System.ComponentModel.DataAnnotations;

namespace DbHandler.DataModels
{
    public  class WorkDay
    {
        [Key]
        public int ID { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? JobType { get; set; }
        public int TotalHours { get; set; }

        [Required]
        public string? Enrollment { get; set; }
    }

    public class ActivityDetail: WorkDay
    { 
    
       
    }
}
