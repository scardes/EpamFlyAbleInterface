using System;
using System.Collections.Generic;
using System.Text;

namespace EpamFlyAbleInterface
{
    interface IFlyable //интерфейс IFlyable с методами FlyTo(новая точка), GetFlyTime(новая точка)
    {
        void FlyTo(uint xCorInt, uint yCorInt, uint zCorInt);

        void GetFlyTime(uint xCorInt, uint yCorInt, uint zCorInt);
    }
}
