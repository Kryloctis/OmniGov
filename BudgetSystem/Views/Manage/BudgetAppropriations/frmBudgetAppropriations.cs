using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriations : Form
    {
        public frmBudgetAppropriations()
        {
            InitializeComponent();
        }

        internal void LoadRecords() 
        {
            DataTable dtBudgetAppropriations;
            try
            {
                if (txtStripSearch.Text.Length > 3 && !string.IsNullOrEmpty(txtStripSearch.Text))
                {
                    dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords();
                }
                else
                {
                    dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords();
                }

                HelperLoadRecords.BudgetAppropriationsDataGridView(dtBudgetAppropriations, dgBudgetAppropriations);
                lblRecordCount.Text = dtBudgetAppropriations.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmBudgetAppropriations_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationsAdd = new frmBudgetAppropriationsAdd(this);
            frmBudgetAppropriationsAdd.ShowDialog();
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 14, 15 };
            Helper.ShowRecordTimestamp(dgBudgetAppropriations, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgBudgetAppropriations, toolStripButtonEdit, toolStripButtonDelete);
        }
    }
}
