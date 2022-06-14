using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по определению местоположения летящего объекта:\n");

            Console.WriteLine("Введите расстояние для полета в км (Координата Х): ");
            uint distanceGlobal = Convert.ToUInt32(Console.ReadLine());

            void FlyAction(IFlyable fly) // FlyAction
            {
                fly.FlyTo(distanceGlobal);
                fly.GetFlyTime(distanceGlobal);
            }

            //первый этап просто сделаем скорость птицы. Вводим расстояние и получаем время в полете. 
            //начнем с птички

            
            Bird bird = new Bird();
            FlyAction(bird);


            //Plane plane = new Plane();
            //FlyAction(plane);

            

            Console.WriteLine("\nВыход из программы");
        }
    }
}
