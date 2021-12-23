using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestSearch : Form
    {
        private frmObligationRequestMain _frmObligationRequestMain;
        private ucObligationRequestMain _ucObligationRequestMain;

        public frmObligationRequestSearch(frmObligationRequestMain frmObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmObligationRequestMain = frmObligationRequestMain;
            _ucObligationRequestMain = _frmObligationRequestMain.ucObligationRequestMain1;
            btnSelect.Enabled = false;
        }

        private void LoadObligationRequests()
        {
            try
            {
                string searchTxt = txtSearch.Text.Trim();
                HelperLoadRecords.ObligationRequestDatagridView(dgObligationRequests, searchTxt);
            }
            catch (MySqlException ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgObligationRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgObligationRequests.SelectedRows.Count == 1)
                btnSelect.Enabled = true;
            else
                btnSelect.Enabled = false;
        }

        private void LoadSelected()
        {
            _ucObligationRequestMain.isEdit = true;
            int rowIndex = dgObligationRequests.CurrentCell.RowIndex;
            int obligationRequestId = Convert.ToInt32(dgObligationRequests.Rows[rowIndex].Cells["id"].Value);
            _ucObligationRequestMain.obligationRequestId = obligationRequestId;
            _ucObligationRequestMain.LoadSearched();
            _frmObligationRequestMain.EnableDisableControls();
            _ucObligationRequestMain.EnableDisableComponents(false);
            _frmObligationRequestMain.GetObligationStatus();
            _frmObligationRequestMain.btnSave.Text = "Update";

            Helper.ClearErrorComboBox(_ucObligationRequestMain.epFPP, _ucObligationRequestMain.cmbxFPP);
            Helper.ClearMaskedTextboxError(_ucObligationRequestMain.epObligationNo, _ucObligationRequestMain.mskTxtObligationNoTemplate);
            Helper.ClearMaskedTextboxError(_ucObligationRequestMain.epObligationRequest, _ucObligationRequestMain.mskTxtObligationNoTemplate);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epPayee, _ucObligationRequestMain.txtPayee);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epReferenceNo, _ucObligationRequestMain.txtReferenceNo);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epExplanation, _ucObligationRequestMain.txtExplanation);

            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelected();
        }

        private void dgObligationRequests_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadSelected();
        }

        private void frmObligationRequestSearch_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgObligationRequests, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadObligationRequests();
        }
    }
}
