using StartAccademy8.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.BLogic
{
    public static class MenuManager
    {
        public static void MainMenu()
        {
            string rowSeparator = new string('-', 100);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("TITOLO");
            Console.WriteLine("Menu funzionalità");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Scegli la funzionalità: ");
            string scelta = Console.ReadLine();

            //switch (scelta.ToUpper())
            //{
            //    case "A":
            //        break;
            //    case "B":
            //        break;
            //    case "VIK":
            //        Console.WriteLine("B di Bari, trmòn");
            //        break;
            //    default:
            //        break;
            //}

            int sceltaEnum = Convert.ToInt16(scelta);
            switch ((MainEnumerators.MenuItems)sceltaEnum)
            {
                case MainEnumerators.MenuItems.LoadCar:
                    Console.WriteLine("Loading Car");
                    break;
                case MainEnumerators.MenuItems.FindCar:
                    Console.WriteLine("Finding Car");
                    break;
                case MainEnumerators.MenuItems.DeleteCar:
                    Console.WriteLine("Deleting Car");
                    break;
                case MainEnumerators.MenuItems.ExitProgram:
                    Console.WriteLine("Exiting Program");
                    break;
                default:
                    break;
            }
        }
    }
}
