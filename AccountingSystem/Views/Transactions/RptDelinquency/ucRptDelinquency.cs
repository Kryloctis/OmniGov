using ACC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RptDelinquency
{
    public partial class ucRptDelinquency : UserControl
    {

        private int delinquencyId;
        private string currentStat;
        public ucRptDelinquency()
        {
            InitializeComponent();
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxDelinquentPropertiesArpNo),
                errorProvider1.GetError(cmbxDelinquentStatus)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxDelinquentPropertiesArpNo.SelectedIndex = -1;
            cmbxDelinquentStatus.SelectedIndex = -1;
        }

        internal void OnLoad(bool isEdit, int delinquencyId = 0)
        {
            if (isEdit)
            {
                this.delinquencyId = delinquencyId;
                LoadSelectedRecord();
            }

            LoadDelinquetPropertiesArpNo();
            DelinquentStatus(isEdit);
        }

        internal void LoadSelectedRecord()
        {
            var dictRptDelinquency = AccFactory.RptDelinquenciesRepository().GetRecordByID(delinquencyId);
            cmbxDelinquentStatus.SelectedValue = Convert.ToInt32(dictRptDelinquency["id"]);
            cmbxDelinquentPropertiesArpNo.Enabled = false;
            currentStat = dictRptDelinquency["delinquency_status"].ToString();
        }


        private void LoadDelinquetPropertiesArpNo()
        {
            var dataTable = AccFactory.RptAssessmentPostsRepository().GetViewDeliquentRecords();
            cmbxDelinquentPropertiesArpNo.DataSource = dataTable;
            cmbxDelinquentPropertiesArpNo.ValueMember = "rpt_assessment_posts_id";
            cmbxDelinquentPropertiesArpNo.DisplayMember = "complete_arp_no";
            cmbxDelinquentPropertiesArpNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxDelinquentPropertiesArpNo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void DelinquentStatus(bool isEdit)
        {
            Dictionary<string, int> dictDelinquencyStatus = new Dictionary<string, int>();

            dictDelinquencyStatus.Add("Notified", 0);
            dictDelinquencyStatus.Add("First Notice Sent", 1);
            dictDelinquencyStatus.Add("Second Notice Sent", 2);
            dictDelinquencyStatus.Add("Third Notice Sent", 3);

            if (isEdit)
            {
                int index = dictDelinquencyStatus[currentStat];
                foreach (var item in dictDelinquencyStatus)
                {
                    if (index < item.Value)
                        cmbxDelinquentStatus.Items.Add(item.Key);
                }
                return;
            }
            cmbxDelinquentStatus.DataSource = dictDelinquencyStatus.ToList();
            cmbxDelinquentStatus.DisplayMember = "Key";
            cmbxDelinquentStatus.ValueMember = "Value";

        }
        private void ucRptDelinquency_Load(object sender, EventArgs e)
        {

        }

        #region Validation



        private void cmbxDelinquentPropertiesArpNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxDelinquentPropertiesArpNo, "Property.");

            string arpNo = cmbxDelinquentPropertiesArpNo.Text;

            if (cmbxDelinquentPropertiesArpNo.FindStringExact(arpNo) < 0)
            {
                errorProvider1.SetError(cmbxDelinquentPropertiesArpNo, "Property ARP no. doesn't exist");
                e.Cancel = true;
            }
        }

        private void cmbxDelinquentPropertiesArpNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxDelinquentPropertiesArpNo);
        }

        private void cmbxDelinquentStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxDelinquentStatus, "Delinquency Status.");
        }

        private void cmbxDelinquentStatus_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxDelinquentStatus);
        }
        #endregion


    }
}
