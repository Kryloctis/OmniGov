using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAccountable : Form
    {
        public frmAccountable()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgAccform);
        }
        internal void LoadRecords()
        {
            try
            {
                var accRepository = Factory.AccountableRepository();
                var dtAcc = accRepository.GetRecords();
                HelperLoadRecords.AccFormDatagridView(dtAcc, dgAccform);

                lblRecordCount.Text = accRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmAccountable_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAccountableAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgAccform.Rows.Count > 0 && dgAccform.SelectedRows.Count > 0)
            {
                int accId = int.Parse(dgAccform.SelectedCells[0].Value.ToString());
                _ = new frmAccountableEdit(this, accId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgAccform.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var accModelList = new List<AccountableModel>();
                        foreach (DataGridViewRow row in dgAccform.SelectedRows)
                        {
                            int accId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            accModelList.Add(new AccountableModel() { Id = accId });
                        }

                        var accRepository = Factory.AccountableRepository();
                        _ = accRepository.Delete(accModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtAcc = Factory.AccountableRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.AccFormDatagridView(dtAcc, dgAccform);

                    lblRecordCount.Text = dgAccform.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void dgAccform_SelectionChanged(object sender, EventArgs e)
        {
           // byte[] columnIndexTimestamp = { 3, 4 };
           // Helper.ShowRecordTimestamp(dgBanks, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgAccform, btnEdit, btnDelete);
        }
    }
}
