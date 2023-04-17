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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class UniformMotionUserControl : MotionBaseUserControl
    {
        public UniformMotionUserControl()
        {
            InitializeComponent();
        }

        public override MotionBase GetMotion()
        {
            var newUniformMotion = new UniformMotion();

            var actions = new List<Action>()
            {
                () =>
                {
                    newUniformMotion.Time = Convert.ToDouble(textBox1.Text);
                },

                () =>
                {
                    newUniformMotion.Speed = Convert.ToDouble(textBox2.Text);
                },

                () =>
                {
                    newUniformMotion.InitCoordinate = Convert.ToDouble(textBox3.Text);
                }
            };

            foreach (var action in actions)
            {
                action.Invoke();
            }

            return newUniformMotion;
        }
    }
}
