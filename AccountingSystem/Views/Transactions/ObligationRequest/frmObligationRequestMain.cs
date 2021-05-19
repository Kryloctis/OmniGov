using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestMain : Form
    {
        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnSave.Click += new EventHandler(BtnSave_Click);
            btnDelete.Click += new EventHandler(BtnDelete_Click);
            btnCancel.Click += new EventHandler(BtnCancel_CLick);
            btnSearch.Click += new EventHandler(BtnSearch_Click);
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_CLick(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}
