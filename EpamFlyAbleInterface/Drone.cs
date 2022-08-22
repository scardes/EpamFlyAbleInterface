using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class Drone:
/// 1. Drone speed is 30 km/h
/// 2. Drone every 10 minut, hangs out to the 1 minute.
/// 3. Drone distance limit = 1000km
/// 4. Takeoff speed increase is +2 km/h every 11 minutes
/// 5. Turn right speed increase +3 km/h every 11 minutes
/// </summary>
namespace EpamFlyAbleInterface
{
    public class Drone : IFlyable
    {
        uint currentX = 0; // Start coordinates (0,0,0)
        uint currentY = 0;
        uint currentZ = 0;
        uint droneSpeed = 30; // Drone Speed
        double flyMinut = 0;
        uint flyHour = 0;

        public void FlyTo(uint xCorDrone, uint yCorDrone, uint zCorDrone)
        {
            Console.WriteLine($"\tDrone start to fly. Drone speed = {droneSpeed} km/h. Each 10 minut drone move to {droneSpeed * 10 / 60} km.");
            Console.WriteLine("\tTakeoff speed increase is +2 km/h and turn right +3 km/h every 11 minutes.");
            Console.WriteLine("\tDrone every 10 minut, hangs out to the 1 minute. \n");

            //One iteration = 10(+1) minute and 5km of distanse 
            while (xCorDrone > currentX) 
            {
                // Distanse (Coordinate X) 
                currentX += (droneSpeed * 10 / 60);

                //Add minutes each iteration
                flyMinut += 11;

                // Turn the minutes into hours
                if (flyMinut >= 60) 
                {
                    flyMinut -= 60;
                    flyHour++;
                }

                // Fly UP (Coordinate Y) increase is +1 km/h each 11 minutes (5 km) 
                if (yCorDrone > currentY) 
                {
                    currentY += 2;
                    if (currentY > yCorDrone)
                    {
                        currentY = yCorDrone;
                    }
                }

                // Turn right (Coordinate Z) increase is +3 km/h each 11 minutes (5 km)
                if (zCorDrone > currentZ) 
                {
                    currentZ += 3;
                    if (currentZ > zCorDrone)
                    {
                        currentZ = zCorDrone;
                    }
                }

                // Drone distance limit = 1000km
                if (currentX >= 1000)
                {
                    currentX = 1000;
                    Console.WriteLine("Drone distance limit = 1000km\n");
                    break;
                }

                //If the final coordinates are not multiple of 5km and we get a overflight
                if (currentX > xCorDrone)
                {
                    //Take away 11 minutes + Then found distance to fly and multiply to a period of time drone over a distance by 1km
                    flyMinut = (flyMinut - 11) + ((xCorDrone - (currentX-5)) * (60 / droneSpeed));

                    // Turn the hours into minutes
                    if (flyMinut <= 0) 
                    {
                        flyMinut += 60;
                        flyHour--;
                    }

                    currentX = xCorDrone;
                }

                // Show temporary coordinats of plane, every 100 km. 
                if ((currentX % 100) == 0) 
                {
                    Console.WriteLine($"Drone: Temporary coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}");
                    GetFlyTime(currentX, currentY, currentZ);
                } 
            }
            Console.WriteLine($"Drone end of fly. Coordinats X:{currentX}, Y:{currentY}, Z:{currentZ}");
        }

        // We need this method, because we use IFlyable Interface which need all his methods in inheritanced class
        public void GetFlyTime(uint xCorDrone, uint yCorDrone, uint zCorDrone)
        {
            Console.WriteLine($"Drone: flight time: {flyHour} hours and {flyMinut} minute\n");
        }
        
    }
}
