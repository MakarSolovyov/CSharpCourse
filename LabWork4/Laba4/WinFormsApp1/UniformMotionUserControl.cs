using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Class UniformMotionUserControl.
    /// </summary>
    public partial class UniformMotionUserControl : MotionBaseUserControl
    {
        /// <summary>
        /// UniformMotionUserControl instance constructor.
        /// </summary>
        public UniformMotionUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to get an Motion object.
        /// </summary>
        /// <returns>A MotionBase object.</returns>
        public override MotionBase GetMotion()
        {
            var newUniformMotion = new UniformMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    newUniformMotion.Time = Convert.ToDouble
                        (timeValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newUniformMotion.Speed = Convert.ToDouble
                        (speedValue.Text.ReplaceByComma());
                },

                () =>
                {
                    newUniformMotion.InitCoordinate = Convert.ToDouble
                        (initCoordinateValue.Text.ReplaceByComma());
                }
            };

            InputParameters(actions);

            return newUniformMotion;
        }
    }
}
