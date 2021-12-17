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

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _ = new frmAddSignatories().ShowDialog();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            _ = new frmEditSignatories().ShowDialog();
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
        }
    }
}
