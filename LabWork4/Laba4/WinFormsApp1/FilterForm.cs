using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Model;

namespace WinFormsApp1
{
    public partial class FilterForm : Form
    {
        private readonly Dictionary<string, Type> _motionTypes = new()
        {
            {nameof(UniformMotion), typeof(UniformMotion)},
            {nameof(UniformAccelMotion), typeof(UniformAccelMotion)},
            {nameof(OscilMotion), typeof(OscilMotion)}
        };

        private readonly Dictionary<string, string> _listBoxToMotionType;

        //private BindingList<MotionBase> motionListFilteredFromMain;

        //private BindingList<MotionBase> motionListFromMain;

        private DataGridView dataGrid;
        private BindingList<MotionBase> motionList;

        public FilterForm(DataGridView dataGridMain, BindingList<MotionBase> motionListMain)
        {   
            InitializeComponent();

            //motionListFilteredFromMain = motionList;

            //motionListFromMain = motionList;

            dataGrid = dataGridMain;
            motionList = motionListMain;

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
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(UpperBoundTextBox.Text) < Convert.ToDouble(LowerBoundTextBox.Text))
            {
                MessageBox.Show("Wrong range!");
            }
            else
            {
                var typeFilteredList = new BindingList<MotionBase>();

                foreach (var motion in motionList)
                {
                    foreach (var checkedMotion in MotionTypeCheckedListBox.CheckedItems)
                    {
                        if (motion.GetType() == _motionTypes[_listBoxToMotionType[checkedMotion.ToString()]])
                        {
                            typeFilteredList.Add(motion);
                        }
                    }
                }

                var valueFilteredList = new BindingList<MotionBase>();

                foreach (var motion in typeFilteredList)
                {
                    if (motion.Coordinate >= Convert.ToDouble(LowerBoundTextBox.Text) &&
                        motion.Coordinate <= Convert.ToDouble(UpperBoundTextBox.Text))
                    {
                        valueFilteredList.Add(motion);
                    }
                }

                dataGrid.DataSource = valueFilteredList;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = motionList;
        }
    }
}
