using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVSearch : Form
    {
        private frmJEV _frmJEV;
        private byte _month;
        private int _year;

        public frmJEVSearch(frmJEV frmJEV, byte month, int year)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmJEV = frmJEV;
            _month = month;
            _year = year;
        }

        private void frmJEVSearch_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dgJEV);
                LoadMonths();
                LoadJEVList();
                nudYear.Value = _year == 0? DateTime.Now.Year:_year;
            }
        }


        private void LoadSelected()
        {
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            string jevNo = dgJEV.Rows[rowIndex].Cells["jev_no"].Value.ToString();
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);

            if (_frmJEV == null)
            {
                var newFrmJev = new frmJEV(this);
                var ucFrmJev = newFrmJev.ucjev1;
                ucFrmJev.jevNo = jevNo;
                ucFrmJev.jevId = jevId;
                newFrmJev.ShowDialog();
            }
            else
            {
                _frmJEV.LoadSelectedJEV(jevNo);
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelected();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = _month == 0? DateTime.Now.Month - 1 : _month;
        }

        internal void LoadJEVList()
        {
            byte jevStatus = (byte)cmbxJevStatus.SelectedIndex;
            string searchTxt = txtSearch.Text;
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            DataTable dtJEV = Factory.JEVRepository().FilterRecords(jevStatus, searchTxt, month, year);
            HelperLoadRecords.JEVDatagridView(dtJEV, dgJEV);
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgJEV.SelectedRows.Count == 1)
                btnSelect.Enabled = true;
            else
                btnSelect.Enabled = false;
        }

        private void dgJEV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadSelected();
        }

        private void cmbxJevStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVList();
        }
    }
}
