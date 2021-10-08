using AccountingSystem.Views.Transactions.BankDeposits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmGCList : Form
    {
        Dictionary<int, string> print = new Dictionary<int, string>();
        public frmGCList()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvgc);
        }

        private void dgvgc_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvgc.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvgc.CurrentRow.Cells[0].Value.ToString());
                var gcdRepository = Factory.GeneralCollectionsDepositsRepository();
                btnDeposit.Enabled = gcdRepository.IdExist(id) ? false:true;
            }
            else
            {
                btnDeposit.Enabled = false;
            }
        }

        private void frmGCList_Load(object sender, EventArgs e)
        {
            LoadGC();
        }

        internal void LoadGC()
        {
            try
            {
                var gcRepository = Factory.GeneralCollectionsRepository();
                var dtgc = gcRepository.GetRecords();
                HelperLoadRecords.GeneralCollectionDatagridView(dtgc, dgvgc);

                lblRecordCount.Text = dgvgc.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    var gcRepository = Factory.GeneralCollectionsRepository();
                    var dtgc = gcRepository.GetRecordsBySearch(txtsearch.Text.Trim());
                    HelperLoadRecords.GeneralCollectionDatagridView(dtgc, dgvgc);

                    lblRecordCount.Text = dgvgc.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadGC();
            }
        }

        private void dgvgc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                if (!Convert.ToBoolean(dgvgc.CurrentRow.Cells[e.ColumnIndex].Value))
                {
                    dgvgc.CurrentRow.Cells[e.ColumnIndex].Value = true;
                    if (!print.ContainsKey(Convert.ToInt16(dgvgc.CurrentRow.Cells[0].Value)))
                    {
                        print.Add(Convert.ToInt16(dgvgc.CurrentRow.Cells[0].Value), dgvgc.CurrentRow.Cells[1].Value.ToString());
                    }
                }
                else
                {
                    dgvgc.CurrentRow.Cells[e.ColumnIndex].Value = false;
                    print.Remove(Convert.ToInt16(dgvgc.CurrentRow.Cells[0].Value));
                }

                btnRCD.Enabled = print.Count > 0 ? true : false;
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if(dgvgc.SelectedRows.Count > 0)
            {
                try
                {
                    int Id = int.Parse(dgvgc.CurrentRow.Cells[0].Value.ToString());
                    var gcRepository = Factory.GeneralCollectionsRepository();
                    decimal gcsum = gcRepository.SumRecords(Id);
                    if (gcsum > 0)
                    {
                        if (Helper.MessageBoxConfirmGCDeposit())
                        {
                            frmBankDeposits fd = new frmBankDeposits();
                            frmBankDepositsAdd fbd = new frmBankDepositsAdd(fd);
                            fbd.Gcid = Id;
                            fbd.Gcamount = gcsum;
                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }


        private void btnRCD_Click(object sender, EventArgs e)
        {
            if (print.Count > 0)
            {
                string id = string.Join(",", print.Select(x => String.Format("'{0}'", x.Key)).ToArray());
                _ = new frmCDReport(id).ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGC();
        }
    }
}
