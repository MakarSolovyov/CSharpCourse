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
    public partial class OscilMotionUserControl : MotionBaseUserControl
    {
        public OscilMotionUserControl()
        {
            InitializeComponent();
        }

        public override MotionBase GetMotion()
        {
            var newOscilMotion = new OscilMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    newOscilMotion.Time = Convert.ToDouble(textBox1.Text);
                },

                () =>
                {
                    newOscilMotion.Amplitude = Convert.ToDouble(textBox2.Text);
                },

                () =>
                {
                    newOscilMotion.CyclFrequency = Convert.ToDouble(textBox3.Text);
                },

                () =>
                {
                    newOscilMotion.InitPhase = Convert.ToDouble(textBox4.Text);
                },
            };

            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newOscilMotion;
        }
    }
}
