using System;
using StartAccademy8.DataModels;

namespace StartAccademy8.BLogic
{
    internal class CarManager
    {
        List<Car> cars = [];
        internal CarManager() { }

        internal CarManager(Car NewCar)
        {
            Console.Clear();
            Console.WriteLine(
                $"Id: {NewCar.Id} - Modello: {NewCar.Model} - Motore: {NewCar.Engine} - Potenza: {NewCar.Power}");
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
            foreach (Car NewCar in cars)
            {
                Console.WriteLine($"Id: {NewCar.Id} - Modello: {NewCar.Model} - Motore: {NewCar.Engine} - Potenza: {NewCar.Power}");
            }
        }

        internal bool DeleteCar(Car car) => cars.Remove(car);

        internal void UpdateCar(Car updatedCar)
        {
            // TO DO
        }
    }
}