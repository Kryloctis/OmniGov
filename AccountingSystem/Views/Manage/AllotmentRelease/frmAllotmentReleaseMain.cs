using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseMain : Form
    {
        internal ucAllotmentReleaseMain uc;

        public frmAllotmentReleaseMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            btnSave.Click += new EventHandler(BtnSave_Click);
            btnNew.Click += new EventHandler(BtnNew_Click);
            uc = ucAllotmentReleaseMain1;
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucAllotmentReleaseMain1;
                if (!uc.ValidateChildren() || uc.ShowErrorAllotmentReleaseListEmpty()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                    var allotmentReleaseModelList = new List<AllotmentReleaseModel>();

                    foreach (DataGridViewRow row in uc.dgAllotmentRelease.Rows)
                    {
                        var allotmentReleaseModel = new AllotmentReleaseModel()
                        {
                            BudgetAppropriationsID = Convert.ToInt32(row.Cells["budget_appropriation_id"].Value),
                            ARONumber = $"{uc.mskSeriesNo.Text}-{uc.mskYear.Text}",
                            Purpose = uc.txtPurpose.Text.Trim(),
                            DateIssued = uc.dtDateIssued.Value,
                            amount = Convert.ToDecimal(row.Cells["allotment_amount"].Value)
                        };

                    allotmentReleaseModelList.Add(allotmentReleaseModel);
                    }

                Factory.AllotmentReleaseRepository().BulkInsert(allotmentReleaseModelList);

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void UnsavedWorkPrompt()
        {
            var message = "Are you sure? Unsaved data will not be saved.";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uc.ResetForm();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment release has been saved.");
                uc.ResetForm();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) 
        {
            if (!uc.panel1.Enabled)
            {
                UnsavedWorkPrompt();
            }
        }
    }
}
