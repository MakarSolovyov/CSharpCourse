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
        /// EventHandler _motionListFiltered field's property.
        /// </summary>
        public EventHandler<MotionEventArgsList> MotionListFiltered { get; set; }

        /// <summary>
        /// Property for link to MainForm _motionList object.
        /// </summary>
        public BindingList<MotionBase> MotionListMain { get; set; }

        /// <summary>
        /// Filter form instance constructor.
        /// </summary>
        public FilterForm()
        {
            InitializeComponent();

            _listBoxToMotionType = new Dictionary<string, string>()
            {
                {"Uniform", nameof(UniformMotion)},
                {"Uniformly accelerated", nameof(UniformAccelMotion)},
                {"Oscillating", nameof(OscilMotion) }
            };

            MotionTypeCheckedListBox.Items.AddRange
                (_listBoxToMotionType.Keys.ToArray());
        }

        /// <summary>
        /// Click event to filter information in DataGrid.
        /// </summary>
        /// <param name="sender">FilterButton.</param>
        /// <param name="e">Event argument.</param>
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var valueFilteredList = new BindingList<MotionBase>();
            var typeFilteredList = new BindingList<MotionBase>();

            var upperBoundFilled = double.TryParse(
                UpperBoundTextBox.Text.ReplaceByComma(),
                out double upperBound);
            var lowerBoundFilled = double.TryParse(
                LowerBoundTextBox.Text.ReplaceByComma(),
                out double lowerBound);

            var action = new List<Action<BindingList<MotionBase>>>
            {
                typeFilteredList =>
                {
                    foreach (var motion in MotionListMain)
                    {
                        foreach (var checkedMotion in
                                 MotionTypeCheckedListBox.CheckedItems)
                        {
                            if (motion.GetType() ==
                                _motionTypes[_listBoxToMotionType[checkedMotion.ToString()]])
                            {
                                typeFilteredList.Add(motion);
                            }
                        }
                    }
                },

                typeFilteredList =>
                {
                    foreach (var motion in typeFilteredList)
                    {
                        if (motion.Coordinate >= upperBound
                            && motion.Coordinate <= lowerBound)
                        {
                            valueFilteredList.Add(motion);
                        }
                    }
                }
            };

            if (string.IsNullOrEmpty(UpperBoundTextBox.Text) &&
                string.IsNullOrEmpty(LowerBoundTextBox.Text))
            {
                if (MotionTypeCheckedListBox.SelectedItems.Count == 0)
                {
                    Close();
                }
                else
                {
                    action[0].Invoke(typeFilteredList);

                    var eventArgs = new MotionEventArgsList(typeFilteredList);
                    MotionListFiltered?.Invoke(this, eventArgs);
                }
            }
            else if (!upperBoundFilled || !lowerBoundFilled)
            {
                _ = MessageBox.Show("Check range parameters!");
            }
            else
            {
                if (upperBound <= lowerBound)
                {
                    _ = MessageBox.Show("Wrong range!");
                }
                else
                {
                    if (MotionTypeCheckedListBox.SelectedItems.Count == 0)
                    {
                        typeFilteredList = MotionListMain;
                        action[1].Invoke(typeFilteredList);
                    }
                    else
                    {
                        action[0].Invoke(typeFilteredList);
                        action[1].Invoke(typeFilteredList);
                    }

                    var eventArgs = new MotionEventArgsList
                        (valueFilteredList);
                    MotionListFiltered?.Invoke(this, eventArgs);
                }
            }
        }

        /// <summary>
        /// Click event to reset information in DataGrid to initial values.
        /// </summary>
        /// <param name="sender">ResetButton.</param>
        /// <param name="e">Event argument.</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            var eventArgs = new MotionEventArgsList(MotionListMain);
            MotionListFiltered?.Invoke(this, eventArgs);
        }
    }
}
