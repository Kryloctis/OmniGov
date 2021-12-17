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
    }
}
