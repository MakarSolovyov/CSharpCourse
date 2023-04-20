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
                    //TODO: rename
                    newOscilMotion.Time = Convert.ToDouble
                    (textBox1.Text);
                },

                () =>
                {
                    newOscilMotion.Amplitude = Convert.ToDouble
                    (textBox2.Text);
                },

                () =>
                {
                    newOscilMotion.CyclFrequency = Convert.ToDouble
                    (textBox3.Text);
                },

                () =>
                {
                    newOscilMotion.InitPhase = Convert.ToDouble
                    (textBox4.Text);
                },
            };
            //TODO: duplication
            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newOscilMotion;
        }
    }
}
