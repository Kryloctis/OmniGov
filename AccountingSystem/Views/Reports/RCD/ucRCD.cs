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
        internal int collectorId = 0;
        internal int fundId = 0;
        internal int approved = 0;
        internal string status = string.Empty;
        internal string remarks = string.Empty;
        internal Dictionary<int, string> data = new Dictionary<int, string>();
        public ucRCD()
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgvpayments);
        }

        private void ucRCD_Load(object sender, EventArgs e)
        {
            cmbcollector.SelectedIndex = -1;
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                }


                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += (s,e) => {
                    var radFund = s as RadioButton;
                    fundId = Convert.ToByte(radFund.Tag);
                };
                radFund.CheckedChanged += (s, e) => {
                    var radFund = s as RadioButton;
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                };
            }
        }
        
        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = fundId == 0 ? "Please select a fund source" : string.Empty;
            errorArray[2] = errorProvider.GetError(txtreport);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void LoadCollectors()
        {
            try
            {
                cmbcollector.SelectedValueChanged -= new EventHandler(cmbcollector_SelectedValueChanged);
                var colRepository = Factory.CollectingOfficerRepository();
                var dtCol = colRepository.GetRecords();

                cmbcollector.DataSource = dtCol;
                cmbcollector.DisplayMember = "fullname";
                cmbcollector.ValueMember = "id";
                cmbcollector.SelectedValueChanged += new EventHandler(cmbcollector_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void ResetForm()
        {
            //
            Id = 0;
            collectorId = 0;
            fundId = 0;
            approved = 0;
            status = string.Empty;
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == 1) ? r.Checked = true : r.Checked = false);
            cmbcollector.SelectedIndex = -1;
            txtreport.Clear();
            dtdate.Value = DateTime.Now;
            dgvpayments.DataSource = null;
            txttotal.Text = "0.00";
        }

        internal void LoadCollections()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportPaymentRepository();

                var dtrcd = rcdRepository.GetRecords(Id);

                HelperLoadRecords.RCDDatagridView(dtrcd, dgvpayments);

                txttotal.Text = rcdRepository.SumRecords(Id).ToString("N2");

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
            collectorId = Convert.ToInt32(cmbcollector.SelectedValue);

            if (collectorId == 0 || fundId == 0)
            {
                Helper.MessageBoxError("Please select collector and fund.");
                return;
            }
            
            _ = new frmGenerateRCD(this, collectorId, fundId, data).ShowDialog();
           
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
            if(dgvpayments.Rows.Count > 0)
            {

                btnclear.Enabled = approved > 0 ? false : true;
                if (dgvpayments.SelectedRows.Count > 0)
                {
                    btndelete.Enabled = approved > 0 ? false : true;
                }
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

        private void cmbcollector_SelectedValueChanged(object sender, EventArgs e)
        {
            collectorId = Convert.ToInt32(cmbcollector.SelectedValue);
            MessageBox.Show("Test "+ collectorId);
        }
    }
}
