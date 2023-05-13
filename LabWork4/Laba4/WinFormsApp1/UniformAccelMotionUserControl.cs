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

                    // TODO:+ duplication
                    (timeValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newUniformAccelMotion.Speed = Convert.ToDouble

                    // TODO:+ duplication
                    (speedValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newUniformAccelMotion.InitCoordinate = Convert.ToDouble

                    // TODO:+ duplication
                    (initCoordinateValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newUniformAccelMotion.Acceleration = Convert.ToDouble

                    // TODO:+ duplication
                    (accelerationValue.Text.ReplaceByComma());
                },
            };

            InputParameters(actions);

            return newUniformAccelMotion;
        }
    }
}
