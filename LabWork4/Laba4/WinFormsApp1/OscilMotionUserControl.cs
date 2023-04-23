using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Class OscilMotionUserControl.
    /// </summary>
    public partial class OscilMotionUserControl : MotionBaseUserControl
    {
        /// <summary>
        /// OscilMotionUserControl instance constructor.
        /// </summary>
        public OscilMotionUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to get an Motion object.
        /// </summary>
        /// <returns>A MotionBase object.</returns>
        public override MotionBase GetMotion()
        {
            var newOscilMotion = new OscilMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    // TODO:+ rename
                    newOscilMotion.Time = Convert.ToDouble
                    (timeValue.Text);
                },

                () =>
                {
                    newOscilMotion.Amplitude = Convert.ToDouble
                    (amplitudeValue.Text);
                },

                () =>
                {
                    newOscilMotion.CyclFrequency = Convert.ToDouble
                    (cyclFrequencyValue.Text);
                },

                () =>
                {
                    newOscilMotion.InitPhase = Convert.ToDouble
                    (initPhaseValue.Text);
                },
            };

            // TODO:+ duplication
            InputParameters(actions);

            return newOscilMotion;
        }
    }
}
