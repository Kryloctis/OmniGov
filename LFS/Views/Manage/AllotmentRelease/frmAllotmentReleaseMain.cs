using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.AllotmentRelease
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

        internal void LoadSelected()
        {
            try
            {
                var dtAllotmentRelease = AccFactory.AllotmentReleaseRepository().GetViewRecordsById(uc.allotmentReleaseId);
                int fppId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["function_program_project_id"]);
                string subFPPId = dtAllotmentRelease.Rows[0]["others_fpp_id"].ToString();
                int fundId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["funds_id"]);
                int allotmentClassId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["allotment_classes_id"]);
                string aroNo = dtAllotmentRelease.Rows[0]["aro_no"].ToString();
                var dateIssued = Convert.ToDateTime(dtAllotmentRelease.Rows[0]["date_issued"]);
                string purpose = dtAllotmentRelease.Rows[0]["purpose"].ToString();

                uc.cmbxFPP.SelectedValue = fppId;
                uc.cmbxSubFPP.SelectedValue = string.IsNullOrEmpty(subFPPId) ? 0 : Convert.ToInt32(subFPPId);
                uc.CheckedFund(fundId);
                uc.CheckedAllotmentClass(allotmentClassId);
                uc.mskSeriesNo.Text = aroNo;
                uc.dtDateIssued.Value = dateIssued;
                uc.txtPurpose.Text = purpose;

                uc.dgAllotmentRelease.Rows.Clear();

                uc.panel1.Enabled = false;
                uc.dtDateIssued.Enabled = false;

                foreach (DataRow row in dtAllotmentRelease.Rows)
                {
                    short year = Convert.ToInt16(row["year"]);
                    int budgetAppropriationId = Convert.ToInt32(row["budget_appropriations_id"]);
                    string accountName = row["ledger_name"].ToString();
                    string accountCode = row["account_code"].ToString();
                    string remarks = row["remarks"].ToString();
                    decimal amount = Convert.ToDecimal(row["amount"]);
                    string fullAccountName = $"{accountName} {(string.IsNullOrEmpty(remarks) ? string.Empty : $"({remarks})")}";

                    var records = new object[]
                    {
                        year,
                        budgetAppropriationId,
                        fullAccountName,
                        accountCode,
                        amount
                    };

                    uc.dgAllotmentRelease.Rows.Add(records);
                }

                btnDelete.Enabled = true;
                btnSave.Text = "Update";
                uc.isEdit = true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
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
                string allotmentReleaseNo = uc.mskSeriesNo.Text;
                string purpose = uc.txtPurpose.Text.Trim();

                var allotmemtReleaseModel = new AllotmentReleaseModel()
                {
                    ARONumber = allotmentReleaseNo,
                    Purpose = purpose,
                    DateIssued = uc.dtDateIssued.Value
                };

                return AccFactory.AllotmentReleaseRepository().Insert(allotmemtReleaseModel, AllotmentAccountModelList());
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
                string allotmentReleaseNo = uc.mskSeriesNo.Text;
                string purpose = uc.txtPurpose.Text.Trim();

                var allotmemtReleaseModel = new AllotmentReleaseModel()
                {
                    ID = uc.allotmentReleaseId,
                    ARONumber = allotmentReleaseNo,
                    Purpose = purpose,
                    DateIssued = uc.dtDateIssued.Value
                };

                return AccFactory.AllotmentReleaseRepository().Update(allotmemtReleaseModel, AllotmentAccountModelList());
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

                if (!uc.isEdit)
                    return saveData = InsertData();
                else
                    return saveData = UpdateData();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                string message = uc.allotmentReleaseId == 0 ? "saved" : "updated";
                Helper.MessageBoxSuccess($"Allotment release has been {message}.");
                uc.ResetForm();
                btnSave.Text = "Save";
            }
        }

        private void CanceAction()
        {
            var message = "Are you sure? Changes will not be saved.";
            if (uc.allotmentReleaseId > 0 || uc.dgAllotmentRelease.Rows.Count > 0)
            {
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    uc.ResetForm();
                    btnDelete.Enabled = false;
                    btnSave.Text = "Save";
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CanceAction();
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
                    return AccFactory.AllotmentReleaseRepository().Delete(uc.allotmentReleaseId);
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