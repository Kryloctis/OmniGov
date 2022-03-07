using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary
{
    public partial class ucBudgetDetailed : UserControl
    {
        internal string fppId;
        internal int fundId;
        internal DateTime DateAsOf;

        public ucBudgetDetailed()
        {
            InitializeComponent();
        }

        private void ucBudgetDetailed_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);

                LoadBudgetDashboardComboboxes();
                LoadBudgetDashboardContents();
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];

            errorArray[0] = cmbxFPP.Tag.ToString();
            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool isValidated()
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.Tag = "No FPP selected.";
                return false;
            }
            return true;
        }

        #region COMBOBOXES

        internal void LoadFunds()
        {
            cmbxFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbxFunds.DisplayMember = "fund_name";
            cmbxFunds.ValueMember = "id";
        }

        private void LoadAllotmentClasses()
        {
            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentClassCombobox(dtAllotmentClasses, cmbxAllotmentClasses, "allotment_code", "id");
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text);

            return dtFPP;
        }

        internal void LoadFPP(bool isSearch)
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0)
                {
                    cmbxFPP.DataSource = null;
                    cmbxFPP.DropDownHeight = 100;
                    return;
                };

                var fppDict = new Dictionary<string, string>();

                if (!isSearch) fppDict.Add("all", "All");
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    string fppId = item["id"].ToString();
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbxFPP.DataSource = new BindingSource(fppDict, null);
                cmbxFPP.DisplayMember = "value";
                cmbxFPP.ValueMember = "key";
                cmbxFPP.DropDownHeight = 400;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP(true);
                cmbxFPP.DroppedDown = true;
            }
        }

        #endregion

        private void LoadDetailed()
        {
            string fppId = cmbxFPP.SelectedValue.ToString();
            int allotmentClassId = Convert.ToInt32(cmbxAllotmentClasses.SelectedValue);

            HelperLoadRecords.DashboardDetailedDatagridView(dataGridView1, fppId, allotmentClassId, fundId, DateAsOf);
        }

        private void LoadBudgetDashboardContents()
        {
            try
            {
                if (!isValidated())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                fppId = cmbxFPP.SelectedValue.ToString();
                fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateAsOf = dtAsOf.Value;

                Cursor.Current = Cursors.WaitCursor;
                LoadDetailed();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private void LoadBudgetDashboardComboboxes()
        {
            LoadFPP(false);
            LoadFunds();
            LoadAllotmentClasses();
            LoadBudgetDashboardContents();
        }

        private void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP(false);
                cmbxFPP.Text = string.Empty;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBudgetDashboardContents();
        }
    }
}
