using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по определению местоположения летящего объекта:\n");

            Console.Write("Введите расстояние для полета в км (Координата Х): ");
            uint cordinateXGlobal = Convert.ToUInt32(Console.ReadLine());
            uint cordinateYGlobal = 0; // потом будет ввод с консоли
            uint cordinateZGlobal = 0; // потом будет ввод с консоли


            void FlyAction(IFlyable fly) // Обращение к интерфейсу
            {
                fly.FlyTo(cordinateXGlobal, cordinateYGlobal, cordinateZGlobal); //Передаем координаты новой точки
                fly.GetFlyTime(cordinateXGlobal, cordinateYGlobal, cordinateZGlobal); //Передаем координаты новой точки
            }

            //первый этап просто сделаем скорость птицы. Вводим расстояние и получаем время в полете. 
            //второй этап - сделаем нормальный класса с получением трех координат и добавить поля текущего положения

            Bird bird = new Bird();
            FlyAction(bird);

            //Plane plane = new Plane();
            //FlyAction(plane);

            Console.WriteLine("\nВыход из программы");
            Console.ReadLine(); // Дружественный выход
        }
    }
}
