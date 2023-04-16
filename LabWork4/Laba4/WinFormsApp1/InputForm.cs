using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WinFormsApp1
{
    public partial class InputForm : Form
    {
        private readonly Dictionary<string, UserControl> _comboBoxToUserControl;

        private readonly Dictionary<string, Func<MotionBase>> _comboBoxToMotion;

        public InputForm()
        {
            InitializeComponent();

            ComboBoxMotionTypes.Items.AddRange(new string[] { "Uniform", "Uniformly accelerated", "Oscillating" });
#if DEBUG
            AddRandomObjectButton.Visible = true;
#endif
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {"Uniform", uniformMotionUserControl1},
                {"Uniformly accelerated", uniformAccelMotionUserControl1},
                {"Oscillating", oscilMotionUserControl1}
            };

            _comboBoxToMotion = new Dictionary<string, Func<MotionBase>>()
            {
                {"Uniform", uniformMotionUserControl1.GetUniformMotion},
                {"Uniformly accelerated", uniformAccelMotionUserControl1.GetUniformAccelMotion},
                {"Oscillating", oscilMotionUserControl1.GetOscilMotion}
            };

            ComboBoxMotionTypes.SelectedIndexChanged += ComboBoxMotionTypes_SelectedIndexChanged;
        }

        private void ComboBoxMotionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = ComboBoxMotionTypes.SelectedItem.ToString();

            foreach (string motionType in _comboBoxToUserControl.Keys)
            {
                _comboBoxToUserControl[motionType].Visible = false;
                if (selectedState == motionType)
                {
                    _comboBoxToUserControl[motionType].Visible = true;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            foreach (var motionType in _comboBoxToMotion)
            {
                if (ComboBoxMotionTypes.SelectedItem.ToString() == motionType.Key)
                {
                    MainForm._motionList.Add(motionType.Value.Invoke());
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddRandomObjectButton_Click(object sender, EventArgs e)
        {
            var rnd = new Random();

            var randomType = rnd.Next(3);
            var randomMotion = new RandomMotionFactory();

            switch(randomType)
            {
                case 0:
                    MainForm._motionList.Add(randomMotion.GetInstance(MotionType.UniformMotion));
                    break;
                case 1:
                    MainForm._motionList.Add(randomMotion.GetInstance(MotionType.UniformAccelMotion));
                    break;
                case 2:
                    MainForm._motionList.Add(randomMotion.GetInstance(MotionType.OscilMotion));
                    break;
                default:
                    break;
            };
        }
    }
}
