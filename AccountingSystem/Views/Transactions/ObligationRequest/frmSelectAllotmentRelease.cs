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
            _ucObligationRequest.lblTypeofFund.Text = dgAllotmentRelease.SelectedCells[6].Value.ToString();
            _ucObligationRequest.lblFPPCode.Text = dgAllotmentRelease.SelectedCells[8].Value.ToString();
            _ucObligationRequest.lblFPPName.Text = dgAllotmentRelease.SelectedCells[9].Value.ToString();
            _ucObligationRequest.lblOtherFPP.Text = string.IsNullOrEmpty(dgAllotmentRelease.SelectedCells[11].Value.ToString())? "-": dgAllotmentRelease.SelectedCells[11].Value.ToString();
            _ucObligationRequest.lblAllotmentClass.Text = dgAllotmentRelease.SelectedCells[13].Value.ToString();
            _ucObligationRequest.lblAccount.Text = dgAllotmentRelease.SelectedCells[17].Value.ToString();

            _ucObligationRequest.fundId = Convert.ToInt32(dgAllotmentRelease.SelectedCells[4].Value);
            _ucObligationRequest.fppId = Convert.ToInt32(dgAllotmentRelease.SelectedCells[7].Value);
            _ucObligationRequest.othersFPPId = string.IsNullOrEmpty(dgAllotmentRelease.SelectedCells[10].Value.ToString())? null: Convert.ToInt32(dgAllotmentRelease.SelectedCells[10].Value);
            _ucObligationRequest.allotmentClassId = Convert.ToInt32(dgAllotmentRelease.SelectedCells[12].Value);
            _ucObligationRequest.accountId = Convert.ToInt32(dgAllotmentRelease.SelectedCells[15].Value);
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
