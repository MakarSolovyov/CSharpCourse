﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Base class for motion factory.
    /// </summary>
    public abstract class MotionFactoryBase
    {
        /// <summary>
        /// Get instance of a certain motion.
        /// </summary>
        /// <returns>An instance of a motion.</returns>
        public abstract MotionBase GetInstance(MotionType motionType);
        
        /// <summary>
        /// Get random value.
        /// </summary>
        /// <param name="maxValue">Max value.</param>
        /// TODO:+ to boolean
        /// <param name="onlyPositive">Input True to get positive value
        /// for sure.</param>
        /// <returns>A positive/negative value.</returns>
        public double GetRandomValue(int maxValue, bool onlyPositive)
        {
            var rnd = new Random();
            var plusMinus = rnd.Next(2);
            var tmpValue = plusMinus == 0
                ? Math.Round(rnd.NextDouble() * maxValue, 2)
                : -Math.Round(rnd.NextDouble() * maxValue, 2);

            if (onlyPositive)
            {
                tmpValue = Math.Abs(tmpValue);
            }

            return tmpValue;
        }
    }
}
