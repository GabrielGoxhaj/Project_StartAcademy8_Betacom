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
        public const string Title = "TITOLO";
        public void TestTuples()
        {
            Tuple<string, int, string, DateTime> tupleOne =
                new("Claudio", 51, "Mozzate", DateTime.Now);

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleOne.Item1);

            Console.WriteLine(tupleOne.Item2);
            Console.WriteLine(tupleOne.Item3);
            Console.WriteLine(tupleOne.Item4);

            Tuple<string, Car, int, bool, string, double> tupleCar =
                new("Auto di Claudio",
                new Car { Enrollment = "2oiui", Model = "Maserati" }, 27, true, "Mozzate", 12.5);

            List<Tuple<string, string, string>> tuples = [];
            tuples.Add(new Tuple<string, string, string>("s1", "s2", "s3"));
        }

    }
}
