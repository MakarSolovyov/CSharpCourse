using System.ComponentModel;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Base class for motion types.
    /// </summary>
    [XmlInclude(typeof(UniformMotion))]
    [XmlInclude(typeof(UniformAccelMotion))]
    [XmlInclude(typeof(OscilMotion))]
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
        [Browsable(false)]
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
        /// <param name="time">Time value.</param>
        public MotionBase(double time)
        {
            Time = time;
        }

        /// <summary>
        /// Motion type field's property sent to DataGridView.
        /// </summary>
        public abstract string MotionType { get; }

        /// <summary>
        /// Parameters field's property sent to DataGridView.
        /// </summary>
        public abstract string Parameters { get; }

        /// <summary>
        /// Coordinate field's property.
        /// </summary>
        public abstract double Coordinate { get; }

        /// <summary>
        /// Info field's property.
        /// </summary>
        [Browsable(false)]
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
            if (double.IsNaN(value))
            {
                throw new ArgumentException("NaN value!");
            }
            else if (value < minValue)
            {
                throw new ArgumentOutOfRangeException
                    ($"{value} must be greater than {minValue}");
            }
        }
    }
}
