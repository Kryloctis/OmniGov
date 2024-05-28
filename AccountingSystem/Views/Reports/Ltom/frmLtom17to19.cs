using ACC.Data;
using Org.BouncyCastle.Crypto.Agreement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom17to19 : Form
    {
        private DataTable dtDelinquentNotice;

        public frmLtom17to19()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
            txtRpt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRpt.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void frmLtom17to19_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRealProperties()
        {
            dtDelinquentNotice = AccFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtDelinquentNotice.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadDelinquencyNoticeRecords()
        {
            var rptId = dtDelinquentNotice.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            var checkedRadioButton = flwLayoutType.Controls
                                      .OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            string noticeType;

            switch (checkedRadioButton.Name)
            {
                case "rad1stNotice":
                    noticeType = "1st Notice";
                    break;

                case "rad2ndNotice":
                    noticeType = "2nd Notice";
                    break;

                case "rad3rdNotice":
                    noticeType = "3rd Notice";
                    break;

                default:
                    noticeType = string.Empty;
                    break;
            }

            if (rptId is not null)
            {
                var dtNoticeDelinquencies = AccFactory.DelinquentNoticeRepository().GetViewRecordsByRptId(Convert.ToInt32(rptId), noticeType);
                cmbxDelinquentNoticeRecord.DataSource = dtNoticeDelinquencies;
                cmbxDelinquentNoticeRecord.ValueMember = "delinquent_notice_id";
                cmbxDelinquentNoticeRecord.DisplayMember = "notice_date";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void rad1stNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rad2ndNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rad3rdNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }
    }
}