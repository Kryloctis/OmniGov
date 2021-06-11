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
    public partial class frmRCDAdd : Form
    {
        private frmRCD _frmrcd;
        public frmRCDAdd(frmRCD frmrcd)
        {
            InitializeComponent();
            _frmrcd = frmrcd;
        }

        private void frmRCDAdd_Load(object sender, EventArgs e)
        {            
            ucrcd1.LoadCollectors();
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
                    CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                    ReportNo = uc.txtreport.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtdate.Value),
                    Approved = Convert.ToInt16(uc.chckapproved.Checked),
                };
                var rcdRepository = Factory.CollectorReportRepository();
                if (!rcdRepository.CodeExist(uc.txtreport.Text.Trim()))
                {
                    return rcdRepository.Insert(rcdModel);
                }
                else
                {
                    Helper.ErrorMessage("Report Number already exists!");
                    uc.txtreport.Focus();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmRCDAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCD has been saved.");
                _frmrcd.LoadRecords();
                var uc = ucrcd1;
                uc.SetId(uc.txtreport.Text.Trim());
                uc.cmbcollector.Enabled = false;
                uc.txtreport.Enabled = false;
                uc.btnadd.Enabled = true;
                if (Helper.MessageBoxConfirmRCDList())
                {                    
                    _ = new frmGenerateRCD(uc, Convert.ToInt16(uc.cmbcollector.SelectedValue), uc.txtreport.Text.Trim()).ShowDialog();
                }
                else
                {
                    uc.ResetForm();
                    uc.cmbcollector.Enabled = true;
                    uc.txtreport.Enabled = true;
                    uc.btnadd.Enabled = false;
                }


            }
        }
    }
}
