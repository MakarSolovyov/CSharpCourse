using System.ComponentModel;
using System.Xml.Serialization;
using Model;

namespace WinFormsApp1
{
    /// <summary>
    /// Class of the main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// List of MotionBase objects.
        /// </summary>
        private BindingList<MotionBase> _motionList = new();

        /// <summary>
        /// List of MotionBase objects, created by filter.
        /// </summary>
        private BindingList<MotionBase> _filteredList = new();

        /// <summary>
        /// Main form instance constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            var source = new BindingSource(_motionList, null);
            MotionDataGridView.DataSource = source;
        }

        /// <summary>
        /// Click event to add an MotionBase object to the list.
        /// </summary>
        /// <param name="sender">AddButton.</param>
        /// <param name="e">Event argument.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var newInputForm = new InputForm();

            newInputForm.Show();

            newInputForm.MotionAdded += (_, args) =>
            {
                _motionList.Add(args.Motion);

                MotionDataGridView.DataSource = _motionList;
            };

            newInputForm.Closed += (_, _) =>
            {
                AddButton.Enabled = true;
            };

            AddButton.Enabled = false;
        }

        /// <summary>
        /// Click event to remove an MotionBase object from the list.
        /// </summary>
        /// <param name="sender">RemoveButton.</param>
        /// <param name="e">Event argument.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MotionDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in
                    MotionDataGridView.SelectedRows)
                {
                    // BUG+
                    _ = _motionList.Remove(row.DataBoundItem as MotionBase);

                    _ = _filteredList.Remove(row.DataBoundItem as MotionBase);
                }
            }
        }

        /// <summary>
        /// Click event to remove all MotionBase objects from the list.
        /// </summary>
        /// <param name="sender">ClearButton.</param>
        /// <param name="e">Event argument.</param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _motionList.Clear();
            _filteredList.Clear();
        }

        /// <summary>
        /// Click event to filter MotionBase objects from the list.
        /// </summary>
        /// <param name="sender">FilterButton.</param>
        /// <param name="e">Event argument.</param>
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var newFilterForm = new FilterForm();

            newFilterForm.MotionListMain = _motionList;

            newFilterForm.Show();

            newFilterForm.MotionListFiltered += (_, args) =>
            {
                MotionDataGridView.DataSource = args.MotionListFiltered;
                _filteredList = args.MotionListFiltered;
            };

            newFilterForm.Closed += (_, _) =>
            {
                FilterButton.Enabled = true;
            };

            FilterButton.Enabled = false;
        }

        /// <summary>
        /// Click event to save MotionBase objects from the list in file.
        /// </summary>
        /// <param name="sender">SaveToolStripMenuItem.</param>
        /// <param name="e">Event argument.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog
            {
                Filter = "MotionCoordinate (*.mcrd)|*.mcrd"
            };

            _ = fileBrowser.ShowDialog();

            var path = fileBrowser.FileName;

            var xmlSerializer = new XmlSerializer
                (typeof(BindingList<MotionBase>));

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

        /// <summary>
        /// Click event to load MotionBase objects from the file.
        /// </summary>
        /// <param name="sender">LoadToolStripMenuItem.</param>
        /// <param name="e">Event argument.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog
            {
                Filter = "MotionCoordinate (*.mcrd)|*.mcrd"
            };

            _ = fileBrowser.ShowDialog();

            var path = fileBrowser.FileName;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var xmlSerializer = new XmlSerializer
                (typeof(BindingList<MotionBase>));

            // BUG+ при загрузке повреждённого файла
            try
            {
                using (var file = new StreamReader(path))
                {
                    _motionList = (BindingList<MotionBase>)xmlSerializer.Deserialize(file);
                }

                MotionDataGridView.DataSource = _motionList;
            }
            catch (Exception exception)
            {
                if (exception.GetType() ==
                    typeof(InvalidOperationException))
                {
                    _ = MessageBox.Show("File upload error.");
                }
                else if (exception.GetType() ==
                    typeof(ArgumentException))
                {
                    _ = MessageBox.Show("The data structure of the " +
                        "uploaded file is broken.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
