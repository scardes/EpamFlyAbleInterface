using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по определению 3D-местоположения летящего объекта:\n");

            Console.Write("Введите расстояние для полета в км (Координата Х): ");
            uint cordinateXGlobal = Convert.ToUInt32(Console.ReadLine());
            uint cordinateYGlobal = 0;
            uint cordinateZGlobal = 0;
            //Console.Write("Введите высоту полета в км (Координата Y): ");
            //uint cordinateYGlobal = Convert.ToUInt32(Console.ReadLine());
            //Console.Write("Введите отклонение в право в км (Координата Z): ");
            //uint cordinateZGlobal = Convert.ToUInt32(Console.ReadLine());

            void FlyAction(IFlyable fly) // Обращение к интерфейсу
            {
                fly.FlyTo(cordinateXGlobal, cordinateYGlobal, cordinateZGlobal); //Передаем координаты новой точки
                fly.GetFlyTime(cordinateXGlobal, cordinateYGlobal, cordinateZGlobal); //Передаем координаты новой точки
            }

            //Bird bird = new Bird();
            //FlyAction(bird);

            //Plane plane = new Plane();
            //FlyAction(plane);

            Drone drone = new Drone();
            FlyAction(drone);

            Console.WriteLine("\nВыход из программы");
            Console.ReadLine(); // Дружественный выход
        }
    }
}
