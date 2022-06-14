using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Bird : IFlyable
    {
        static uint GetRandom() //Получаем рандомное от 1 до 20 -> скорость птицы
        {
            Random rnd = new Random();
            uint value = (uint)rnd.Next(1,20); //uint - только положительные значения
            return value;
        }
        
        private uint birdSpeed = GetRandom(); //birdSpeed - Скорость нашей птичкой

        public void FlyTo(uint xCorBird) // Получаем входящие координаты
        {
            Console.WriteLine("Птичка начинает полет");
            Console.WriteLine($"Скорость птички {birdSpeed} км/ч");
            Console.WriteLine($"Дальность полета: {xCorBird} км");
            
        }

        public void GetFlyTime(uint xCorBird)
        {
            uint flyHour = xCorBird / birdSpeed; // получаем часы
            double flyMinut = ((double)(xCorBird % birdSpeed) / (double)birdSpeed) * 60; //получаем минуты
            flyMinut = Math.Round(flyMinut, 2); //округляем на те случае когда много чисел после запятой (минуты)
            Console.WriteLine("\nBird >> GetFlyTime << ");
            Console.WriteLine($"Длительность полета: {flyHour} часов и {flyMinut} минут");
        }
    }
}
