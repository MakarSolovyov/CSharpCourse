namespace Model
{
    /// <summary>
    /// Class which describes a certain adult.
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Number of adult's passport.
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Adult's employer.
        /// </summary>
        private string _employer;

        /// <summary>
        /// Husband or wife.
        /// </summary>
        private Adult _spouse;

    }
}
