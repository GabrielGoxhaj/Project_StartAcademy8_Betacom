using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.DataModels
{
    public class CarOptionals
    {
        public int Id { get; set; }
        public string CarEnrollment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
