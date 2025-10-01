using System;
using System.ComponentModel.DataAnnotations;

namespace StartAccademy8.DataModels
{
    public class Car
    {
        [Key]
        [Required]
        public string Enrollment { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public string Engine { get; set; }

        [Range(500, 9000, ErrorMessage = "La cilindrata deve essere compresa tra 500 e 9000 cc")]
        public int Power { get; set; }
        public MainEnumerators.CarModel ModelEnum { get; set; }
        public List<CarOptionals> Optionals { get; set; } = [];
    }
}