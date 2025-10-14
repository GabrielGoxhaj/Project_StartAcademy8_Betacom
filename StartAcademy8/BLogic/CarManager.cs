using System;
using StartAcademy8.DataModels;

namespace StartAcademy8.BLogic
{
    internal class CarManager
    {
        List<Car> cars = [];
        internal CarManager() { }

        internal CarManager(Car NewCar)
        {
            Console.Clear();
            Console.WriteLine(
                $"Id: {NewCar.Enrollment} - Modello: {NewCar.Model} - Motore: {NewCar.Engine} - Potenza: {NewCar.Power}");
        }

        internal bool LoadCar(Car NewCar)
        {
            bool result = false;

            try
            {
                cars.Add(NewCar);
                result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        internal void PrintCars()
        {
            string rowSeparator = new string('-', 100);
            foreach (Car NewCar in cars)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Id: {NewCar.Enrollment} - Modello: {NewCar.Model} - Motore: {NewCar.Engine} - Potenza: {NewCar.Power}");
                foreach (CarOptionals optionals in NewCar.Optionals)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {optionals.Name} - Descrizione: {optionals.Description} - Quantità: {optionals.Quantity}");
                }
            }
        }

        internal bool DeleteCar(Car car) => cars.Remove(car);

        internal void UpdateCar(Car updatedCar)
        {
            // TO DO
        }

        internal void FindCar(string enrollment)
        {
            string rowSeparator = new string('-', 100);
            Car? car = cars.Find(c => c.Enrollment == enrollment);
            List<Car> car2 = cars.FindAll(c => c.Model == "BMW" && c.Power >= 2000);
            
            if (car != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(rowSeparator);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Id: {car.Enrollment} - Modello: {car.Model} - Motore: {car.Engine} - Potenza: {car.Power}");
                foreach (CarOptionals optionals in car.Optionals)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {optionals.Name} - Descrizione: {optionals.Description} - Quantità: {optionals.Quantity}");
                }
            }
            else { Console.Write($"L'auto con matricola: {enrollment} non è presente"); }
        }
    }
}