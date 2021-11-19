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
        private int collectorId = 0;
        private int fundId = 0;
        private DataTable list;
        public frmGenerateRCD(ucRCD ucrcd,int Coid,int Fid, Dictionary<int,string> _data)
        {
            InitializeComponent();            
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgPreview, true);
            _ucrcd = ucrcd;
            collectorId = Coid;
            fundId = Fid;
            data = _data;
        } 

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                var pcRepository = Factory.PaymentCollectionRepository();
                var dateFrom = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtfrom.Value));
                var dateTo = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtto.Value));

                //list = pcRepository.GetRecordByLedger(collectorId, fundId, dateFrom, dateTo, id);
                HelperLoadRecords.CollectionDataGridView(list, dgPreview);

                txttotalamount.Text = String.Format("{0:N2}", pcRepository.SumRecords(collectorId, fundId, dateFrom, dateTo));
               
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
                    DataTable newtable = convertToGrid(_ucrcd.dgvpayments);
                    if (list.Rows.Count > 0)
                    {                        
                        for (int i = 0; i < list.Rows.Count; i++)
                        {
                            DataRow row = newtable.NewRow();
                            row[0] = 0;
                            row[1]= list.Rows[i]["id"];
                            row[2]= list.Rows[i]["account_code"];
                            row[3] = list.Rows[i]["accform"];
                            row[4] = list.Rows[i]["ledger_name"];
                            row[5] = list.Rows[i]["subsidiary"];
                            row[6] = list.Rows[i]["payee"];
                            row[7] = list.Rows[i]["receipt_no"];
                            row[8]= list.Rows[i]["payment_date"];
                            row[9] = list.Rows[i]["amount"];
                            row[10]= list.Rows[i]["collector"];
                            newtable.Rows.Add(row);
                            newtable.AcceptChanges();
                        }
                        _ucrcd.dgvpayments.DataSource = newtable;
                    }
                    _ucrcd.txttotal.Text = String.Format("{0:N2}", _ucrcd.dgvpayments.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells[9].Value)));
                    this.Close();
                }
                else
                {
                    DataTable dt = convertList(list);
                    HelperLoadRecords.RCDDatagridView(dt, _ucrcd.dgvpayments);
                    _ucrcd.txttotal.Text = String.Format("{0:N2}", _ucrcd.dgvpayments.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells[9].Value)));
                    this.Close();
                }

            }
        }

        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private DataTable convertToGrid(DataGridView view)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in view.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in view.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            return dt;
        }

        private DataTable convertList(DataTable data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("pid", typeof(int));
            dt.Columns.Add("account_code", typeof(string));
            dt.Columns.Add("accform", typeof(string));
            dt.Columns.Add("ledger_name", typeof(string));
            dt.Columns.Add("subsidiary", typeof(string));
            dt.Columns.Add("payee", typeof(string));
            dt.Columns.Add("receipt_no", typeof(string));
            dt.Columns.Add("payment_date", typeof(DateTime));
            dt.Columns.Add("amount", typeof(decimal));
            dt.Columns.Add("collector", typeof(string));
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGenerateRCD_Load(object sender, EventArgs e)
        {

        }

        private void dgPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
