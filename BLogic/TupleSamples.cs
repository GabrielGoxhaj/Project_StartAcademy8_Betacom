using StartAccademy8.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.BLogic
{
    public class TupleSamples
    {
        public void TestTuples()
        {
            Tuple<string, int, string, DateTime> tupleOne =
                new Tuple<string, int, string, DateTime>("Claudio", 51, "Mozzate", DateTime.Now);

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleOne.Item1);

            Tuple<string, Car, int, bool, string, double> tuple =
                new("Auto di Claudio", 
                new Car { Enrollment = "ianfuu4", Model = "Lamborghini" }, 27, true, "Mozzate", 12.5);

            List<Tuple<string, string, string>> tuples = [];
            tuples.Add(new Tuple<string, string, string>("s1", "s2", "s3"));
        }
    }
}
