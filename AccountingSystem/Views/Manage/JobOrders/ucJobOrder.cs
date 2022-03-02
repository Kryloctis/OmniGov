using AccountingSystem.Views.Manage.LinkUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.JobOrders
{
    public partial class ucJobOrder : UserControl
    {
        public ucJobOrder()
        {
            InitializeComponent();
        }

        private void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLinkUser frmLinkuser = new();
            frmLinkuser.table = "JO";

            if (frmLinkuser.ShowDialog() == DialogResult.OK)
            {
                //UserId = frmLinkuser.UserId;
                linkuser.Text = string.Format("@{0}", frmLinkuser.Username);
              
                txtPrefix.Text = frmLinkuser.prefix;
                txtLastName.Text = frmLinkuser.lname;
                txtFirstName.Text = frmLinkuser.fname;
                txtMiddleInitial.Text = frmLinkuser.mname;
                txtSuffix.Text = frmLinkuser.suffix;
            }
        }
    }
}
