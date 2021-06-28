using ACC.Domain.Interfaces;
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

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class ucRCD : UserControl
    {
        internal int Id = 0;
        internal int CoId = 0;
        internal int Fid = 0;
        internal Dictionary<int, string> data = new Dictionary<int, string>();
        public ucRCD()
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgvpayments);
        }

        private void ucRCD_Load(object sender, EventArgs e)
        {

        }
        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(cmbfund);
            errorArray[2] = errorProvider.GetError(txtreport);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void LoadCollectors()
        {
            try
            {
                var colRepository = Factory.CollectingOfficerRepository();
                var dtCol = colRepository.GetRecords();
                cmbcollector.DataSource = dtCol;
                cmbcollector.ValueMember = "id";
                cmbcollector.DisplayMember = "fullname";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadFunds()
        {
            try
            {
                var fundRepository = Factory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                dtFund.Columns.Add("funddisplay", typeof(string), "fund_code + ' - ' + fund_name");
                cmbfund.DataSource = dtFund;
                cmbfund.ValueMember = "id";
                cmbfund.DisplayMember = "funddisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void ResetForm()
        {
            Id = 0;
            CoId = 0;
            cmbcollector.SelectedIndex = -1;
            txtreport.Clear();
            dtdate.Value = DateTime.Now;
            dgvpayments.DataSource = null;
        }

        internal void LoadCollections()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportPaymentRepository();
                var dtrcd = rcdRepository.GetRecords(Id);
                HelperLoadRecords.RCDDatagridView(dtrcd, dgvpayments);

                txttotal.Text = String.Format("{0:N2}",rcdRepository.SumRecords(Id));
                if(dtrcd.Rows.Count > 0)
                {
                    data.Clear();
                    for(int i =0;i < dtrcd.Rows.Count; i++)
                    {
                        data.Add(int.Parse(dtrcd.Rows[i]["pid"].ToString()), dtrcd.Rows[i]["payee"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbcollector, "Collector!");
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbcollector);
        }

        private void txtreport_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtreport, "Report No.!");
        }

        private void txtreport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtreport);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex == -1)
            {
                Helper.MessageBoxError("Please select Collector!");
                cmbcollector.Focus();
               
            }
            else if(cmbfund.SelectedIndex == -1)
            {
                Helper.MessageBoxError("Please select Fund!");
                cmbfund.Focus();
            }
            else
            {
                _ = new frmGenerateRCD(this, Convert.ToInt16(cmbcollector.SelectedValue), Convert.ToInt16(cmbfund.SelectedValue), data).ShowDialog();
            }
            
        }

        private void chckapproved_CheckedChanged(object sender, EventArgs e)
        {
            if(dgvpayments.Rows.Count > 0)
            {
                if (chckapproved.Checked)
                {
                    btnadd.Enabled = false;
                    btnclear.Enabled = false;
                }
                else
                {
                    btnadd.Enabled = true;
                    btnclear.Enabled = true;
                }
            }
            else
            {
                Helper.MessageBoxError("Please Load Payment List!");
                chckapproved.Checked = false;
            }
            
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if(dgvpayments.Rows.Count > 0)
            {
                try
                {
                    if (Helper.MessageBoxConfirmDelete(dgvpayments.Rows.Count))
                    {
                        var rcdModelList = new List<CollectorReportPaymentModel>();
                        var rcdRepository = Factory.CollectorReportPaymentRepository();
                        rcdModelList.Add(new CollectorReportPaymentModel() { CoId = Id });
                        if (rcdRepository.Delete(rcdModelList))
                        {
                            LoadCollections();
                            txttotal.Text = String.Format("{0:N2}", rcdRepository.SumRecords(Id));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
       
          
        }

        private void dgvpayments_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvpayments.SelectedRows.Count > 0)
            {
                btndelete.Enabled = chckapproved.Checked ? false: true;
                btnclear.Enabled = chckapproved.Checked ? false : true;
            }
            else
            {
                btnclear.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(dgvpayments.SelectedRows.Count > 0)
            {
                try
                {
                    if (Helper.MessageBoxConfirmDelete(dgvpayments.SelectedRows.Count))
                    {
                        int id = int.Parse(dgvpayments.CurrentRow.Cells[0].Value.ToString());
                        if (id > 0)
                        {
                            var rcdModelList = new List<CollectorReportPaymentModel>();
                            var rcdRepository = Factory.CollectorReportPaymentRepository();
                            rcdModelList.Add(new CollectorReportPaymentModel() { Id = id });
                            if (rcdRepository.Delete(rcdModelList))
                            {
                                dgvpayments.Rows.RemoveAt(dgvpayments.CurrentRow.Index);
                                txttotal.Text = String.Format("{0:N2}",dgvpayments.Rows.Cast<DataGridViewRow>().Sum(x =>Convert.ToDouble(x.Cells[9].Value)));
                            }
                            // LoadCollections();
                        }
                        else
                        {
                            dgvpayments.Rows.RemoveAt(dgvpayments.CurrentRow.Index);
                            txttotal.Text = String.Format("{0:N2}", dgvpayments.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells[9].Value)));
                        }

                    }
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
            
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbfund, "Fund!");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbfund);
        }
    }
}
