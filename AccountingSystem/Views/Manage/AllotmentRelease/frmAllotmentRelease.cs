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
    public partial class frmAllotmentRelease : Form
    {
        private MainForm _MainForm;
        public frmAllotmentRelease(MainForm mainForm)
        {
            InitializeComponent();
            _MainForm = mainForm;
            btnAdd.Click += new EventHandler(btnAdd_Click);
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            _ = new frmAllotmentReleaseAdd(this).ShowDialog(); ;
        }
    }
}
