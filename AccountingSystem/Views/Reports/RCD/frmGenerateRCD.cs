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
    public partial class frmGenerateRCD : Form
    {
        private frmRCD _frmrcd;
        private int Id;
        private string _reportno;
        List<CollectorReportPaymentModel> data = new List<CollectorReportPaymentModel>();
        public frmGenerateRCD(frmRCD frmrcd,string reportno)
        {
            InitializeComponent();            
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgPreview);
            _frmrcd = frmrcd;
            _reportno = reportno;
            this.Text = String.Format("Collection Report > {0}", reportno);
        }
        private void LoadCollectors()
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
        private void frmGenerateRCD_Load(object sender, EventArgs e)
        {
            LoadCollectors();
            SelectedReportValue();
        }

        private void SelectedReportValue()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(_reportno);
                Id = Convert.ToInt16(rcdData["id"]);
                cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                cmbcollector.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbcollector, "Please select collector!");
                cmbcollector.Focus();
            }
            else
            {
                try
                {
                    var pcRepository = Factory.PaymentCollectionRepository();
                    var dateYearMonth = String.Format("{0:MMMM}-{0:yyyy}", Convert.ToDateTime(dtpMonth.Value));
                    var dtpc = pcRepository.GetRecordByLedger(Id, dateYearMonth);
                    HelperLoadRecords.PaymentDatagridView(dtpc, dgPreview);

                    txttotalamount.Value = pcRepository.SumRecords(Id, dateYearMonth);
                    if(dtpc.Rows.Count > 0)
                    {
                        data.Clear();
                        for(int i=0;i < dtpc.Rows.Count; i++)
                        {
                            data.Add(new CollectorReportPaymentModel()
                            {
                                CoId = Id,
                                PcId = Convert.ToInt16(dtpc.Rows[i]["id"]),
                            });
                        }
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(dgPreview.Rows.Count <= 0)
            {
                errorProvider.SetError(dgPreview, "Please Load Payment Collection list!");
                dgPreview.Focus();
            }
            else if (cmbcollector.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbcollector, "Please select collector!");
                cmbcollector.Focus();
            }
            else
            {
                if (Helper.MessageBoxConfirmRCDList())
                {
                    var rcdRepository = Factory.CollectorReportPaymentRepository();
                    if (rcdRepository.Insert(data))
                    {
                        Helper.MessageBoxSuccess("Collection Report Generated Successfully!");
                        _frmrcd.LoadRecords();
                        this.Close();
                    }
                }
            }
        }

        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexData = { 11, 12, 13, 14 };
            Helper.ShowRecordTimestamp(dgPreview, columnIndexData, lblCreatedAt, lblUpdatedAt, lblCreatedBy, lblUpdatedBy);
        }
    }
}
