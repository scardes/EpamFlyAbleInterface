using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Drone : IFlyable
    {
        uint currentX = 0; // Начальные координаты (0,0,0)
        uint currentY = 0;
        uint currentZ = 0;
        uint droneSpeed = 30; // Скорость дрона
        double flyMinut = 0;
        uint flyHour = 0;

        public void FlyTo(uint xCorDrone, uint yCorDrone, uint zCorDrone)
        {
            Console.WriteLine($" Скорость дрона {droneSpeed} км/ч. Каждые 10 минут пролетает {droneSpeed * 10 / 60} км.  \n");

            while (xCorDrone >= (currentX))
            {
                currentX += (droneSpeed * 10 / 60); // Проходим это расстояние по координате Х: за 10 минут

                Console.WriteLine($"Дрон: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");

                flyMinut += 11; // 10+1 минута (10 полета и 1 минута зависания)

                if (flyMinut >= 60) // Переводим минуты в часы
                {
                    flyMinut -= 60;
                    flyHour++;
                }

                Console.WriteLine($"Дрон: Длительность полета: {flyHour} часов и {flyMinut} минут\n");

            }

            Console.WriteLine($"Дрон: конечные координаты  X:{currentX}, Y:{currentY}, Z:{currentZ}");
            Console.WriteLine($"Дрон: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }

        public void GetFlyTime(uint xCorDrone, uint yCorDrone, uint zCorDrone) 
        {            
        }
        
    }
}
