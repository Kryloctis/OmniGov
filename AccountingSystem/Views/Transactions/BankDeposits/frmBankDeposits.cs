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

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDeposits : Form
    {
        public frmBankDeposits()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgbankdeposits);
        }

        private void frmBankDeposits_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var depositsRepository = Factory.BankDepositsRepository();
                var dtdeposits = depositsRepository.GetRecords();
                HelperLoadRecords.DepositsDatagridView(dtdeposits, dgbankdeposits);

                lblRecordCount.Text = depositsRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgbankdeposits.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var bdModelList = new List<BankDepositsModel>();
                        foreach (DataGridViewRow row in dgbankdeposits.SelectedRows)
                        {
                            int bdId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            bdModelList.Add(new BankDepositsModel() { Id = bdId });
                        }

                        var bdRepository = Factory.BankDepositsRepository();
                        _ = bdRepository.Delete(bdModelList);
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
                    var dtdeposits = Factory.BankDepositsRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.DepositsDatagridView(dtdeposits, dgbankdeposits);

                    lblRecordCount.Text = dgbankdeposits.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void dgbankdeposits_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexData = { 6, 7, 8, 9 };
            Helper.ShowRecordTimestamp(dgbankdeposits, columnIndexData, lblCreatedAt, lblUpdatedAt, lblCreatedBy, lblUpdatedBy);
            Helper.EnableDisableToolStripButtons(dgbankdeposits, btnEdit, btnDelete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmBankDepositsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgbankdeposits.Rows.Count > 0 && dgbankdeposits.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dgbankdeposits.SelectedCells[0].Value.ToString());
                _ = new frmBankDepositsEdit(this, Id).ShowDialog();
            }
        }
    }
}
