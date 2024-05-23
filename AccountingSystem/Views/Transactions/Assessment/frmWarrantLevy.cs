using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.AccountableForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class frmWarrantLevy : Form
    {
        private bool isEdit;
        private ucWarrantLevy ucWarrantLevy;

        public frmWarrantLevy()
        {
            InitializeComponent();
            ucWarrantLevy = ucWarrantLevy1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = false;
                ucWarrantLevy.OnLoad(isEdit);
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Save (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = true;
                int rowIndex = dataGridView1.CurrentRow.Index;
                int warrantLevyId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["warrant_levy_id"].Value);
                ucWarrantLevy.OnLoad(isEdit, warrantLevyId);
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Update (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData(DataGridView dataGridView)
        {
            var selectedRows = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRows.Count))
            {
                var registryModels = new List<DelinquentNoticeModel>();

                foreach (DataGridViewRow row in selectedRows)
                    registryModels.Add(new DelinquentNoticeModel() { Id = Convert.ToInt32(row.Cells["delinquent_notice_id"].Value) });

                return AccFactory.DelinquentNoticeRepository().Delete(registryModels);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData(dataGridView1))
                {
                    Helper.MessageBoxSuccess($"{dataGridView1.SelectedRows.Count} record/s has been deleted.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void frmWarrantLevy_Load(object sender, EventArgs e)
        {
        }
    }
}