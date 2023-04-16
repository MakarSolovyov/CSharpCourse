using System.ComponentModel;
using Model;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public static BindingList<MotionBase> _motionList = new();

        public MainForm()
        {
            InitializeComponent();

            MotionDataGridView.DataSource = _motionList;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newInputForm = new InputForm();

            newInputForm.Show();

            MotionDataGridView.DataSource = _motionList;

            newInputForm.Closed += (_, _) =>
            {
                AddButton.Enabled = true;
            };

            AddButton.Enabled = false;
        }
    }
}