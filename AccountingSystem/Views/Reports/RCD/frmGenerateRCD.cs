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
        private ucRCD _ucrcd;
        private int Id;
        private int CoId;
        private string _reportno;
        List<CollectorReportPaymentModel> data;
        public frmGenerateRCD(ucRCD ucrcd,int Coid,string reportno)
        {
            InitializeComponent();            
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgPreview);
            _ucrcd = ucrcd;
            CoId = Coid;
            _reportno = reportno;
            this.Text = String.Format("Collection Report > Report No. {0}", reportno);
        }
        private void frmGenerateRCD_Load(object sender, EventArgs e)
        {
            SetReportID();
        }
        
        private void SetReportID()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(_reportno);
                Id = int.Parse(rcdData["id"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                var pcRepository = Factory.PaymentCollectionRepository();
                var dateFrom = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtfrom.Value));
                var dateTo = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtto.Value));
                var dtpc = pcRepository.GetRecordByLedger(CoId, dateFrom,dateTo);
                HelperLoadRecords.PaymentDatagridView(dtpc, dgPreview);

                txttotalamount.Value = pcRepository.SumRecords(CoId, dateFrom,dateTo);
                lblRecordCount.Text = dgPreview.Rows.Count > 0 ? dgPreview.Rows.Count.ToString():"0";
                if (dtpc.Rows.Count > 0)
                {
                    data = new List<CollectorReportPaymentModel>();
                    data.Clear();
                    for (int i = 0; i < dtpc.Rows.Count; i++)
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
             if(dgPreview.Rows.Count <= 0)
            {
                Helper.MessageBoxError("Please Load Payment Collection list!");
                dgPreview.Focus();
            }
            else
            {
                var rcdRepository = Factory.CollectorReportPaymentRepository();
                if (rcdRepository.Append(data))
                {
                    Helper.MessageBoxSuccess("Collection Report Generated Successfully!");
                    _ucrcd.LoadCollections();
                    this.Close();
                }
            }
        }

        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {
           
        }
    }
}
