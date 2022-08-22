using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    /// <summary>
    /// Struct for transmit coordinates of new point (by Interface FlyAction) to classes
    /// </summary>
    public struct Coordinate
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
