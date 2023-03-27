using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class for oscillating motion.
    /// </summary>
    public class OscilMotion : MotionBase
    {
        /// <summary>
        /// Amplitude.
        /// </summary>
        private double _amplitude;

        /// <summary>
        /// Cyclic frequency.
        /// </summary>
        private double _cyclFrequency;

        /// <summary>
        /// Initial phase.
        /// </summary>
        private double _initPhase;

        /// <summary>
        /// Amplitude field's property.
        /// </summary>
        public double Amplitude
        {
            get => _amplitude;
            set
            {
                CheckValue(value, MinValue);
                _amplitude = value;
            }
        }

        /// <summary>
        /// Cyclic frequency field's property.
        /// </summary>
        public double CyclFrequency
        {
            get => _cyclFrequency;
            set 
            {
                CheckValue(value, MinValue);
                _cyclFrequency = value;
            }
        }

        /// <summary>
        /// Initial phase field's property.
        /// </summary>
        public double InitPhase
        {
            get => _initPhase;
            set => _initPhase = value;
        }

        /// <summary>
        /// Oscillating motion coordinate.
        /// </summary>        
        public override double Coordinate => Amplitude *
            Math.Sin(CyclFrequency * Time + InitPhase);

        /// <summary>
        /// Information about calculating.
        /// </summary>
        public override string Info =>
            $"Motion type: Oscillating motion\n" +
            $"Amplitude: {Amplitude}\n" +
            $"Cyclic frequency: {CyclFrequency}\n" +
            $"Initial phase: {InitPhase}\n" +
            $"Time: {Time}\n";

        /// <summary>
        /// An instance of class OscilMotion.
        /// </summary>
        /// <param name="amplitude">Amplitude.</param>
        /// <param name="cyclFrequency">Cyclic frequency.</param>
        /// <param name="initPhase">Initial phase.</param>
        /// <param name="time">Time.</param>
        public OscilMotion(double amplitude, double cyclFrequency,
            double initPhase, double time) : base(time)
        {
            Amplitude = amplitude;
            CyclFrequency = cyclFrequency;
            InitPhase = initPhase;
        }
    }
}
