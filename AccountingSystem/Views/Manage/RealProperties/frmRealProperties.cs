using ACC.Domain.Models;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditRealProperties().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnSynchronize_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var realProperiesModelList = new List<RealPropertiesModel>();
                var dtPropertyAssessmentPosting = RptFactory.RealPropertiesRepository().GetViewPropertyAssessmentPostingRecords();
                int inputCount = 0;

                foreach (DataRow row in dtPropertyAssessmentPosting.Rows)
                {
                    string propertyIdentifier = row["real_properties_identifier"].ToString();
                    string completeArpNo = row["complete_arp_no"].ToString();
                    string pin = row["pin"].ToString();
                    string ownerName = row["owner_name"].ToString();
                    string ownerTin = row["owner_tin"].ToString();
                    string ownerAddress = row["owner_address"].ToString();
                    string ownerContact = row["owner_contact"].ToString();
                    string barangayName = row["barangays_name"].ToString();
                    string municipalityName = row["municipality_name"].ToString();
                    string provinceName = row["provinces_name"].ToString();
                    string propertyKind = row["property_kind"].ToString();
                    int effectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    decimal otherImprovements = Convert.ToDecimal(row["other_improvements"]);
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal area = Convert.ToDecimal(row["land_area"]);
                    string lotNo = row["land_lot_no"].ToString();
                    string classificationCode = row["classification_code"].ToString();
                    string classificationName = row["classification_name"].ToString();
                    string actualUseCode = row["actual_use_code"].ToString();
                    string actualUseName = row["actual_use_name"].ToString();
                    int grYear = Convert.ToInt32(row["gryear"]);
                    bool isTaxable = Convert.ToBoolean(Convert.ToByte(row["is_taxable"]));
                    bool isCancelled = Convert.ToBoolean(Convert.ToByte(row["is_cancelled"]));

                    var realPropertiesModel = new RealPropertiesModel()
                    {
                        PropertyIdentifier = propertyIdentifier,
                        CompleteArpNo = completeArpNo,
                        Pin = pin,
                        OwnerName = ownerName,
                        OwnerTin = ownerTin,
                        OwnerAddress = ownerAddress,
                        OwnerContact = ownerContact,
                        BarangayName = barangayName,
                        MunicipalityName = municipalityName,
                        ProvinceName = provinceName,
                        PropertyKind = propertyKind,
                        EffectivityQuarter = effectivityQuarter,
                        EffectivityYear = effectivityYear,
                        OtherImprovements = otherImprovements,
                        AssessedValue = assessedValue,
                        Area = area,
                        LotNo = lotNo,
                        ClassificationCode = classificationCode,
                        ClassificationName = classificationName,
                        ActualUseCode = actualUseCode,
                        ActualUseName = actualUseName,
                        GrYear = grYear,
                        IsTaxable = isTaxable,
                        IsCancelled = isCancelled
                    };

                    realProperiesModelList.Add(realPropertiesModel);
                    int totalRows = dtPropertyAssessmentPosting.Rows.Count;
                    inputCount += 1;

                    backgroundWorker1.ReportProgress((inputCount * 100) / totalRows, "Sychronizing Data...");
                }

                AccFactory.RealPropertiesRepository().SynchronizeData(realProperiesModelList);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            lblProgressStatus.Visible = true;

            toolStripProgressBar1.Value = e.ProgressPercentage;
            lblProgressStatus.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (toolStripProgressBar1.Value == 100)
            {
                lblProgressStatus.Text = "Done.";
                Helper.MessageBoxSuccess("Real Properties has been synchronized");
                lblProgressStatus.Visible = false;
                toolStripProgressBar1.Visible = false;
            }
        }
    }
}