using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coordinate = new Coordinate();

            Console.WriteLine("Программа по определению 3D-местоположения летящего объекта:\n");
            
            //Ask the user to type the (Координата Х) number.
            Console.Write("Введите расстояние для полета в км (Координата Х): ");
            string cordInputX = Console.ReadLine();

            while (!uint.TryParse(cordInputX, out coordinate.cleanCordX))
            {
                Console.Write("Please enter расстояние для полета в км (Координата Х): ");
                cordInputX = Console.ReadLine();
            }

            //Ask the user to type the (Координата Y) number.
            Console.Write("Введите высоту полета в км (Координата Y): ");
            string cordInputY = Console.ReadLine();

            while (!uint.TryParse(cordInputY, out coordinate.cleanCordY))
            {
                Console.Write("Please enter расстояние для полета в км (Координата Y): ");
                cordInputY = Console.ReadLine();
            }

            //Ask the user to type the (Координата Z) number.
            Console.Write("Введите отклонение в право в км(Координата Z): ");
            string cordInputZ = Console.ReadLine();

            while (!uint.TryParse(cordInputZ, out coordinate.cleanCordZ))
            {
                Console.Write("Введите отклонение в право в км(Координата Z): ");
                cordInputZ = Console.ReadLine();
            }

            Bird bird = new Bird();
            coordinate.FlyAction(bird);

            Plane plane = new Plane();
            coordinate.FlyAction(plane);

            Drone drone = new Drone();
            coordinate.FlyAction(drone);

            Console.WriteLine("\nВыход из программы");
            Console.ReadLine(); // Дружественный выход

        }

        struct Coordinate 
        {
            public uint cleanCordX;
            public uint cleanCordY;
            public uint cleanCordZ;

            //
            public void FlyAction(IFlyable fly) // Обращение к интерфейсу
            {
                fly.FlyTo(cleanCordX, cleanCordY, cleanCordZ); //Передаем координаты новой точки
                fly.GetFlyTime(cleanCordX, cleanCordY, cleanCordZ); //Передаем координаты новой точки
            }
        }
    }
}