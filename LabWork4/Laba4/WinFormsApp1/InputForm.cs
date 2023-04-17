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

        private BindingList<MotionBase> motionListMain;

        public InputForm(BindingList<MotionBase> motionList)
        {
            InitializeComponent();

            motionListMain = motionList;
#if DEBUG
            AddRandomObjectButton.Visible = true;
#endif
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {"Uniform", uniformMotionUserControl1},
                {"Uniformly accelerated", uniformAccelMotionUserControl1},
                {"Oscillating", oscilMotionUserControl1}
            };

            ComboBoxMotionTypes.Items.AddRange(_comboBoxToUserControl.Keys.ToArray());

            // TODO:+ Можно создать базовый класс/интерфейс UserControl с методом AddMotion 
            _comboBoxToMotion = new Dictionary<string, Func<MotionBase>>()
            {
                {"Uniform", uniformMotionUserControl1.GetMotion},
                {"Uniformly accelerated", uniformAccelMotionUserControl1.GetMotion},
                {"Oscillating", oscilMotionUserControl1.GetMotion}
            };

            ComboBoxMotionTypes.SelectedIndexChanged += ComboBoxMotionTypes_SelectedIndexChanged;
        }

        private void ComboBoxMotionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = ComboBoxMotionTypes.SelectedItem.ToString();

            foreach (var (motionType, userControl) in _comboBoxToUserControl)
            {
                userControl.Visible = false;
                if (selectedState == motionType)
                {
                    userControl.Visible = true;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            foreach (var motionType in _comboBoxToMotion)
            {
                if (ComboBoxMotionTypes.SelectedItem.ToString() == motionType.Key)
                {
                    motionListMain.Add(motionType.Value.Invoke());
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
                    motionListMain.Add(randomMotion.GetInstance(MotionType.UniformMotion));
                    break;
                case 1:
                    motionListMain.Add(randomMotion.GetInstance(MotionType.UniformAccelMotion));
                    break;
                case 2:
                    motionListMain.Add(randomMotion.GetInstance(MotionType.OscilMotion));
                    break;
                default:
                    break;
            };
        }
    }
}
