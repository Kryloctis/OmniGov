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
        private Dictionary<int, string> data;
        private int CoId = 0;
        private DataTable list;
        public frmGenerateRCD(ucRCD ucrcd,int Coid, Dictionary<int,string> _data)
        {
            InitializeComponent();            
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgPreview);
            _ucrcd = ucrcd;
            CoId = Coid;
            data = _data;
            this.Text = "Generate Collections";
        }
        private void frmGenerateRCD_Load(object sender, EventArgs e)
        {
            
        }        
      

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if(data.Count > 0)
                {
                    string id = string.Join(",", data.Select(x => String.Format("'{0}'", x.Key)).ToArray());
                    var pcRepository = Factory.PaymentCollectionRepository();
                    var dateFrom = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtfrom.Value));
                    var dateTo = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtto.Value));
                    list = pcRepository.GetRecordByLedger(CoId, dateFrom, dateTo,id);
                    HelperLoadRecords.PaymentDatagridView(list, dgPreview);

                    txttotalamount.Value = pcRepository.SumRecords(CoId, dateFrom, dateTo,id);
                    lblRecordCount.Text = dgPreview.Rows.Count.ToString();
                }
                else
                {                    
                    var pcRepository = Factory.PaymentCollectionRepository();
                    var dateFrom = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtfrom.Value));
                    var dateTo = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtto.Value));
                    list = pcRepository.GetRecordByLedger(CoId, dateFrom, dateTo);
                    HelperLoadRecords.PaymentDatagridView(list, dgPreview);

                    txttotalamount.Value = pcRepository.SumRecords(CoId, dateFrom, dateTo);
                    lblRecordCount.Text = dgPreview.Rows.Count.ToString();
                }               
                
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(dgPreview.Rows.Count <= 0 && list.Rows.Count <= 0)
            {
                Helper.MessageBoxError("Please Load Payment Collection list!");
                dgPreview.Focus();
            }
            else
            {
                
                if (_ucrcd.dgvpayments.Rows.Count > 0)
                {
                    if(list.Rows.Count > 0)
                    {
                        for (int i = 0; i < list.Rows.Count; i++)
                        {
                            DataGridViewRow row = (DataGridViewRow)_ucrcd.dgvpayments.RowTemplate.Clone();
                            row.Cells[0].Value = 0;
                            row.Cells[1].Value = list.Rows[i]["id"];
                            row.Cells[2].Value = list.Rows[i]["account_code"];
                            row.Cells[3].Value = list.Rows[i]["accform"];
                            row.Cells[4].Value = list.Rows[i]["ledger_name"];
                            row.Cells[5].Value = list.Rows[i]["subsidiary"];
                            row.Cells[6].Value = list.Rows[i]["payee"];
                            row.Cells[7].Value = list.Rows[i]["receipt_no"];
                            row.Cells[8].Value = list.Rows[i]["payment_date"];
                            row.Cells[9].Value = list.Rows[i]["amount"];
                            row.Cells[10].Value = list.Rows[i]["collector"];
                            _ucrcd.dgvpayments.Rows.Add(row);
                            /*
                            var update = from DataGridViewRow r in _ucrcd.dgvpayments.Rows where r.Cells[1].Value.Equals(list.Rows[i]["id"]) select r;
                            if(update.Count() > 0)
                            {
                                foreach (var item in update)
                                {
                                    item.Cells[1].Value = list.Rows[i]["id"];
                                    item.Cells[2].Value = list.Rows[i]["account_code"];
                                    item.Cells[3].Value = list.Rows[i]["accform"];
                                    item.Cells[4].Value = list.Rows[i]["ledger_name"];
                                    item.Cells[5].Value = list.Rows[i]["subsidiary"];
                                    item.Cells[6].Value = list.Rows[i]["payee"];
                                    item.Cells[7].Value = list.Rows[i]["receipt_no"];
                                    item.Cells[8].Value = list.Rows[i]["payment_date"];
                                    item.Cells[9].Value = list.Rows[i]["amount"];
                                    item.Cells[10].Value = list.Rows[i]["collector"];
                                }
                            }
                            else
                            {
                               
                            }*/


                        }
                    }
                    this.Close();
                }
                else
                {
                    DataTable dt = convertList(list);
                    HelperLoadRecords.RCDDatagridView(dt, _ucrcd.dgvpayments);
                    this.Close();
                }
                
                /*var rcdRepository = Factory.CollectorReportPaymentRepository();
                if (rcdRepository.Append(data))
                {
                    Helper.MessageBoxSuccess("Collection Report Generated Successfully!");
                    _ucrcd.LoadCollections(); 
                    this.Close();
                }*/
            }
        }

        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private DataTable convertList(DataTable data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("pid", typeof(int));
            dt.Columns.Add("account_code", typeof(object));
            dt.Columns.Add("accform", typeof(object));
            dt.Columns.Add("ledger_name", typeof(object));
            dt.Columns.Add("subsidiary", typeof(object));
            dt.Columns.Add("payee", typeof(object));
            dt.Columns.Add("receipt_no", typeof(object));
            dt.Columns.Add("payment_date", typeof(DateTime));
            dt.Columns.Add("amount", typeof(decimal));
            dt.Columns.Add("collector", typeof(object));
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["id"] = 0;
                    row["pid"] = data.Rows[i]["id"];
                    row["account_code"] = data.Rows[i]["account_code"];
                    row["accform"] = data.Rows[i]["accform"];
                    row["ledger_name"] = data.Rows[i]["ledger_name"];
                    row["subsidiary"] = data.Rows[i]["subsidiary"];
                    row["payee"] = data.Rows[i]["payee"];
                    row["receipt_no"] = data.Rows[i]["receipt_no"];
                    row["payment_date"] = data.Rows[i]["payment_date"];
                    row["amount"] = data.Rows[i]["amount"];
                    row["collector"] = data.Rows[i]["collector"];
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
    }
}
