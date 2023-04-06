using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class to get random parameters for calculating motion coordinate.
    /// </summary>
    public class RandomMotionFactory : MotionFactoryBase
    {
        /// <summary>
        /// Get the instance of a certain motion.
        /// </summary>
        /// <param name="motionType">Motion type.</param>
        /// <returns>An instance of a certain motion.</returns>
        /// <exception cref="ArgumentException">Only designated motion
        /// types.</exception>
        public override MotionBase GetInstance(MotionType motionType)
        {
            var rnd = new Random();
            const int maxValue = 10;

            switch (motionType)
            {
                case (MotionType.UniformMotion):
                {
                    var tmpInitCoordinate = GetRandomValue(maxValue, false);

                    var tmpSpeed = GetRandomValue(maxValue, false);

                    var tmpTime = GetRandomValue(maxValue, true);

                    return new UniformMotion
                            (tmpInitCoordinate, tmpSpeed, tmpTime);
                }
                case (MotionType.UniformAccelMotion):
                {
                    var tmpInitCoordinate = GetRandomValue(maxValue, false);

                    var tmpAcceleration = GetRandomValue(maxValue, false);

                    var tmpSpeed = GetRandomValue(maxValue, false);

                    var tmpTime = GetRandomValue(maxValue, true);

                    return new UniformAccelMotion(tmpSpeed,
                        tmpInitCoordinate, tmpAcceleration, tmpTime);
                }
                case (MotionType.OscilMotion):
                {
                    var tmpAmplitude = GetRandomValue(maxValue, true);

                    var tmpCyclFrequency = GetRandomValue(maxValue, true);

                    var tmpInitPhase = GetRandomValue(maxValue, false);

                    var tmpTime = GetRandomValue(maxValue, true);

                    return new OscilMotion(tmpAmplitude,
                        tmpCyclFrequency, tmpInitPhase, tmpTime);
                }
                default:
                    throw new ArgumentException
                        ("Enter only designated motion types.");
            }
        }
    }
}
