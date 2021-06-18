using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using MySql.Data.MySqlClient;
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
            uc = ucAllotmentReleaseMain1;
            btnDelete.Enabled = false;
        }

        private List<AllotmentAccountModel> AllotmentAccountModelList()
        {
            var allotmentAccountModelList = new List<AllotmentAccountModel>();

            foreach (DataGridViewRow row in uc.dgAllotmentRelease.Rows) 
            {
                int budgetAppropriationsId = Convert.ToInt32(row.Cells["budget_appropriation_id"].Value);
                decimal allotmentReleaseAmount = Convert.ToDecimal(row.Cells["allotment_amount"].Value);

                var allotmentAccountModel = new AllotmentAccountModel()
                {
                    BudgetAppropriationsID = budgetAppropriationsId,
                    Amount = allotmentReleaseAmount
                };

                allotmentAccountModelList.Add(allotmentAccountModel);
            }

            return allotmentAccountModelList;
        }


        private bool InsertData() 
        {
            try
            {
                string allotmentReleaseNo = $"{uc.mskSeriesNo.Text}-{uc.mskYear.Text}";
                string purpose = uc.txtPurpose.Text.Trim();

                var allotmemtReleaseModel = new AllotmentReleaseModel()
                {
                    ARONumber = allotmentReleaseNo,
                    Purpose = purpose,
                    DateIssued = uc.dtDateIssued.Value
                };

                return Factory.AllotmentReleaseRepository().Insert(allotmemtReleaseModel, AllotmentAccountModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool UpdateData() 
        {
            try
            {
                string allotmentReleaseNo = $"{uc.mskSeriesNo.Text}-{uc.mskYear.Text}";
                string purpose = uc.txtPurpose.Text.Trim();

                var allotmemtReleaseModel = new AllotmentReleaseModel()
                {
                    ID = uc.allotmentReleaseId,
                    ARONumber = allotmentReleaseNo,
                    Purpose = purpose,
                    DateIssued = uc.dtDateIssued.Value
                };


                return Factory.AllotmentReleaseRepository().Update(allotmemtReleaseModel, AllotmentAccountModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private bool SaveData() 
        {
            try
            {
                bool saveData;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.allotmentReleaseId == 0)
                    saveData = InsertData();
                else
                    saveData = UpdateData();

                return saveData;
            }
            catch (MySqlException mysqlex)
            {
                Helper.MessageBoxError(mysqlex.Message);
            }

            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void Prompt()
        {
            var message = "Are you sure? Unsaved data will not be saved.";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uc.ResetForm();
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment release has been saved.");
                uc.ResetForm();
                btnSave.Text = "Save";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) 
        {
            if (!uc.panel1.Enabled)
            {
                Prompt();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseSearch(this).ShowDialog();
        }


        private bool Delete() 
        {
            try
            {
                if (Helper.MessageBoxConfirmDelete(1))
                {
                    return Factory.AllotmentReleaseRepository().Delete(uc.allotmentReleaseId);
                }
            }
            catch (MySqlException ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete()) 
            {
                Helper.MessageBoxSuccess($"Allotment Release records has been deleted.");
                uc.ResetForm();
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
            }
        }
    }
}
