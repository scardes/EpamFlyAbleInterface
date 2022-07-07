using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Interface with two metods 
/// 1. FlyTo (3d-coordinats of final point) and 
/// 2. GetFlyTime (Calculate time of time of fly from 3d-Coordinats)
/// </summary>
namespace EpamFlyAbleInterface
{
    interface IFlyable
    {
        void FlyTo(uint xCorInt, uint yCorInt, uint zCorInt);

        void GetFlyTime(uint xCorInt, uint yCorInt, uint zCorInt);
    }
}
