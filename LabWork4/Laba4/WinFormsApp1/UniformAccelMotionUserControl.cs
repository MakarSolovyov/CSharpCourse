using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// UniformAccelMotionUserControl.
    /// </summary>
    public partial class UniformAccelMotionUserControl :
        MotionBaseUserControl
    {
        /// <summary>
        /// UniformAccelMotionUserControl instance constructor.
        /// </summary>
        public UniformAccelMotionUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to get an Motion object.
        /// </summary>
        /// <returns>An MotionBase object.</returns>
        public override MotionBase GetMotion()
        {
            var newUniformAccelMotion = new UniformAccelMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    newUniformAccelMotion.Time = Convert.ToDouble
                    (timeValue.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Speed = Convert.ToDouble
                    (speedValue.Text);
                },

                () =>
                {
                    newUniformAccelMotion.InitCoordinate = Convert.ToDouble
                    (initCoordinateValue.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Acceleration = Convert.ToDouble
                    (accelerationValue.Text);
                },
            };

            // TODO:+ duplication
            InputParameters(actions);

            return newUniformAccelMotion;
        }
    }
}
