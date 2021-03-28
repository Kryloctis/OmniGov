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
        public frmSelectAllotmentRelease()
        {
            InitializeComponent();
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

            if (selectedRowsCount == 1 && dgAllotmentRelease.SelectedCells[4].Value != null)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
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
    }
}
