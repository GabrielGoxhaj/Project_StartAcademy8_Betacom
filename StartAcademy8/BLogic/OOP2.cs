using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy8.BLogic
{
    public class OOP2
    {
        public abstract class Vehicle
        {
            private int _speedKmh;
            public int SpeedKmh
            {
                get => _speedKmh;
                set
                {
                    if (value < 0) throw new ArgumentOutOfRangeException(nameof(SpeedKmh));
                    _speedKmh = value;
                }
            }
            protected Vehicle(int speedKmh) => SpeedKmh = speedKmh;
            public abstract void Move(int km);
            public virtual void Accelerate(int delta)
            {
                SpeedKmh += delta;
                Console.WriteLine($"Velocità: {SpeedKmh} km/h");
            }
        }
        public interface IFlyable
        {
            void Fly(int km);
        }
        public class Auto : Vehicle
        {
            public Auto(int speedKmh) : base(speedKmh) { }
            public override void Move(int km) => Console.WriteLine($"L'auto si muove per {km} km a una velocità di {SpeedKmh} km/h.");
        }
        public class Bicycle : Vehicle
        {
            public Bicycle(int speedKmh) : base(speedKmh) { }
            public override void Move(int km) => Console.WriteLine($"La bicicletta si muove per {km} km a una velocità di {SpeedKmh} km/h.");
        }
        public class Airplane : Vehicle, IFlyable
        {
            public Airplane(int speedKmh) : base(speedKmh) { }
            public void Fly(int km)
            {
                Console.WriteLine($"L'aereo vola per {km} km a una velocità di {SpeedKmh} km/h.");
            }
            public override void Move(int km)
            {
                Console.WriteLine($"L'aereo si muove sul suolo in fase di decollo/atterraggio per {km} mt.");
            }
        }
    }
}
