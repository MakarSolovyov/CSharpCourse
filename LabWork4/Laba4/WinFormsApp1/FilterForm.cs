using System.ComponentModel;
using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Class of the filter form.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Dictionary of motion types.
        /// </summary>
        private readonly Dictionary<string, Type> _motionTypes = new()
        {
            {nameof(UniformMotion), typeof(UniformMotion)},
            {nameof(UniformAccelMotion), typeof(UniformAccelMotion)},
            {nameof(OscilMotion), typeof(OscilMotion)}
        };

        /// <summary>
        /// Dictionary of motion type names.
        /// </summary>
        private readonly Dictionary<string, string> _listBoxToMotionType;

        /// <summary>
        /// Field for link to MainForm DataGridView object.
        /// </summary>
        private DataGridView _dataGrid;

        /// <summary>
        /// Field for link to MainForm _motionList object.
        /// </summary>
        private BindingList<MotionBase> _motionList;

        /// <summary>
        /// Filter form instance constructor.
        /// </summary>
        /// <param name="dataGridMain">MainForm DataGridView object.</param>
        /// <param name="motionListMain">MainForm _motionList object.</param>
        public FilterForm(DataGridView dataGridMain,
            BindingList<MotionBase> motionListMain)
        {
            InitializeComponent();

            _dataGrid = dataGridMain;
            _motionList = motionListMain;

            _listBoxToMotionType = new Dictionary<string, string>()
            {
                {"Uniform", "UniformMotion"},
                {"Uniformly accelerated", "UniformAccelMotion"},
                {"Oscillating", "OscilMotion" }
            };

            MotionTypeCheckedListBox.Items.AddRange(
                new string[] {
                    "Uniform", "Uniformly accelerated", "Oscillating"
                });

            UpperBoundTextBox.Text = "0";
            LowerBoundTextBox.Text = "0";
        }

        /// <summary>
        /// Click event to filter information in DataGrid.
        /// </summary>
        /// <param name="sender">FilterButton.</param>
        /// <param name="e">Event argument.</param>
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var action = new List<Action<BindingList<MotionBase>>>
            {
                new Action<BindingList<MotionBase>>
                ((BindingList<MotionBase> typeFilteredList) =>
                {
                    foreach (var motion in _motionList)
                    {
                        foreach (var checkedMotion in
                            MotionTypeCheckedListBox.CheckedItems)
                        {
                            if (motion.GetType() == _motionTypes
                            [_listBoxToMotionType
                            [checkedMotion.ToString()]])
                            {
                                typeFilteredList.Add(motion);
                            }
                        }
                    }
                })
            };

            if ((Convert.ToDouble(UpperBoundTextBox.Text) <=
                Convert.ToDouble(LowerBoundTextBox.Text)) &&
                LowerBoundTextBox.Text != "0")
            {
                _ = MessageBox.Show("Wrong range!");
            }
            else if (UpperBoundTextBox.Text == "0" &&
                LowerBoundTextBox.Text == "0")
            {
                var typeFilteredList = new BindingList<MotionBase>();

                action[0].Invoke(typeFilteredList);

                _dataGrid.DataSource = typeFilteredList;
            }
            else
            {
                var typeFilteredList = new BindingList<MotionBase>();

                action[0].Invoke(typeFilteredList);

                var valueFilteredList = new BindingList<MotionBase>();

                foreach (var motion in typeFilteredList)
                {
                    if (motion.Coordinate >= Convert.ToDouble
                        (LowerBoundTextBox.Text) &&
                        motion.Coordinate <= Convert.ToDouble
                        (UpperBoundTextBox.Text))
                    {
                        valueFilteredList.Add(motion);
                    }
                }

                _dataGrid.DataSource = valueFilteredList;
            }
        }

        /// <summary>
        /// Click event to reset information in DataGrid to initial values.
        /// </summary>
        /// <param name="sender">ResetButton.</param>
        /// <param name="e">Event argument.</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            _dataGrid.DataSource = _motionList;
        }
    }
}
