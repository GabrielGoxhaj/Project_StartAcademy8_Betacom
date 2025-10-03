using StartAccademy8.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.BLogic
{
    public static class FileManager
    {
        public static void WriteCarsFile(List<Car> cars)
        {
            string outCar = string.Empty;
            string fileName = "CarsListSB.txt"; // gli assegno direttamente io l'estensione del file
            string filePath = "C:\\Temp";
            StringBuilder strCarsFile = new();

            //Versione 1
            //foreach (Car car in cars)
            //{
            //    outCar += $"{car.Enrollment};{car.Model};{car.Engine};{car.Power} \n";
            //    File.AppendAllText(Path.Combine(filePath, fileName), outCar);
            //    outCar = string.Empty;
            //}

            //Versione 2
            foreach (Car car in cars)
                strCarsFile.AppendLine($"{car.Enrollment};{car.Model};{car.Engine};{car.Power}");

            File.WriteAllText(Path.Combine(filePath, fileName), strCarsFile.ToString());
        }

        public static List<Car> ReadCarsFile()
        {
            List<Car> list = [];

            string fileName2 = "CarsListSB.txt";
            string filePath = "C:\\Temp";

            string[] carsTxt = File.ReadAllLines(Path.Combine(filePath, fileName2));

            foreach (string car in carsTxt)
            {
                list.Add(
                    new Car
                    {
                        Enrollment = car.Split(';')[0],
                        Model = car.Split(';')[1],
                        Engine = car.Split(';')[2],
                        Power = Convert.ToInt16(car.Split(";")[3]),
                    });
            }

            return list;
        }
    }
}
