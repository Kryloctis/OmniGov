using AccountingSystem.Views.Manage.LinkUser;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.JobOrders
{
    public partial class ucJobOrder : UserControl
    {
        internal int users_id;

        public ucJobOrder()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            users_id = 0;
            txtPrefix.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            txtSuffix.Clear();
            linkuser.Text = "+ Link User";
            txtJobtitle.Text = "Collecting Officer (JO)";
        }

        private void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLinkUser frmLinkuser = new();
            frmLinkuser.userType = "JO";

            if (frmLinkuser.ShowDialog() == DialogResult.OK)
            {
                linkuser.Text = string.Format("@{0}", frmLinkuser.Username);

                users_id = frmLinkuser.UserId;
                txtPrefix.Text = frmLinkuser.prefix;
                txtLastName.Text = frmLinkuser.lastName;
                txtFirstName.Text = frmLinkuser.firstName;
                txtMiddleInitial.Text = frmLinkuser.middleInitial;
                txtSuffix.Text = frmLinkuser.suffix;
            }
        }

        private void ucJobOrder_Load(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}