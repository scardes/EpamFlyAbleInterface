using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    class Plane : IFlyable
    {
        public void FlyTo()
        {
            Console.WriteLine("Plane >> FlyTo");

        }

        public void GetFlyTime()
        {
            Console.WriteLine("Plane >> GetFlyTime");
        }


    }
}
