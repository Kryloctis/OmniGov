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
    public partial class ucAllotmentReleaseMain : UserControl
    {
        private int fundId = 0;
        private int allotmentClassId = 0;

        public ucAllotmentReleaseMain()
        {
            InitializeComponent();
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                if (Convert.ToInt32(fund["id"]) == 1)
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    ShowCheckIcon(radFund);
                }


                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        internal void LoadAllotmentClasses()
        {
            var allotmentClasses = Factory.AllotmentClassesRepository().GetRecords();

            foreach (DataRow allotmentClass in allotmentClasses.Rows)
            {
                var radAllotmentClass = new RadioButton
                {
                    Text = allotmentClass["allotment_code"].ToString(),
                    Tag = allotmentClass["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                if (Convert.ToInt32(allotmentClass["id"]) == 1)
                {
                    radAllotmentClass.Checked = true;
                    allotmentClassId = Convert.ToByte(allotmentClass["id"]);
                    ShowCheckIcon(radAllotmentClass);
                }

                flowLayoutPanelAllotmentClass.Controls.Add(radAllotmentClass);

                radAllotmentClass.Click += new EventHandler(RadioAllotmentClass_Click);
                radAllotmentClass.CheckedChanged += new EventHandler(RadioAllotmentClass_CheckedChanged);
            }
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void radioFunds_Click(object sender, EventArgs e) 
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToInt32(radFund.Tag);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void RadioAllotmentClass_Click(object sender, EventArgs e) 
        {
            var radAllotmentClass = sender as RadioButton;
            allotmentClassId = Convert.ToInt32(radAllotmentClass.Tag);
        }

        private void RadioAllotmentClass_CheckedChanged(object sender, EventArgs e) 
        {
            var radAllotmentClass = sender as RadioButton;
            ShowCheckIcon(radAllotmentClass);
        }

        private void dtDateIssued_ValueChanged(object sender, EventArgs e)
        {
            mskYear.Text = dtDateIssued.Value.Year.ToString();
        }

        private void ucAllotmentReleaseMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadFunds();
                LoadAllotmentClasses();
                mskYear.Text = dtDateIssued.Value.Year.ToString();
                Helper.DatagridDefaultStyle(dataGridView1, true);
            }
        }
    }
}
