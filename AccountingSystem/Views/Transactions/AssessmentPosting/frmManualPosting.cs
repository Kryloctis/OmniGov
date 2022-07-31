using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.AssessmentPosting
{
    public partial class frmManualPosting : Form
    {
        public frmManualPosting()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmManualPosting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Post Property?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Property successfully posted.");
                    Close();
                }
            }
            return;
        }

        private bool SaveData()
        {
            string completeArpNo = txtARPNo.Text;
            string propertyPIN = txtPIN.Text;
            string ownerName = txtOwner.Text;
            string barangayCode = txtBarangayCode.Text;
            string barangayName = txtBarangayName.Text;
            string municipalityCode = txtMunicipalityCode.Text;
            string municipalityName = txtMunicipalityName.Text;
            string provinceCode = txtProvinceCode.Text;
            string provinceName = txtProvinceName.Text;
            string propertyKind = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
            int effectivityQuarter = Convert.ToInt32(txtEffectivityQuarter.Text);
            int effectivityYear = Convert.ToInt32(txtEffectivityYear.Value);
            decimal assessedValue = nudAssessmentValue.Value;
            bool isTaxable = cbTaxable.Checked ? true : false;
            bool isCancelled = cbCancelled.Checked ? true : false;
            DateTime postedAt = DateTime.Now;
            decimal penaltyRate = AccFactory.rptPenaltiesRepository().GetPenaltyRate();
            string penaltyFrequency = AccFactory.rptPenaltiesRepository().GetPenaltyFrequency();
            decimal basicRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("BSC");
            decimal sefRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("SEF");

            var assessmentPostingModel = new AssessmentPostingModel()
            {
                CompleteArpNo = completeArpNo,
                PropertyPin = propertyPIN,
                OwnerName = ownerName,
                BarangayName = barangayName,
                MunicipalityName = municipalityName,
                ProvinceName = provinceName,
                PropertyKind = propertyKind,
                EffectivityQuarter = effectivityQuarter,
                EffectivityYear = effectivityYear,
                AssessedValue = assessedValue,
                IsTaxable = isTaxable,
                IsCancelled = isCancelled,
                PostedAt = postedAt,
                PenaltyRate = penaltyRate,
                PenaltyFrequency = penaltyFrequency,
                BasicRate = basicRate,
                SefRate = sefRate
            };

            AccFactory.AssessmentPostsRepository().Insert(assessmentPostingModel);
             
            return true;
        }

    }
}
