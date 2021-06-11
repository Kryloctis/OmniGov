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
    public partial class frmRCDEdit : Form
    {
        private frmRCD _frmrcd;
        public frmRCDEdit(frmRCD frmrcd, int Id)
        {
            InitializeComponent();
            _frmrcd = frmrcd;
            ucrcd1.Id = Id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCD has been updated.");
                _frmrcd.LoadRecords();
                
            }
        }
        private bool SaveData()
        {
            try
            {
                var uc = ucrcd1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var rcdModel = new CollectorReportModel()
                {
                    Id = uc.Id,
                    CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                    ReportNo = uc.txtreport.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtdate.Value),
                    Approved = Convert.ToInt16(uc.chckapproved.Checked),
                };
                var rcdRepository = Factory.CollectorReportRepository();
                return rcdRepository.Update(rcdModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmRCDEdit_Load(object sender, EventArgs e)
        {
            ucrcd1.LoadCollectors();
            LoadSelectedValue();
         
        }

        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucrcd1;
                var rcdRepository = Factory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(uc.Id);
                uc.CoId = Convert.ToInt16(rcdData["collecting_officers_id"]);
                uc.cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtreport.Text = rcdData["report_no"];
                uc.dtdate.Value = Convert.ToDateTime(rcdData["date"]);
                uc.chckapproved.Checked = rcdData["is_approved"] == "0" ? false : true;

                uc.LoadCollections();

                uc.cmbcollector.Enabled = false;
                uc.txtreport.Enabled = false;
                uc.btnadd.Enabled = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
