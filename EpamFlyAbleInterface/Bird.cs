using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Bird : IFlyable
    {
        private uint birdSpeed = GetRandom(); //birdSpeed - Скорость нашей птичкой
        
        uint currentX = 0; // Начальные координаты (0,0,0)
        uint currentY = 0; 
        uint currentZ = 0; 

        static uint GetRandom() //Получаем рандомное от 1 до 20 -> скорость птицы
        {
            Random rnd = new Random();
            uint value = (uint)rnd.Next(1, 20); //uint - только положительные значения // от 1 чтобы полет состоялся 
            return value;
        }

        public void FlyTo(uint xCorBird, uint yCorBird, uint zCorBird) //Получаем координаты новой точки. Куда нам следует лететь
        {
            Console.WriteLine($" Скорость данной Птички {birdSpeed} км/ч");
            Console.WriteLine($" Птичка начальные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}\n");

            while (xCorBird >= (birdSpeed + currentX)) //Каждый час отчитываемся где находимся
            {
                currentX += birdSpeed;
                Console.WriteLine($"Птичка: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");
                GetFlyTime(currentX,currentY, currentZ);
            }

            Console.WriteLine($"Птичка конечные координаты  X:{xCorBird}, Y:{yCorBird}, Z:{zCorBird}");
        }

        public void GetFlyTime(uint xCorBird, uint yCorBird, uint zCorBird)
        {
            uint flyHour = xCorBird / birdSpeed; // получаем часы
            double flyMinut = ((double)(xCorBird % birdSpeed) / (double)birdSpeed) * 60; //получаем минуты
            flyMinut = Math.Round(flyMinut, 1); //округляем на те случае когда много чисел после запятой (минуты)
            Console.WriteLine($"Птичка: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }
    }
}
