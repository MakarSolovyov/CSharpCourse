using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class for uniform motion.
    /// </summary>
    public class UniformMotion : MotionBase
    {
        /// <summary>
        /// Speed.
        /// </summary>
        private double _speed;

        /// <summary>
        /// Initial coordinate.
        /// </summary>
        private double _initCoordinate;

        /// <summary>
        /// Speed field's property.
        /// </summary>
        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }

        /// <summary>
        /// Initial coordinate field's property.
        /// </summary>
        public double InitCoordinate
        {
            get => _initCoordinate;
            set => _initCoordinate = value;
        }

        /// <summary>
        /// Uniform motion coordinate.
        /// </summary>        
        public override double Coordinate => InitCoordinate + Speed * Time;

        /// <summary>
        /// Information about calculating.
        /// </summary>
        public override string Info => $"Motion type: uniform\n" +
            $"Initial coordinate: {InitCoordinate}\n" +
            $"Speed: {Speed}\n" +
            $"Time: {Time}\n";

        /// <summary>
        /// An instance of class UniformMotion.
        /// </summary>
        /// <param name="initCoordinate">Initial coordinate value.</param>
        /// <param name="speed">Speed value.</param>
        /// <param name="time">Time value.</param>
        public UniformMotion
            (double initCoordinate, double speed, double time)
            : base(time)
        {
            Speed = speed;
            InitCoordinate = initCoordinate;
        }
    }
}
