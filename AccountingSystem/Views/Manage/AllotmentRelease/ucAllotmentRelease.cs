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
    public partial class ucAllotmentRelease : UserControl
    {
        internal int fppID;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int fundId;
        internal DateTime dateIssued;
        private ucAllotmentReleaseMain ucAllotmentMain;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            ucAllotmentMain = ucAllotmentReleaseMain;
        }


        //ACCOUNT COMBOBOX
        private DataTable DatatableBudgetAppropriations()
        {
            var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
            string accountGroupName = allotmentClassRepo["allotment_name"];

            DataTable dtBudgetAppropriation;

            if (string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtBudgetAppropriation = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupName("Assets");
                else
                    dtBudgetAppropriation = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupName(accountGroupName);
            }
            else
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtBudgetAppropriation = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupNameSearch("Assets", cmbxBudgetAppropriations.Text);
                else
                    dtBudgetAppropriation = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupNameSearch(accountGroupName, cmbxBudgetAppropriations.Text);
            }

            return dtBudgetAppropriation;
        }

        private void LoadBudgetAppropriations()
        {
            try
            {
                cmbxBudgetAppropriations.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DatatableBudgetAppropriations().Rows.Count == 0) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableBudgetAppropriations().Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxBudgetAppropriations.DataSource = new BindingSource(accountDict, null);
                cmbxBudgetAppropriations.DisplayMember = "value";
                cmbxBudgetAppropriations.ValueMember = "key";

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
            {
                cmbxBudgetAppropriations.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadBudgetAppropriations();
                cmbxBudgetAppropriations.SelectedIndex = -1;
                cmbxBudgetAppropriations.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void cmbxBudgetAppropriations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxBudgetAppropriations.FindStringExact(cmbxBudgetAppropriations.Text) == -1 && !string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
            {
                LoadBudgetAppropriations();
                cmbxBudgetAppropriations.DroppedDown = true;
            }
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epYear.GetError(nudYear);
            errorArray[1] = epBudgetAppropriation.GetError(cmbxBudgetAppropriations);
            errorArray[2] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ucAllotmentRelease_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                nudYear.Value = DateTime.Now.Year;
                LoadBudgetAppropriations();
                cmbxBudgetAppropriations.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }


        //VALIDATIONS

        private void nudYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epYear, nudYear, "Year");
        }

        private void nudYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epYear, nudYear);
        }

        



        private bool AmountNotValidated() 
        {
            try
            {
                var isEmpty = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");

                if (isEmpty)
                {
                    return true;
                }
                else if (nudAmount.Value == 0)
                {
                    epAmount.SetError(nudAmount, Helper.ErrorMessage("Amount"));
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = AmountNotValidated();
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }




        private bool BudgetAppropriationNotValidated() 
        {
            try
            {
                var isEmpty = Helper.ShowErrorComboBoxEmpty(epBudgetAppropriation, cmbxBudgetAppropriations, "Budget Appropriation");

                if (isEmpty)
                    return true;
                else if (cmbxBudgetAppropriations.FindStringExact(cmbxBudgetAppropriations.Text) < 0 && !string.IsNullOrEmpty(cmbxBudgetAppropriations.Text)) 
                {
                    epBudgetAppropriation.SetError(cmbxBudgetAppropriations, "Budget Appropriation doesn't exist in youe records");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private void cmbxBudgetAppropriations_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = BudgetAppropriationNotValidated();
        }

        private void cmbxBudgetAppropriations_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epBudgetAppropriation, cmbxBudgetAppropriations);
        }

    }
}
