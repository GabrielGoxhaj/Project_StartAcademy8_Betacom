using StartAccademy8.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.BLogic
{
    internal class DictionarySamples
    {
        public void MyFirstDictionary()
        {
            Dictionary<string, int> valuePairs = [];
            valuePairs.Add("Giada", 30);
            valuePairs.Add("Claudio", 51);

            if (valuePairs.Count > 0)
            {
                if (valuePairs.ContainsKey("Claudio"))
                {
                    Console.WriteLine("Claudio è presente in Aula");
                }
            }

            foreach (KeyValuePair<string, int> pair in valuePairs)
            {
                Console.WriteLine($"Nome: {pair.Key} - Età: {pair.Value}");
            }

            valuePairs.Add("Giada2", 33);
            SortedDictionary<string, int> valuePairsSorted = [];
            valuePairsSorted.Add("Giada", 33);
            valuePairsSorted.Add("Claudio", 51);
            valuePairsSorted.Add("Veronica", 26);
            valuePairsSorted.Add("Mauro", 35);

            foreach (KeyValuePair<string, int> pair in valuePairsSorted)
                Console.WriteLine($"Nome: {pair.Key} - Etò: {pair.Value}");

            valuePairsSorted.Remove("Giada");

            Dictionary<int, Car> valuePairs1 = [];

            valuePairs1.Add(27, new Car { Enrollment = "khsah", Model = "Mercedes-Benz" });
        }
    };
}
