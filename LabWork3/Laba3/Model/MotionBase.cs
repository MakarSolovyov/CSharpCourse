﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Base class for motion types.
    /// </summary>
    public abstract class MotionBase
    {
        /// <summary>
        /// Time.
        /// </summary>
        private double _time;

        /// <summary>
        /// Minimal value for certain parameters.
        /// </summary>
        protected const double MinValue = 0;

        /// <summary>
        /// Time field's property.
        /// </summary>
        public double Time
        {
            get => _time;
            set
            {
                CheckValue(value, MinValue);
                _time = value;
            }
        }

        /// <summary>
        /// An instance of class MotionBase.
        /// </summary>
        /// <param name="initCoordinate">Initial coordinate value.</param>
        /// <param name="speed">Speed value.</param>
        /// <param name="time">Time value.</param>
        public MotionBase(double time)
        {
            Time = time;
        }

        /// <summary>
        /// Coordinate field's property.
        /// </summary>
        public abstract double Coordinate { get; }

        /// <summary>
        /// Info field's property.
        /// </summary>
        public abstract string Info { get; }

        /// <summary>
        /// Check parameters for positive values.
        /// </summary>
        /// <param name="value">A certain value.</param>
        /// <param name="minValue">Min value.</param>
        /// <exception cref="ArgumentOutOfRangeException">Value must be
        /// greater than minimal value.</exception>
        protected static void CheckValue(double value, double minValue)
        {
            if (value < minValue)
            {
                throw new ArgumentOutOfRangeException
                    ($"{value} must be greater than {minValue}");
            }
        }
    }
}
