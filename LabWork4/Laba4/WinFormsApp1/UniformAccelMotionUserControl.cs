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
                    (textBox1.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Speed = Convert.ToDouble
                    (textBox2.Text);
                },

                () =>
                {
                    newUniformAccelMotion.InitCoordinate = Convert.ToDouble
                    (textBox3.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Acceleration = Convert.ToDouble
                    (textBox4.Text);
                },
            };

            //TODO: duplication
            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newUniformAccelMotion;
        }
    }
}
