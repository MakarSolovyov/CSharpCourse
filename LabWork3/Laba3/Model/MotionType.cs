using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Variant's of motion types.
    /// </summary>
    public enum MotionType
    {
        /// <summary>
        /// Uniform motion.
        /// </summary>
        UniformMotion,

        /// <summary>
        /// Uniformly accelerated motion.
        /// </summary>
        UniformAccelMotion,

        /// <summary>
        /// Oscillating motion.
        /// </summary>
        OscilMotion
    }
}
