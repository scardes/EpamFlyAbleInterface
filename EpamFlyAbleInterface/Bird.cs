using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Bird : IFlyable // За основу взята координата Х. До которой мы всегда добираемся. А вот высота и поворот на право - не гарантируемы
    {
        uint currentX = 0; // Начальные координаты (0,0,0)
        uint currentY = 0; 
        uint currentZ = 0;

        private uint birdSpeed = GetRandom(); //birdSpeed - Скорость нашей птичкой

        static uint GetRandom() //Получаем рандомное от 1 до 20 -> скорость птицы
        {
            Random rnd = new Random();
            uint value = (uint)rnd.Next(1, 20); //uint - только положительные значения // от 1 чтобы полет состоялся 
            return value;
        }

        public void FlyTo(uint xCorBird, uint yCorBird, uint zCorBird) //Получаем координаты новой точки. Куда нам следует лететь
        {
            Console.WriteLine($" Скорость Птички {birdSpeed} км/ч, Набор высоты +1 км/ч, вправо +2 км/ч \n");

            while (xCorBird >= (birdSpeed + currentX)) //Каждый час отчитываемся где находимся
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

                Console.WriteLine($"Птичка: Временные координаты X:{currentX}, Y:{currentY}, Z:{currentZ}");
                GetFlyTime(currentX, currentY, currentZ);
            }

            Console.WriteLine($"Птичка конечные координаты  X:{xCorBird}, Y:{currentY}, Z:{currentZ}"); //xCorBird - по длине всегда долетам
        }

        public void GetFlyTime(uint xCorBird, uint yCorBird, uint zCorBird) // Высчитываем время полета
        {
            uint flyHour = xCorBird / birdSpeed; // получаем часы
            double flyMinut = ((double)(xCorBird % birdSpeed) / (double)birdSpeed) * 60; //получаем минуты
            flyMinut = Math.Round(flyMinut, 1); //округляем на те случае когда много чисел после запятой (минуты)
            Console.WriteLine($"Птичка: Длительность полета: {flyHour} часов и {flyMinut} минут\n");
        }

        uint FlyUp(uint yCorBird) // Набор высоты. Птичка набирает высоту по 1 км в час. И не может поднятся выше 8 км 
        {
            if (currentY >= 8)
            {
                Console.WriteLine("Птичка выше 8 км не поднимется");
                return currentY;
            }
            Console.WriteLine("Птичка набирает высоту +1 км");
            return currentY++;
        }
    }
}
