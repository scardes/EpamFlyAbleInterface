using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class bird: 1. Bird has a random speed (1 -20) km/h 2. 
/// </summary>
namespace EpamFlyAbleInterface
{
    class Bird : IFlyable // За основу взята координата Х. До которой мы всегда добираемся. А вот высота и поворот на право - не гарантируемы
    {
        uint currentX = 0; // Начальные координаты (0,0,0)
        uint currentY = 0; 
        uint currentZ = 0;
        int hundreds = 100;

        //Get random number from 1 to 20 and this is our bird (km/h) speed = birdSpeed
        static uint GetRandom()
        {
            Random rnd = new Random();
            uint value = (uint)rnd.Next(1, 20); 
            return value;
        }

        private uint birdSpeed = GetRandom(); 

        public void FlyTo(uint xCorBird, uint yCorBird, uint zCorBird) //Получаем координаты новой точки. Куда нам следует лететь
        {
            Console.WriteLine($"\n\tBird start to fly. Скорость Птички {birdSpeed} км/ч, Набор высоты +1 км/ч (Максимум 8 КМ), вправо +2 км/ч \n");

            while (xCorBird > (birdSpeed + currentX)) //Каждый час отчитываемся где находимся
            {
                currentX += birdSpeed; // Полет в длину: Х координата 
                
                if (yCorBird > currentY) // Полет в высоту: Y координата
                {
                    FlyUp(currentY);
                }

                if (zCorBird > currentZ) // Полет в право: Z координата. Вправо уходим со скоростью макс 2 км/ч
                {
                    currentZ += 2;
                    if (currentZ > zCorBird)
                    {
                        currentZ = zCorBird;
                    }
                }

                if ((currentX) >= hundreds) //отчитываемся каждые 100 км
                {
                    Console.WriteLine($"Птичка: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    GetFlyTime(currentX, currentY, currentZ);
                    hundreds += 100; // Счетчик
                }

            }

            currentX = xCorBird;
            Console.WriteLine($"Птичка: конечные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}"); //xCorBird - по длине всегда долетам
        }

        public void GetFlyTime(uint xCorBird, uint yCorBird, uint zCorBird) // Высчитываем время полета
        {
            uint flyHour = xCorBird / birdSpeed; // получаем часы
            double flyMinut = ((double)(xCorBird % birdSpeed) / (double)birdSpeed) * 60; //получаем минуты
            flyMinut = Math.Round(flyMinut, 1); //округляем на те случае когда много чисел после запятой (минуты)
            Console.WriteLine($"Птичка: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }

        private uint FlyUp(uint yCorBird) // Набор высоты. Птичка набирает высоту по 1 км в час. И не может поднятся выше 8 км 
        {
            if (currentY >= 8)
            {
                return currentY;
            }
            return currentY++;
        }
    }
}
