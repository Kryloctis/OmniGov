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

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmBanks : Form
    {
        public frmBanks()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgBanks);
        }
        internal void LoadRecords()
        {
            try
            {
                var banksRepository = Factory.BanksRepository();
                var dtBanks = banksRepository.GetRecords();
                HelperLoadRecords.BanksDatagridView(dtBanks, dgBanks);

                lblRecordCount.Text = banksRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmBanks_Load(object sender, EventArgs e)
        {            
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmBankAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgBanks.Rows.Count > 0 && dgBanks.SelectedRows.Count > 0)
            {
                int bankId = int.Parse(dgBanks.SelectedCells[0].Value.ToString());
                _ = new frmBankEdit(this, bankId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgBanks.SelectedRows.Count;
            try
            {
                if(selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var banksModelList = new List<BanksModel>();
                        foreach (DataGridViewRow row in dgBanks.SelectedRows)
                        {
                            int bankId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            banksModelList.Add(new BanksModel() { Id = bankId });
                        }

                        var banksRepository = Factory.BanksRepository();
                        _ = banksRepository.Delete(banksModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgBanks_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgBanks, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgBanks, btnEdit, btnDelete);

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtBanks = Factory.BanksRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.BanksDatagridView(dtBanks, dgBanks);

                    lblRecordCount.Text = dgBanks.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }
    }
}
