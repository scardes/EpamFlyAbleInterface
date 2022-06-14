using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    interface IFlyable //интерфейс IFlyable с методами FlyTo(новая точка), GetFlyTime(новая точка)
    {

        void FlyTo(uint distanceInterface);

        void GetFlyTime(uint distanceInterface);
                
    }
}
