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
        private List<CollectorReportPaymentModel> data;
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
                ucrcd1.LoadCollections();
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
                bool saved = rcdRepository.Update(rcdModel);
                if (saved)
                {
                    if (uc.dgvpayments.Rows.Count > 0)
                    {
                        data = new List<CollectorReportPaymentModel>();
                        data.Clear();
                        for (int i = 0; i < uc.dgvpayments.Rows.Count; i++)
                        {
                            data.Add(new CollectorReportPaymentModel()
                            {
                                Id = Convert.ToInt16(uc.dgvpayments.Rows[i].Cells[0].Value),
                                CoId = uc.Id,
                                PcId = Convert.ToInt16(uc.dgvpayments.Rows[i].Cells[1].Value),
                            });
                        }

                        var crpRepository = Factory.CollectorReportPaymentRepository();
                        return crpRepository.Append(data);
                    }
                }

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
            ucrcd1.LoadFunds();
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
                uc.Fid = Convert.ToInt32(rcdData["funds_id"]);
                uc.cmbfund.SelectedValue = rcdData["funds_id"];
                uc.cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtreport.Text = rcdData["report_no"];
                uc.dtdate.Value = Convert.ToDateTime(rcdData["date"]);                

                uc.LoadCollections();
                uc.chckapproved.Checked = rcdData["is_approved"] == "0" ? false : true;
                uc.cmbcollector.Enabled = false;
                uc.cmbfund.Enabled = false;
                uc.txtreport.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
