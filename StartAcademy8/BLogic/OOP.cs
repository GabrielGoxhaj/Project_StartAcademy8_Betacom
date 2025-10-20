using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy8.BLogic
{
    public class OOP
    {
        public abstract class Animal
        {
            private int _age;
            public int Age
            {
                get => _age;
                set
                {
                    if (value < 0 || value > 50)
                        throw new ArgumentOutOfRangeException(nameof(Age));
                    _age = value;
                }
            }
            public string Name { get; set; }
            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public abstract void AnimalSound();
            public virtual void AnimalMovement()
            {
                Console.WriteLine($"{Name}, normalmente si muove.");
            }
        }
        public interface IMovementType
        {
            void AnimalFLy();
            void AnimalLand();
        }
        public class Khane : Animal
        {
            public Khane(string name, int age) : base(name, age)
            {
            }
            public override void AnimalSound() => Console.WriteLine($"Name:  BAU, bAU, BAU");
            public override void AnimalMovement()
            {
                base.AnimalMovement();
                Console.WriteLine("Nel caso di Fuffi, corre come un matto.");
            }
        }
        public class Eagle : Animal, IMovementType
        {
            public Eagle(string name, int age) : base(name, age)
            {
            }
            public override void AnimalSound() => Console.WriteLine($"{Name}, cree, cree");
            public override void AnimalMovement()
            {
                Console.Write($"{Name}, vola ad alte quote");
            }
            public int MyMethod()
            {
                return 0;
            }

            public void AnimalFLy()
            {
                Console.WriteLine("Questo Animale Vola");
            }

            public void AnimalLand()
            {
                Console.WriteLine("Questo Animale, raramente sta a terra, o meglio sta nel nido con la famiglia");
            }
        }
        public class Gallina : Eagle
        {
            public Gallina(string name, int age) : base(name, age)
            {
                //    CommonAcademy8.Utility utility = new();
                //    utility.FirstLibMethod();
            }
            public void GallinaMethod()
            { }
        }
        public class StrangeSingleton
        {
            private static int counter = 0;
            private static StrangeSingleton strangeInstance;
            public static string FilePathName = string.Empty;
            private StrangeSingleton()
            {
                //counter++;
                //Console.WriteLine($"Valore COntatore: {counter}");
            }
            public static StrangeSingleton GetStrangeSingleton()
            {
                if (strangeInstance == null)
                {
                    strangeInstance = new StrangeSingleton();
                    // Scrivo tutto il codice che mi serve, esempio:
                    FilePathName = ConfigurationManager.AppSettings["DataFilePath"];
                }

                return strangeInstance;
            }

        }
    }
}
