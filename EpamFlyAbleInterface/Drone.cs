using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 
/// </summary>
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
            Console.WriteLine($" \n Вылетает дрон. Скорость дрона {droneSpeed} км/ч. Каждые 10 минут пролетает {droneSpeed * 10 / 60} км.");
            Console.WriteLine(" Дрон каждые 10 минут, зависает на 1 минуту (двигаясь по координате Х) \n");

            while (xCorDrone > currentX) // передвигаемся по координате Х 
            {
                currentX += (droneSpeed * 10 / 60); // Проходим это расстояние по координате Х: за 10 минут

                flyMinut += 11; // 10+1 минута (10 полета и 1 минута зависания)

                if (flyMinut >= 60) // Переводим минуты в часы
                {
                    flyMinut -= 60;
                    flyHour++;
                }

                if (yCorDrone > currentY) // Полет в вверх: Y координата. Вправо уходим на 2 км (координата Y) на каждые 10 минут по координате Х
                {
                    currentY += 2;
                    if (currentY > yCorDrone)
                    {
                        currentY = yCorDrone;
                    }
                }

                if (zCorDrone > currentZ) // Полет в право: Z координата. Вправо уходим на 3 км (координата Z) на каждые 10 минут по координате Х
                {
                    currentZ += 3;
                    if (currentZ > zCorDrone)
                    {
                        currentZ = zCorDrone;
                    }
                }

                if (currentX >= 1000)
                {
                    currentX = 1000;
                    Console.WriteLine("Дрон больше 1000км не пролетит\n");
                    break;
                }

                // Перелет шага
                if (currentX > xCorDrone)
                {
                    //Отнимаем прибавленные 11 минут + высчитываем заново (определяем сколько еще км надо пролететь и умнажаем на расстояние которое пролетаем за 1км
                    flyMinut = (flyMinut - 11) + ((xCorDrone - (currentX-5)) * (60 / droneSpeed)); 

                    if (flyMinut <= 0) // Переводим минуты в часы
                    {
                        flyMinut += 60;
                        flyHour--;
                    }

                    currentX = xCorDrone;
                }


                if ((currentX % 100) == 0) //отчитываемся каждые 100 км
                {
                    
                    Console.WriteLine($"Дрон: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    Console.WriteLine($"Дрон: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
                } 

            }

            Console.WriteLine($"Дрон: Конечные координаты  X:{currentX}, Y:{currentY}, Z:{currentZ}");
            Console.WriteLine($"Дрон: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }

        public void GetFlyTime(uint xCorDrone, uint yCorDrone, uint zCorDrone)
        {
        }
        
    }
}
