using System;

/// <summary>
/// Program find a flying object in 3d location with custom terms. 
/// Using interface and three classes Bird, Plane, Drone
/// </summary>
namespace EpamFlyAbleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coordinate = new Coordinate();

            Console.WriteLine("Program find a flying object in 3d location:\n");

            //Ask the user to type the (coordinate Х) number = distance to fly.
            Console.Write("Please enter distance to fly in km (Coordinate Х): ");
            string cordInputX = Console.ReadLine();

            while (!uint.TryParse(cordInputX, out coordinate.cleanCordX))
            {
                Console.Write("Please enter correct number (in km) = distance to fly (Coordinate Х): ");
                cordInputX = Console.ReadLine();
            }

            //Ask the user to type the (coordinate Y) number = height 
            Console.Write("Please enter height of fly (in km) (Coordinate Y): ");
            string cordInputY = Console.ReadLine();

            while (!uint.TryParse(cordInputY, out coordinate.cleanCordY))
            {
                Console.Write("Please enter correct number (in km) = of height of fly (Coordinate Y): ");
                cordInputY = Console.ReadLine();
            }

            //Ask the user to type the (coordinate Z) number = turn to right side
            Console.Write("Please enter turn to the right side (in km) (Coordinate Z): ");
            string cordInputZ = Console.ReadLine();

            while (!uint.TryParse(cordInputZ, out coordinate.cleanCordZ))
            {
                Console.Write("Please enter correct number (in km) = turn to the right side(Coordinate Z): ");
                cordInputZ = Console.ReadLine();
            }

            Bird bird = new Bird();
            coordinate.FlyAction(bird);

            Plane plane = new Plane();
            coordinate.FlyAction(plane);

            Drone drone = new Drone();
            coordinate.FlyAction(drone);

            // Frendly exit
            Console.WriteLine("\nProgram exit");
            Console.ReadLine(); 

        }

        /// <summary>
        /// Struct for transmit coordinates of new point (by Interface FlyAction) to classes
        /// </summary>
        struct Coordinate 
        {
            public uint cleanCordX;
            public uint cleanCordY;
            public uint cleanCordZ;

            public void FlyAction(IFlyable fly) 
            {
                fly.FlyTo(cleanCordX, cleanCordY, cleanCordZ); 
                fly.GetFlyTime(cleanCordX, cleanCordY, cleanCordZ); 
            }
        }
    }
}