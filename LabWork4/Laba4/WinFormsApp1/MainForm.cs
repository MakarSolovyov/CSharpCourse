using System.ComponentModel;
using Model;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public static BindingList<MotionBase> _motionList = new();

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Program.mainForm = this;
            MotionDataGridView.DataSource = _motionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MotionDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in 
                    MotionDataGridView.SelectedRows)
                {
                    _motionList.Remove(row.DataBoundItem as MotionBase);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _motionList.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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