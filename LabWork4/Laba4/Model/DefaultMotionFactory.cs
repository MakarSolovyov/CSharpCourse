namespace Model
{
    /// <summary>
    /// Class to get default parameters for calculating motion coordinate.
    /// </summary>
    public class DefaultMotionFactory : MotionFactoryBase
    {
        /// <summary>
        /// Get the instance of a certain motion with deafault parameters.
        /// </summary>
        /// <param name="motionType">Motion type.</param>
        /// <returns>An instance of a certain motion.</returns>
        /// <exception cref="ArgumentException">Only designated motion
        /// types.</exception>
        public override MotionBase GetInstance(MotionType motionType)
        {
            switch (motionType)
            {
                case (MotionType.UniformMotion):
                    {
                        return new UniformMotion();
                    }

                case (MotionType.UniformAccelMotion):
                    {
                        return new UniformAccelMotion();
                    }

                case (MotionType.OscilMotion):
                    {
                        return new OscilMotion();
                    }

                default:
                    throw new ArgumentException
                        ("Enter only designated motion types.");
            }
        }
    }
}
