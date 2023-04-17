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
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, Type> _motionTypes = new()
        {
            {nameof(UniformMotion), typeof(UniformMotion)},
            {nameof(UniformAccelMotion), typeof(UniformAccelMotion)},
            {nameof(OscilMotion), typeof(OscilMotion)}
        };

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, string> _listBoxToMotionType;

        /// <summary>
        /// 
        /// </summary>
        public FilterForm()
        {   
            InitializeComponent();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(UpperBoundTextBox.Text) 
                < Convert.ToDouble(LowerBoundTextBox.Text))
            {
                MessageBox.Show("Wrong range!");
            }
            else
            {
                var typeFilteredList = new BindingList<MotionBase>();

                foreach (var motion in MainForm._motionList)
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

                Program.mainForm.MotionDataGridView.DataSource = valueFilteredList;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Program.mainForm.MotionDataGridView.DataSource = MainForm._motionList;
        }
    }
}
