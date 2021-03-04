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

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class frmFunds : Form
    {
        public frmFunds()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            try
            {
                var fundsRepository = Factory.FundsRepository();
                var dtFunds = fundsRepository.GetRecords();
                HelperLoadRecords.FundsDatagridView(dtFunds, dgFunds);

                lblRecordCount.Text = fundsRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmFunds_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgFunds);
            LoadRecords();
        }

      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmFundAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgFunds.Rows.Count > 0)
            {
                int fundId = int.Parse(dgFunds.SelectedCells[0].Value.ToString());
                _ = new frmFundEdit(this, fundId).ShowDialog();
            }
           
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgFunds.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var fundsModelList = new List<FundsModel>();
                        foreach (DataGridViewRow row in dgFunds.SelectedRows)
                        {
                            int fundId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            fundsModelList.Add(new FundsModel() { Id = fundId });
                        }

                        var fundsRepository = Factory.FundsRepository();
                        _ = fundsRepository.Delete(fundsModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


		private void dgFunds_SelectionChanged(object sender, EventArgs e)
		{
            byte[] columnIndexTimestamp = { 2, 3 };
            Helper.ShowRecordTimestamp(dgFunds, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunds, btnEdit, btnDelete);
        }
	}
}
