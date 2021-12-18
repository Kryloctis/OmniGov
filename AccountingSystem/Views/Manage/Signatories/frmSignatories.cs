using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmSignatories : Form
    {
        public frmSignatories()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        internal void LoadSignatories()
        {
            try
            {
                var dtSignatories = Factory.SignatoriesRepository().GetRecords();

                HelperLoadRecords.SignatoriesDatagridView(dtSignatories, dgSignatories);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _ = new frmAddSignatories(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            int signatoriesId = Convert.ToInt32(dgSignatories.Rows[dgSignatories.CurrentRow.Index].Cells["id"].Value);

            var _frmEditSignatories = new frmEditSignatories(this);
            _frmEditSignatories.uc.signatoriesId = signatoriesId;
            _frmEditSignatories.ShowDialog();
        }

        private void EnableDisableButtons()
        {
            Helper.EnableDisableToolStripButtons(dgSignatories, btnEdit, btnDelete);

            if (dgSignatories.SelectedRows.Count < 1)
                btnDocumentReferences.Enabled = false;
            else
                btnDocumentReferences.Enabled = true;
        }

        private void dtSignatories_SelectionChanged(object sender, System.EventArgs e)
        {
            EnableDisableButtons();
        }

        private void frmSignatories_Load(object sender, System.EventArgs e)
        {
            EnableDisableButtons();
            LoadSignatories();
        }
    }
}
