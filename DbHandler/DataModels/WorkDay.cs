using System.ComponentModel.DataAnnotations;

namespace DbHandler.Models
{
    public class WorkDay
    {
        [Key]
        public int ID { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? JobType { get; set; }
        public int TotalHours { get; set; }

        [Required]
        public string? Enrollment { get; set; }
    }


    public static class ExtraActivityInfo
    {
        public static void WeekFrequency(this WorkDay workDay)
        {
            Console.WriteLine("SONO UN ESTENSIONE DELLA CLASSE WORKDAY (NO EREDITATO");
        }

        public static string TrasformaInMaiuscolo(this string sValue)
        { return sValue.ToUpper(); }
    }

}
