using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.Journals.DefaultAccounts;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Journals
{
    public partial class frmJournals : Form
    {
        public frmJournals()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        internal void LoadRecords()
        {
            HelperLoadRecords.JournalsDatagridView(dgJournals);
            lblRecordCount.Text = dgJournals.Rows.Count.ToString();
        }

        private void frmJournals_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            Helper.DatagridFullRowSelectStyle(dgJournals, true);
            LoadRecords();
        }

        private void dgJournals_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgJournals, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgJournals, btnEdit, btnDelete);
            int journalId = Convert.ToInt32(dgJournals.CurrentRow.Cells["id"].Value);
            if (journalId == 1) btnDefaultAccounts.Enabled = false;
            else btnDefaultAccounts.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmJournalsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int journalId = int.Parse(dgJournals.SelectedCells[0].Value.ToString());
            _ = new frmJournalsEdit(this, journalId).ShowDialog();
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgJournals.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var journalsModelList = new List<JournalsModel>();
                    foreach (DataGridViewRow row in dgJournals.SelectedRows)
                    {
                        int journalId = Convert.ToInt16(row.Cells[0].Value.ToString());
                        journalsModelList.Add(new JournalsModel() { Id = journalId });
                    }

                    return Factory.JournalsRepository().Delete(journalsModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteData())
                LoadRecords();
        }

        private void showDefaultAccounts()
        {
            var frmJournalDefaultAccounts = new frmDefaultAccounts();
            int journalId = Convert.ToInt32(dgJournals.CurrentRow.Cells["id"].Value);
            frmJournalDefaultAccounts.journalId = journalId;
            frmJournalDefaultAccounts.ShowDialog();
        }

        private void btnDefaultAccounts_Click(object sender, EventArgs e)
        {
            showDefaultAccounts();
        }
    }
}