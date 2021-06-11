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
            var errorArray = new string[2];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(txtreport);

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
                if(txtreport.Text != string.Empty)
                {
                    var rcdRepository = Factory.CollectorReportPaymentRepository();
                    var dtrcd = rcdRepository.GetRecords(txtreport.Text.Trim());
                    HelperLoadRecords.RCDDatagridView(dtrcd, dgvpayments);

                    txttotal.Value = rcdRepository.SumRecords(txtreport.Text.Trim());

                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void SetId(string id)
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(id);
                Id = int.Parse(rcdData["id"]);
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
            if(txtreport.Text.Length > 0)
            {
                if(dgvpayments.Rows.Count > 0)
                {
                    Helper.MessageBoxError("Report has existing payment records, please clear record first before loading payments!");
                    dgvpayments.Focus();
                }
                else
                {
                    _ = new frmGenerateRCD(this, Convert.ToInt16(cmbcollector.SelectedValue), txtreport.Text.Trim()).ShowDialog();
                }
                
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
                chckapproved.Checked = false;
            }
            
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmDelete(dgvpayments.Rows.Count))
                {
                    var rcdModelList = new List<CollectorReportPaymentModel>();
                    var rcdRepository = Factory.CollectorReportPaymentRepository();
                    rcdModelList.Add(new CollectorReportPaymentModel() { CoId=Id});
                    _ = rcdRepository.Delete(rcdModelList);
                    LoadCollections();
                }
            } 
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
          
        }
    }
}
