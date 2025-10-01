using Microsoft.VisualBasic;
using StartAccademy8.BLogic;
using System.Linq.Expressions;
using StartAccademy8.DataModels;
using System.ComponentModel.DataAnnotations;

namespace StartAccademy8
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new(); // Costruttore vuoto
            //CarManager carManager2 = new(car);

            Car car = new();
            {
                car.Id = 1;
                car.Model = "BMW";
                car.Engine = "Gasoline";
                car.Power = 205;
            }

            CarManager carManager3 = new(new Car { Id = 2, Model = "Kia", Engine = "Full Hybrid", Power = 141 });
            Car car2 = new();
            {
                car2.Id = 3;
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

                carManager3.LoadCar(car);
                carManager3.LoadCar(car2);
                carManager3.PrintCars();

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
}