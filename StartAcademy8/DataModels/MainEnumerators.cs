using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy8.DataModels
{
    public class MainEnumerators
    {
        public enum CarModel
        {
            None,
            BMW,
            Porsche,
            SAAB,
            Lamborghini,
        }

        public enum EngineType
        {
            None,
            Gasoline,
            Hydrogen,
            Diesel,
            FullHybrid
        }

        public enum MenuItems
        {
            None,
            LoadCar = 1,
            FindCar,
            DeleteCar,
            ExitProgram = 9
        }
    }
}
