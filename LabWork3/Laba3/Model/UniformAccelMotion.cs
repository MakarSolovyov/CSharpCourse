using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class for uniformly accelerated motion.
    /// </summary>
    public class UniformAccelMotion : MotionBase
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
        /// Acceleration.
        /// </summary>
        private double _acceleration;

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
        /// Initial coordinate field's property.
        /// </summary>
        public double Acceleration
        {
            get => _acceleration;
            set => _acceleration = value;
        }

        /// <summary>
        /// Uniform motion coordinate.
        /// </summary>        
        public override double Coordinate => Math.Round(InitCoordinate +
            Speed * Time + Acceleration * Time * Time / 2, 2);

        /// <summary>
        /// Information about calculating.
        /// </summary>
        public override string Info =>
            $"Motion type: uniformly accelerated\n" +
            $"Initial coordinate: {InitCoordinate}\n" +
            $"Speed: {Speed}\n" +
            $"Acceleration: {Acceleration}\n" +
            $"Time: {Time}\n";

        /// <summary>
        /// An instance of class UniformAccelMotion.
        /// </summary>
        /// <param name="speed">Speed.</param>
        /// <param name="initCoordinate">Initial coordinate.</param>
        /// <param name="acceleration">Acceleration.</param>
        /// <param name="time">Time.</param>
        public UniformAccelMotion(double speed, double initCoordinate,
            double acceleration, double time) : base(time)
        {
            Speed = speed;
            InitCoordinate = initCoordinate;
            Acceleration = acceleration;
        }

        /// <summary>
        /// Create an instance of class UniformAccelMotion without
        /// parameters.
        /// </summary>
        public UniformAccelMotion() : this(1.11, 1.11, 1.11, 1.11)
        { }

        // TODO:+ to factory
    }
}
