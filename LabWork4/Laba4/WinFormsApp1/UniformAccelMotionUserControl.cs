using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class UniformAccelMotionUserControl : MotionBaseUserControl
    {
        public UniformAccelMotionUserControl()
        {
            InitializeComponent();
        }

        public override MotionBase GetMotion()
        {
            var newUniformAccelMotion = new UniformAccelMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    newUniformAccelMotion.Time = Convert.ToDouble(textBox1.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Speed = Convert.ToDouble(textBox2.Text);
                },

                () =>
                {
                    newUniformAccelMotion.InitCoordinate = Convert.ToDouble(textBox3.Text);
                },

                () =>
                {
                    newUniformAccelMotion.Acceleration = Convert.ToDouble(textBox4.Text);
                },
            };

            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newUniformAccelMotion;
        }
    }
}
