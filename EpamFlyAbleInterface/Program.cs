using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            uint cleanCordX;
            uint cleanCordY;
            uint cleanCordZ;

            Console.WriteLine("Программа по определению 3D-местоположения летящего объекта:\n");

            // Ask the user to type the (Координата Х) number.
            Console.Write("Введите расстояние для полета в км (Координата Х): ");
            string cordInputX = Console.ReadLine();

            while (!uint.TryParse(cordInputX, out cleanCordX))
            {
                Console.Write("Please enter расстояние для полета в км (Координата Х): ");
                cordInputX = Console.ReadLine();
            }

            // Ask the user to type the (Координата Y) number.
            Console.Write("Введите высоту полета в км (Координата Y): ");
            string cordInputY = Console.ReadLine();

            while (!uint.TryParse(cordInputY, out cleanCordY))
            {
                Console.Write("Please enter расстояние для полета в км (Координата Y): ");
                cordInputY = Console.ReadLine();
            }
            // Ask the user to type the (Координата Z) number.
            Console.Write("Введите отклонение в право в км(Координата Z): ");
            string cordInputZ = Console.ReadLine();

            while (!uint.TryParse(cordInputZ, out cleanCordZ))
            {
                Console.Write("Введите отклонение в право в км(Координата Z): ");
                cordInputZ = Console.ReadLine();
            }
            

            void FlyAction(IFlyable fly) // Обращение к интерфейсу
            {
                fly.FlyTo(cleanCordX, cleanCordY, cleanCordZ); //Передаем координаты новой точки
                fly.GetFlyTime(cleanCordX, cleanCordY, cleanCordZ); //Передаем координаты новой точки
            }

            Bird bird = new Bird();
            FlyAction(bird);

            Plane plane = new Plane();
            FlyAction(plane);

            Drone drone = new Drone();
            FlyAction(drone);

            Console.WriteLine("\nВыход из программы");
            Console.ReadLine(); // Дружественный выход
        }
    }
}
