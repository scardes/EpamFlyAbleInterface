using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class Plane:
/// 1. Plane start with speed = 200 km/h
/// 2. Every 10 km  increases the speed to 10 km/h
/// 3. Plane MAX speed is 800 km/h
/// 4. Takeoff speed increase is +1 km/h each 10 km of distanse 
/// 5. Turn right increase is +3 km/h each 10 km of distanse
/// </summary>
namespace EpamFlyAbleInterface
{
    class Plane : IFlyable
    {
        uint currentX = 0;
        uint currentY = 0;
        uint currentZ = 0;
        uint planeSpeed = 200;

        // Get coordinates of the final point
        public void FlyTo(uint xCorPlane, uint yCorPlane, uint zCorPlane)
        {
            Console.WriteLine($"\tPlane start to fly. Start speed is {planeSpeed}km/h +10km/h (Max=800km/h) every 10 km.");
            Console.WriteLine("\tTakeoff speed increase is +1 km/h and turn right +3 km/h every 10 km. \n");

            //One iteration = 10 km 
            while (xCorPlane > currentX) 
            {
                // Distanse (Coordinate X)
                currentX += 10;

                // Increase plane speed with speed limit = 800 km/h (passenger aircraft)
                if (planeSpeed < 800) 
                {
                    planeSpeed += 10;
                }

                // Fly UP (Coordinate Y) increase is +1 km/h each 10 km by (Coordinate X)
                if (yCorPlane > currentY) 
                {
                    currentY++;
                }

                // Turn right (Coordinate Z) increase is +3 km/h each 10 km by (Coordinate X)
                if (zCorPlane > currentZ) 
                {
                    currentZ += 3;
                    if (currentZ > zCorPlane)
                    {
                        currentZ = zCorPlane;
                    }
                }

                //If the final coordinates are not multiple of 10km and we get a overflight
                if (currentX > xCorPlane)
                {
                    
                    if (planeSpeed != 800)
                    {
                        planeSpeed = (planeSpeed - 10) + (currentX - xCorPlane);
                    }

                    currentX = xCorPlane;
                }

                // Show temporary coordinats of plane, every 100 km. 
                if ((currentX % 100) == 0)
                {
                    Console.WriteLine($"Plane speed is: {planeSpeed}");
                    Console.WriteLine($"Plane: Temporary coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    GetFlyTime(currentX, currentY, currentZ);
                }
            }

            Console.WriteLine($"Plane speed is:  {planeSpeed}");
            Console.WriteLine($"Plane End Fly. Coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}");
        }

        // Get Fly time. FlyMinut has rounding
        public void GetFlyTime(uint xCorPlane, uint yCorPlane, uint zCorPlane)
        {
            uint flyHour = xCorPlane / planeSpeed; 
            double flyMinut = ((double)(xCorPlane % planeSpeed) / (double)planeSpeed) * 60; 
            flyMinut = Math.Round(flyMinut, 1); 
            Console.WriteLine($"Plane: flight time: {flyHour} hours and {flyMinut} minute\n");
        }

    }
}
