using System.ComponentModel;
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
        /// Dictionary of motion instances.
        /// </summary>
        private readonly Dictionary<string,
            Func<MotionBase>> _comboBoxToMotion;

        /// <summary>
        /// Field for link to MainForm _motionList object.
        /// </summary>
        private BindingList<MotionBase> _motionListMain;

        /// <summary>
        /// Input form instance constructor.
        /// </summary>
        /// <param name="motionList">MainForm _motionList object.</param>
        public InputForm(BindingList<MotionBase> motionList)
        {
            InitializeComponent();

            _motionListMain = motionList;
#if DEBUG
            AddRandomObjectButton.Visible = true;
#endif
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {"Uniform", uniformMotionUserControl1},
                {"Uniformly accelerated", uniformAccelMotionUserControl1},
                {"Oscillating", oscilMotionUserControl1}
            };

            ComboBoxMotionTypes.Items.AddRange(_comboBoxToUserControl.Keys.
                ToArray());

            // TODO:+ Можно создать базовый класс/интерфейс UserControl
            // с методом AddMotion
            _comboBoxToMotion = new Dictionary<string, Func<MotionBase>>()
            {
                {"Uniform", uniformMotionUserControl1.GetMotion},
                {"Uniformly accelerated", uniformAccelMotionUserControl1.
                    GetMotion},
                {"Oscillating", oscilMotionUserControl1.GetMotion}
            };

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
            string selectedState = ComboBoxMotionTypes.SelectedItem.
                ToString();

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
            foreach (var motionType in _comboBoxToMotion)
            {
                if (ComboBoxMotionTypes.SelectedItem.ToString() ==
                    motionType.Key)
                {
                    _motionListMain.Add(motionType.Value.Invoke());
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

            var randomType = rnd.Next(3);
            var randomMotion = new RandomMotionFactory();

            switch (randomType)
            {
                case 0:
                    _motionListMain.Add(randomMotion.GetInstance(MotionType.
                        UniformMotion));
                    break;
                case 1:
                    _motionListMain.Add(randomMotion.GetInstance(MotionType.
                        UniformAccelMotion));
                    break;
                case 2:
                    _motionListMain.Add(randomMotion.GetInstance(MotionType.
                        OscilMotion));
                    break;
                default:
                    break;
            }
        }
    }
}
