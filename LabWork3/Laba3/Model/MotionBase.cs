using System;
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
        /// Time field's property.
        /// </summary>
        public double Time
        {
            get => _time;
            set
            {
                if (_time > 0)
                {
                    _time = value;
                }
                else
                {
                    throw new ArgumentException
                        ("Time value must be greater than 0");
                }
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
    }
}
