using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbHandler.Models;

namespace DbHandler.DataModels
{
    public class Employee
    {
        [Key]
        [Required]
        [MaxLength(4), MinLength(4)] // 4 caratteri, il primo deve essere una lettera alfabeto e poi 3 numeri
        public string Enrollment { get; set; }
        [Required]
        [MinLength(3), MaxLength(35)]
        public string FullName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Department { get; set; }

        [Range(18, 100, ErrorMessage = "Età compresa tra i 18 e 100 anni")]
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Cap { get; set; }
        public string Phone { get; set; }
        public List<WorkDay> WorkDays { get; set; } = [];
    }
}
