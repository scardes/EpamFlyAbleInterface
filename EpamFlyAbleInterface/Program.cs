using System;

namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по определению местоположения летящего объекта:\n");

            void FlyAction(IFlyable fly)
            {
                fly.FlyTo();
            }

            // uint xCord = 

            Plane plane = new Plane();
            FlyAction(plane);

            

            Console.WriteLine("\nВыход из программы");
        }
    }
}
