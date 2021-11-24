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
    public partial class frmRCDAdd : Form
    {
        public frmRCDAdd()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgCollectorsReport, true);
        }

        private void frmRCDAdd_Load(object sender, EventArgs e)
        {
            cmbCollector.SelectedIndex = -1;

            LoadFunds();
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                int collectorId = Convert.ToInt32(cmbCollector.SelectedValue);
                string status = cmbCollector.Text.ToLower();
                byte fundId = (byte)(cmbfunds.SelectedValue != null ? Convert.ToByte(cmbfunds.SelectedValue.ToString()) : 0);
                string keySearch = txtsearch.Text;


                var colectorRepository = Factory.CollectorReportRepository();

                //var dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch);
                var dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch);

                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgCollectorsReport);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            try
            {
                var fundrepo = Factory.FundsRepository();
                var dtfunds = fundrepo.GetRecords();
                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "fund_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


    }
}
