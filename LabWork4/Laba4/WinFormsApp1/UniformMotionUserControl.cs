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
                    (textBox1.Text);
                },

                () =>
                {
                    newUniformMotion.Speed = Convert.ToDouble
                    (textBox2.Text);
                },

                () =>
                {
                    newUniformMotion.InitCoordinate = Convert.ToDouble
                    (textBox3.Text);
                }
            };

            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newUniformMotion;
        }
    }
}
