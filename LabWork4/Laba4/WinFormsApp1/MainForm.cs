using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private static BindingList<MotionBase> _motionList = new();

        public MainForm()
        {
            InitializeComponent();

            MotionDataGridView.DataSource = _motionList;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newInputForm = new InputForm(_motionList);

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
            var newFilterForm = new FilterForm(MotionDataGridView, _motionList);

            newFilterForm.Show();

            newFilterForm.Closed += (_, _) =>
            {
                FilterButton.Enabled = true;
            };

            FilterButton.Enabled = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog
            {
                Filter = "MotionCoordinate (*.mcrd)|*.mcrd"
            };

            fileBrowser.ShowDialog();

            var path = fileBrowser.FileName;

            var xmlSerializer = new XmlSerializer(typeof(BindingList<MotionBase>));

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            using (var file = File.Create(path))
            {
                xmlSerializer.Serialize(file, MotionDataGridView.DataSource);
                file.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog
            {
                Filter = "MotionCoordinate (*.mcrd)|*.mcrd"
            };

            fileBrowser.ShowDialog();

            var path = fileBrowser.FileName;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(BindingList<MotionBase>));

            var file = new StreamReader(path);

            _motionList = (BindingList<MotionBase>)xmlSerializer.Deserialize(file);

            MotionDataGridView.DataSource = _motionList;
        }
    }
}