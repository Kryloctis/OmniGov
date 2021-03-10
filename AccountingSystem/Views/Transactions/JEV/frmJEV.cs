using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        public frmJEV()
        {
            InitializeComponent();
        }

        private void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radButtons = new RadioButton();
                radButtons.Text = fund["fund_name"].ToString();
                radButtons.Tag = fund["id"];

                flowLayoutPanelFunds.Controls.Add(radButtons);
            }
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
            LoadFunds();
        }
    }
}
