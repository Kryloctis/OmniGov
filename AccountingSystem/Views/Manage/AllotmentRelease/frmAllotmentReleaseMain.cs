using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseMain : Form
    {
        public frmAllotmentReleaseMain()
        {
            InitializeComponent();
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            Helper.LoadFormIcon(this);
        }
    }
}
