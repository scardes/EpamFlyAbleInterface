using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class bird: 
/// 1. Bird has a random speed (1 - 20) km/h 
/// 2. Takeoff speed is +1 km/h
/// 3. Limit of hight is 8 km 
/// 4. Turn right speed is +2 km/h
/// </summary>
namespace EpamFlyAbleInterface
{
    public class Bird : IFlyable 
    {
        uint currentX = 0;
        uint currentY = 0; 
        uint currentZ = 0;
        int hundreds = 100;

        //Get random number from 1 to 20 and this is our bird (km/h) speed = birdSpeed
        private static uint GetRandom()
        {
            Random rnd = new Random();
            uint value = (uint)rnd.Next(1, 20); 
            return value;
        }

        private uint birdSpeed = GetRandom();

        // Get coordinates of the final point
        public void FlyTo(uint xCorBird, uint yCorBird, uint zCorBird) 
        {
            Console.WriteLine($"\n\tBird start to fly. Bird speed = {birdSpeed} km/h, takeoff speed is +1 km/h");
            Console.WriteLine("\tBird have hight limit =8 km, Turn right speed is +2 km/h \n");

            //One iteration = 1 hour
            while (xCorBird > (birdSpeed + currentX)) 
            {
                // Distanse (Coordinate X)
                currentX += birdSpeed;

                // Fly UP (Coordinate Y)
                if (yCorBird > currentY)
                {
                    FlyUp(currentY);
                }

                // Turn right (Coordinate Z) speed is +2 km/h
                if (zCorBird > currentZ) 
                {
                    currentZ += 2;
                    if (currentZ > zCorBird)
                    {
                        currentZ = zCorBird;
                    }
                }

                // Show temporary coordinats of bird fly, every (more than) 100 km. 
                if ((currentX) >= hundreds)
                {
                    Console.WriteLine($"Bird: Temporary coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    GetFlyTime(currentX, currentY, currentZ);
                    hundreds += 100; 
                }

            }

            currentX = xCorBird;
            Console.WriteLine($"Bird End Fly: Coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}"); 
        }

        // Bird take-off. Speed +1 km/h and bird have limit of hight is 8 km 
        private uint FlyUp(uint yCorBird)
        {
            if (currentY >= 8)
            {
                return currentY;
            }
            return currentY++;
        }

        // Get Fly time. FlyMinut has rounding
        public void GetFlyTime(uint xCorBird, uint yCorBird, uint zCorBird) 
        {
            uint flyHour = xCorBird / birdSpeed; 
            double flyMinut = ((double)(xCorBird % birdSpeed) / (double)birdSpeed) * 60; 
            flyMinut = Math.Round(flyMinut, 1); 
            Console.WriteLine($"Bird:  flight time: {flyHour} hours and {flyMinut} minute\n");
        }

    }
}
