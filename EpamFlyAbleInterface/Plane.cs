using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Plane : IFlyable
    {
        uint currentX = 0; // Начальные координаты (0,0,0)
        uint currentY = 0;
        uint currentZ = 0;
        uint planeSpeed = 200; // Начальная скорость самолета

        public void FlyTo(uint xCorPlane, uint yCorPlane, uint zCorPlane)
        {
            Console.WriteLine($"\n Вылетает самолет. Начальная скорость самолета {planeSpeed} км/ч + 10 км/ч каждые 10 км. Максимальная скорость: 800 км/ч \n");

            while (xCorPlane > currentX) //Каждый 10 км отчитываемся где находимся и какая скорость самолета
            {
                currentX += 10; // Продвигаемся на 10 км
                                
                if (planeSpeed < 800) // Ограничим максимальную скорость самолета 800 км/ч (это пассажирский самолет)
                {
                    planeSpeed += 10; //Увеличиваем скорость на 10км/ч каждые 10 км пути 
                }

                if (yCorPlane > currentY) // Полет в вверх +1 км (координата Y) на каждые 10 км по координате Х
                {
                    currentY++;
                }

                if (zCorPlane > currentZ) // Полет в право: Z координата. Вправо уходим на 3 км (координата Z) на каждые 10 км по координате Х
                {
                    currentZ += 3;
                    if (currentZ > zCorPlane)
                    {
                        currentZ = zCorPlane;
                    }
                }

                //If конечные координаты не кратны 10 и мы немного перелетели с шагом 10
                if (currentX > xCorPlane)
                {
                    
                    if (planeSpeed != 800)
                    {
                        planeSpeed = (planeSpeed - 10) + (currentX - xCorPlane);
                    }

                    currentX = xCorPlane;
                }

                if ((currentX % 100) == 0) //отчитываемся каждые 100 км
                {
                    Console.WriteLine($"Самолет: скорость: {planeSpeed}");
                    Console.WriteLine($"Самолет: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    GetFlyTime(currentX, currentY, currentZ);
                }
            }

            Console.WriteLine($"Самолет: скорость: {planeSpeed}");
            Console.WriteLine($"Самолет: конечные координаты  X:{currentX}, Y:{currentY}, Z:{currentZ}");
        }

        public void GetFlyTime(uint xCorPlane, uint yCorPlane, uint zCorPlane)
        {
            uint flyHour = xCorPlane / planeSpeed; // получаем часы
            double flyMinut = ((double)(xCorPlane % planeSpeed) / (double)planeSpeed) * 60; //получаем минуты
            flyMinut = Math.Round(flyMinut, 1); //округляем на те случае когда много чисел после запятой (минуты)
            Console.WriteLine($"Самолет: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }

    }
}
