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
                    newOscilMotion.Time = Convert.ToDouble
                        (timeValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newOscilMotion.Amplitude = Convert.ToDouble
                        (amplitudeValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newOscilMotion.CyclFrequency = Convert.ToDouble
                        (cyclFrequencyValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newOscilMotion.InitPhase = Convert.ToDouble
                        (initPhaseValue.Text.ReplaceByComma());
                },
            };

            InputParameters(actions);

            return newOscilMotion;
        }
    }
}
