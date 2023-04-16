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
            Program.mainForm = this;
            MotionDataGridView.DataSource = _motionList;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newInputForm = new InputForm();

            newInputForm.Show();

            newInputForm.Closed += (_, _) =>
            {
                AddButton.Enabled = true;
            };

            AddButton.Enabled = false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MotionDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in MotionDataGridView.SelectedCells)
                {
                    _motionList.Remove(cell.OwningRow.DataBoundItem as MotionBase);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _motionList.Clear();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            var newFilterForm = new FilterForm();

            newFilterForm.Show();

            newFilterForm.Closed += (_, _) =>
            {
                FilterButton.Enabled = true;
            };

            FilterButton.Enabled = false;
        }
    }
}