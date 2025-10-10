using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy8.BLogic
{
    internal static class FirstDay
    {

        private static int x;
        internal static void Welcome()
        {
            Console.WriteLine("Hello, Betacom!");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Cambio colore");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Scrivi testo: ");

            string inputConsole = "";

            inputConsole = Console.ReadLine();
            Console.WriteLine(inputConsole.ToUpper());

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Numero: " + i);
                Console.WriteLine($"Numero: {i}");
            }

            string x = "";
            string y = null;

            bool status = true;
            while (true)
            {
                Console.WriteLine("Sono in un ciclo while");
                if (Console.ReadLine().ToUpper() == "F")
                { break; }
                else
                { Console.WriteLine("Ciclo in continuazione"); }
            }

            do
            {
                Console.WriteLine(status);
                status = false;
            } while (status); // continua ad andare avanti finchè status = true, esce subito

            string sName = "Claudio";
            foreach (char c in sName)
            {
                Console.Write(c.ToString().ToUpper() + ',');
            }
        }

        internal static void RunMultiply()
        {
            string rowSeparator = new string('-', 100);
            int n1 = 0;
            int n2 = 0;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(rowSeparator);
                Console.WriteLine("Semplice moltiplicatore di 2 numeri");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Inserire Numero 1: ");
                if (!int.TryParse(Console.ReadLine(), out n1))
                {
                    Console.Write("Numero non valido! Premi un tasto per continuare ");
                    Console.ReadLine();
                }
                Console.Write("Inserire Numero 2: ");
                if (!int.TryParse(Console.ReadLine(), out n2))
                {
                    Console.Write("Numero non valido! Premi un tasto per continuare ");
                    Console.ReadLine();
                }

                Console.WriteLine("Il risultato della moltiplicazione tra i numeri " + n1 + " e " + n2 + " è pari a " + ComputeMultiply(n1, n2));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(rowSeparator);
                Console.WriteLine("Vuoi continuare? (S/N) ? ");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine().Equals("N", StringComparison.CurrentCultureIgnoreCase))
                { break; }
            }
        }

        private static int ComputeMultiply(int num1, int num2)
        {
            return (num1 * num2);
        }

    }
}
