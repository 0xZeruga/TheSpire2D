using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// This is the class that contain all the converter function
    /// </summary>
    public class UnitConverter
    {
        /// <summary>
        /// Convert speed from km/h to m/s
        /// </summary>
        /// <param name="pKph">kilometer per hour</param>
        /// <returns>meter per seconds</returns>
        public static float SpeedKphToMps(float pKph)
        {
            return pKph / 3600f;
        }
    }
}
