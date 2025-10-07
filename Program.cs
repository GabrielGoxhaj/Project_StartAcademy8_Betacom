using Microsoft.VisualBasic;
using StartAccademy8.BLogic;
using StartAccademy8.DataModels;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq.Expressions;

namespace StartAccademy8
{
    public class Program
    {
        static string LineSeparator = ConfigurationManager.AppSettings["LineSeparator"];
        static void Main(string[] args)
        {
            RecordSamples DbConfig = new("SqlServerOne", "AdventureWorks", "Customers");

            DictionarySamples dictionarySamples = new();
            dictionarySamples.MyFirstDictionary();
            return;

            Car car1 = new Car
            {
                Enrollment = "A1",
                Model = "Mercedes"
            };

            Car car3 = new Car
            {
                Enrollment = "A1",
                Model = "Mercedes"
            };

            Console.WriteLine($"Car1 uguale a Car3: {car1 == car3}");
            Console.WriteLine(LineSeparator);
            Console.WriteLine($"Car1 uguale a Car3: {Object.ReferenceEquals(car1, car3)}");
            return;

            dictionarySamples.MyFirstDictionary();
            return;

            List<Car> cars = [];
            FileManager.ReadCarsJson(ref cars);
            //cars = FileManager.ReadCarsFile();


            //MenuManager.MainMenu();
            //return;

            //int CarModel = (int)MainEnumerators.CarModel.SAAB;

            int myCar = 2;

            MainEnumerators.CarModel carModel = MainEnumerators.CarModel.BMW;
            Car carEnum = new()
            {
                Enrollment = "stnmrtn69",
                Model = "Aston Martin",
                Engine = "Gasoline",
                ModelEnum = MainEnumerators.CarModel.None,
                Power = 3000,
            };

            CarOptionals carOptionals1 = new();
            carOptionals1.Id = 1;
            carOptionals1.CarEnrollment = "stnmrtn69";
            carOptionals1.Description = "Running";
            carOptionals1.Quantity = 3;

            List<Car> fileTxtCars = [];
            fileTxtCars.Add(carEnum);
            fileTxtCars.Add(carEnum);
            fileTxtCars.Add(carEnum);

            FileManager.WriteCarsFile(fileTxtCars);
            FileManager.WriteCarsJson(fileTxtCars);
            FileManager.WriteCarsXml(fileTxtCars);
            return;

            Console.WriteLine(carEnum.ToString());
            Console.WriteLine(
                $"Model ENUM: {carEnum.ModelEnum}\n" +
                $"Valore Enum Model: {(int)carEnum.ModelEnum}\n" +
                $"La mia auto: {(MainEnumerators.CarModel)myCar}"
                );

            return;
            
            int[] myNumbers = new int[10];
            List<int> list = new List<int>();

            myNumbers[0] = 1;
            list.Add(1);

            int[] myNumbers2 = { 1, 2, 3, 4 };
            List<int> list2 = [1, 2, 3, 4];
            List<DateTime> list3 = new List<DateTime>();
            DateTime Today = DateTime.Now;
            DateTime Yesterday = new DateTime(2025, 09, 30);

            //Console.WriteLine($"Tra ieri e ora sono passati: {(int)(Today - Yesterday).TotalMinutes}");
            //return;

            //CarManager carManager = new(); // Costruttore vuoto
            //CarManager carManager2 = new(car);

            Car car = new();
            {
                car.Enrollment = "1";
                car.Model = "BMW";
                car.Engine = "Gasoline";
                car.Power = 205;
            }

            CarOptionals carOptionals = new()
            {
                Id = 1,
                CarEnrollment = "1",
                Description = "Cane",
                Name = "Rivestimento Interni",
                Quantity = 1,
            };

            car.Optionals.Add(carOptionals);

            CarManager carManager3 = new(new Car { Enrollment = "2", Model = "Kia", Engine = "Full Hybrid", Power = 141 });
            Car car2 = new();
            {
                car2.Enrollment = "3";
                car2.Model = "Porsche";
                car2.Engine = "Gasoline";
                car2.Power = 550;
            }

            var contextValidation = new ValidationContext(car, null, null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(car, contextValidation, validationResults, true);
            if (isValid)
            {
                carManager3.LoadCar(car);
            }
            else
            {
                Console.WriteLine("ATTENZIONE: Dati errati in uno o più modelli auto");
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                return;
            }

            carManager3.LoadCar(car);
            carManager3.LoadCar(car2);
            Console.WriteLine("Cerca Auto, inserisci il numero di matricola: ");
            carManager3.FindCar(Console.ReadLine());

            //carManager3.PrintCars();

            // FirstDay.Welcome();

            //FirstDay.RunMultiply();

            //try
            //{
            //    Console.Write("Inserire Numero 1: ");
            //    n1 = Convert.ToInt16(Console.ReadLine());
            //    Console.Write("Inserire Numero 2: ");
            //    n2 = Convert.ToInt16(Console.ReadLine());
            //    Console.WriteLine(FirstDay.ComputeSquare(n1, n2));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"E' stato inserito un numero non valido. Descrizione Errore {ex.Message}");
            //    Console.WriteLine("Operazione annullata, programma chiuso");
            //    return;
            //}
            //finally
            //{
            //    Console.WriteLine("Eseguito finally");
            //}
        }
    }
}