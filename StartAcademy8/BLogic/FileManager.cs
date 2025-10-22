using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommonAcademy8.DataModels;

namespace StartAcademy8.BLogic
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

            File.AppendAllText(Path.Combine(ConfigurationManager.AppSettings["DataFilePath"], ConfigurationManager.AppSettings["TxtFileName"]), strCarsFile.ToString());
        }

        public static List<Car> ReadCarsFile()
        {
            List<Car> list = [];

            string fileName = "CarsListSB.txt";
            string filePath = "C:\\Temp";

            string[] carsTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            //string[] carProps = new string[];

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

        public static void WriteCarsJson(List<Car> cars)
        {
            string fileName = "CarsListSB.json";
            string filePath = "C:\\Temp";

            string saveCarsJson = string.Empty;

            saveCarsJson = JsonSerializer.Serialize(
                cars, new JsonSerializerOptions { WriteIndented = true }
                );

            File.WriteAllText(Path.Combine(filePath, fileName), saveCarsJson);
        }

        public static void ReadCarsJson(ref List<Car> cars)
        {
            string fileName = "CarsListSB.json";
            string filePath = "C:\\Temp";
            string CarsJson = File.ReadAllText(Path.Combine(filePath, fileName));
            cars = JsonSerializer.Deserialize<List<Car>>(CarsJson);
        }

        public static void WriteCarsXml(List<Car> cars)
        {
            string fileName = "CarsListSB.xml";
            string filePath = "C:\\Temp";

            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<Car>));
            StreamWriter stream = new(Path.Combine(filePath, fileName));
            xmlSerialize.Serialize(stream, cars);
            stream.Close();
        }

        public static void ReadCarsXml()
        {
            List<Car> cars = [];

            string fileName = "CarsListSB.xml";
            string filePath = "D:\\Temp";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Car>));
            using (FileStream fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Open))
            {
                cars = (List<Car>)xmlSerializer.Deserialize(fileStream);
            }
        }



    }
}
