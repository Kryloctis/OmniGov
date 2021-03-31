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
    public partial class frmSelectAllotmentRelease : Form
    {
        private ucObligationRequest _ucObligationRequest;
        public frmSelectAllotmentRelease(ucObligationRequest ucObligationRequest)
        {
            InitializeComponent();
            _ucObligationRequest = ucObligationRequest;
            toolStripCmbxFunds.ComboBox.SelectedValueChanged += new EventHandler(toolStripCmbxFunds_SelectedValueChanged);
            toolStripCmbxAllotmentClass.ComboBox.SelectedValueChanged += new EventHandler(toolStripCmbxAllotmentClass_SelectedValueChanged);
            toolStripCmbxYear.ComboBox.SelectedValueChanged += new EventHandler(toolStripCmbxYear_SelectedValueChanged);
        }

        internal void LoadAllotmentReleaseRecords()
        {
            int dgFPPRowCount = dgFPP.SelectedRows.Count;

            if (dgFPPRowCount > 0) 
            {
                int fppID = Convert.ToInt32(dgFPP.SelectedCells[0].Value);
                int allotmentClassID = Convert.ToInt32(toolStripCmbxAllotmentClass.ComboBox.SelectedValue);
                int typeOfFundID = Convert.ToInt32(toolStripCmbxFunds.ComboBox.SelectedValue);
                short year = Convert.ToInt16(toolStripCmbxYear.ComboBox.SelectedValue);

                HelperLoadRecords.AllotmentReleaseDgvObligationRequest(dgAllotmentRelease, fppID, allotmentClassID, typeOfFundID, year);
            }
        }

        internal void LoadComboboxes()
        {
            try
            {
                HelperLoadRecords.AllomentToolStripCmbx(Factory.AllotmentClassesRepository().GetRecords(), toolStripCmbxAllotmentClass, "allotment_code", "id");
                HelperLoadRecords.TypeOfFundsToolStripCmbx(Factory.FundsRepository().GetRecords(), toolStripCmbxFunds, "fund_name", "id");
                HelperLoadRecords.YearToolStripCmbx(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), toolStripCmbxYear, "year", "year");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void EnableDisableButtonsLocal() 
        {
            int selectedRowsCount = dgAllotmentRelease.SelectedRows.Count;

            if (selectedRowsCount == 1 && dgAllotmentRelease.SelectedCells[7].Value != null)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void LoadSelectedRecord() 
        {
            int rowIndex = dgAllotmentRelease.CurrentCell.RowIndex;
            int fundID = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["fund_id"].Value);
            int fppID = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["fpp_id"].Value);
            int? othersFPPID = string.IsNullOrEmpty(dgAllotmentRelease.Rows[rowIndex].Cells["others_fpp_id"].Value.ToString()) ? null : Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["others_fpp_id"].Value);
            int allotmentClassID = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["allotment_class_id"].Value);
            int accountID = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["gen_ledger_acc_id"].Value);

            string fundName = dgAllotmentRelease.Rows[rowIndex].Cells["fund_name"].Value.ToString();
            string fppCode = dgAllotmentRelease.Rows[rowIndex].Cells["fpp_code"].Value.ToString();
            string fppName = dgAllotmentRelease.Rows[rowIndex].Cells["fpp_name"].Value.ToString();
            string otherFPPName = dgAllotmentRelease.Rows[rowIndex].Cells["others_fpp_name"].Value.ToString();
            string allotmentClassesName = dgAllotmentRelease.Rows[rowIndex].Cells["allotment_class_code"].Value.ToString();
            string accountName = dgAllotmentRelease.Rows[rowIndex].Cells["gen_ledger_name"].Value.ToString();
            short year = Convert.ToInt16(toolStripCmbxYear.ComboBox.SelectedValue);

            _ucObligationRequest.lblTypeofFund.Text = fundName;
            _ucObligationRequest.lblFPPCode.Text = fppCode;
            _ucObligationRequest.lblFPPName.Text = fppName;
            _ucObligationRequest.lblOtherFPP.Text = string.IsNullOrEmpty(otherFPPName) ? "-": otherFPPName;
            _ucObligationRequest.lblAllotmentClass.Text = allotmentClassesName;
            _ucObligationRequest.lblAccount.Text = accountName;
            _ucObligationRequest.lblYear.Text = year.ToString();

            _ucObligationRequest.fundId = fundID;
            _ucObligationRequest.fppId = fppID;
            _ucObligationRequest.othersFPPId = othersFPPID;
            _ucObligationRequest.allotmentClassId = allotmentClassID;
            _ucObligationRequest.accountId = accountID;
            _ucObligationRequest.year = year;
        }

        private void frmSelectAllotmentRelease_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgFPP, true);
            Helper.DatagridDefaultStyle(dgAllotmentRelease, true);

            HelperLoadRecords.FPPDgVObligationRequest(dgFPP,Factory.AllotmentReleaseRepository().GetFPPRecords());
            LoadComboboxes();
        }

        private void dgFPP_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadAllotmentReleaseRecords();
        }

        private void toolStripCmbxFunds_SelectedValueChanged(object sender, EventArgs e) 
        {
            LoadAllotmentReleaseRecords();
        }

        private void toolStripCmbxAllotmentClass_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadAllotmentReleaseRecords();
        }

        private void toolStripCmbxYear_SelectedValueChanged(object sender, EventArgs e) 
        {
            LoadAllotmentReleaseRecords();
        }

        private void dgFPP_SelectionChanged(object sender, EventArgs e)
        {
            LoadAllotmentReleaseRecords();
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonsLocal();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelectedRecord();
            Close();
        }

        private void dgAllotmentRelease_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgAllotmentRelease.SelectedCells[7].Value != null)
            {
                LoadSelectedRecord();
                Close();
            }
        }
    }
}
