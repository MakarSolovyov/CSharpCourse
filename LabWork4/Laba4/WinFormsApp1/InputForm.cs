using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Class of the input form.
    /// </summary>
    public partial class InputForm : Form
    {
        /// <summary>
        /// Dictionary of motion user controls.
        /// </summary>
        private readonly Dictionary<string,
            UserControl> _comboBoxToUserControl;

        /// <summary>
        /// Handler to event of adding motion.
        /// </summary>
        private EventHandler<MotionEventArgs> _motionAdded;

        /// <summary>
        /// EventHandler _motionAdded field's property.
        /// </summary>
        public EventHandler<MotionEventArgs> MotionAdded
        {
            get => _motionAdded;
            set => _motionAdded = value;
        }

        /// <summary>
        /// Input form instance constructor.
        /// </summary>
        /// <param name="motionList">MainForm _motionList object.</param>
        public InputForm()
        {
            InitializeComponent();
#if DEBUG
            AddRandomObjectButton.Visible = true;
#endif
            string[] motionTypes = { "Uniform", "Uniformly accelerated",
                "Oscillating" };

            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {motionTypes[0], uniformMotionUserControl1},
                {motionTypes[1], uniformAccelMotionUserControl1},
                {motionTypes[2], oscilMotionUserControl1}
            };

            ComboBoxMotionTypes.Items.AddRange(motionTypes);

            ComboBoxMotionTypes.SelectedIndexChanged +=
                ComboBoxMotionTypes_SelectedIndexChanged;
        }

        /// <summary>
        /// Click event to check changes in ComboBox.
        /// </summary>
        /// <param name="sender">ComboBoxMotionTypes.</param>
        /// <param name="e">Event argument.</param>
        private void ComboBoxMotionTypes_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            string selectedState =
                ComboBoxMotionTypes.SelectedItem.ToString();

            foreach (var (motionType, userControl) in
                _comboBoxToUserControl)
            {
                userControl.Visible = false;
                if (selectedState == motionType)
                {
                    userControl.Visible = true;
                }
            }
        }

        /// <summary>
        /// Click event to add a new motion object.
        /// </summary>
        /// <param name="sender">OKButton.</param>
        /// <param name="e">Event argument.</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboBoxMotionTypes.Text.ToString()))
            {
                Close();
            }
            else
            {
                try
                {
                    var chosenMotion =
                        ComboBoxMotionTypes.SelectedItem.ToString();
                    var chosenMotionControl =
                        _comboBoxToUserControl[chosenMotion];
                    var eventArgs = new MotionEventArgs
                        (((MotionBaseUserControl)chosenMotionControl).GetMotion());

                    MotionAdded?.Invoke(this, eventArgs);
                }
                catch (Exception exception)
                {
                    if (exception.GetType() == typeof
                        (ArgumentOutOfRangeException) ||
                        exception.GetType() == typeof
                        (FormatException))
                    {
                        _ = MessageBox.Show
                            ($"Incorrect input parameters.\n" +
                            $"Error: {exception.Message}");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Click event to close the form.
        /// </summary>
        /// <param name="sender">CancelButton.</param>
        /// <param name="e">Event argument.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Click event to add a random motion object.
        /// </summary>
        /// <param name="sender">AddRandomObjectButton.</param>
        /// <param name="e">Event argument.</param>
        private void AddRandomObjectButton_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var motionTypes = new Dictionary<int, MotionType>
            {
                {0, MotionType.UniformMotion },
                {1, MotionType.UniformAccelMotion },
                {2, MotionType.OscilMotion }
            };
            var randomType = rnd.Next(motionTypes.Count);
            var randomMotion =
                new RandomMotionFactory()
                    .GetInstance(motionTypes[randomType]);

            var eventArgs = new MotionEventArgs(randomMotion);
            MotionAdded?.Invoke(this, eventArgs);
        }
    }
}
