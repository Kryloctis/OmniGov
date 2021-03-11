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
    public partial class ucJEV : UserControl
    {
        internal int fundId;
        internal int journalId;

        public ucJEV()
        {
            InitializeComponent();
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton();
                radFund.Text = fund["fund_name"].ToString();
                radFund.Tag = fund["id"];
                radFund.AutoSize = true;
                radFund.Appearance = Appearance.Button;
                radFund.TextImageRelation = TextImageRelation.ImageBeforeText;
                
                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        internal void LoadJournals()
        {
            var journals = Factory.JournalsRepository().GetRecords();

            foreach (DataRow journal in journals.Rows)
            {
                var radJournal = new RadioButton();
                radJournal.Text = journal["journal_name"].ToString();
                radJournal.Tag = journal["id"];
                radJournal.AutoSize = true;
                radJournal.Appearance = Appearance.Button;
                radJournal.TextImageRelation = TextImageRelation.ImageBeforeText;

                flowLayoutPanelJournals.Controls.Add(radJournal);

                radJournal.Click += new EventHandler(radJournal_Click);
                radJournal.CheckedChanged += new EventHandler(radioJournals_CheckedChanged);
            }
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void radFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToInt32(radFund.Tag);
            ShowCheckIcon(radFund);
        }

        private void radJournal_Click(object sender, EventArgs e)
        {
            var radJournal = sender as RadioButton;
            journalId = Convert.ToInt32(radJournal.Tag);
            ShowCheckIcon(radJournal);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void radioJournals_CheckedChanged(object sender, EventArgs e)
        {
            var radJournal = sender as RadioButton;
            ShowCheckIcon(radJournal);
        }

        private void ucJEV_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgAccounts);
            LoadFunds();
            LoadJournals();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            _ = new frmJEVAccountAdd(this).ShowDialog();
        }
    }
}
