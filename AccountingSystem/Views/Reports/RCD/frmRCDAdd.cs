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
        private List<CollectorReportPaymentModel> data;
        public frmRCDAdd(frmRCD frmrcd)
        {
            InitializeComponent();
            _frmrcd = frmrcd;
        }

        private void frmRCDAdd_Load(object sender, EventArgs e)
        {            
            ucrcd1.LoadCollectors();
            ucrcd1.LoadFunds();
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
                else if (uc.dgvpayments.Rows.Count <= 0)
                {
                    Helper.MessageBoxError("Please Load Payment Collection list!");
                    return false;
                }
                else{
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
                        int id = rcdRepository.InsertId(rcdModel);
                        if(id > 0)
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
                                        CoId = id,
                                        PcId = Convert.ToInt16(uc.dgvpayments.Rows[i].Cells[1].Value),
                                    });
                                }

                                var crpRepository = Factory.CollectorReportPaymentRepository();
                                return crpRepository.Append(data);
                            }
                           
                        }

                    }
                    else
                    {
                        Helper.ErrorMessage("Report Number already exists!");
                        uc.txtreport.Focus();
                    }
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
                uc.ResetForm();
                uc.cmbcollector.Enabled = true;
                uc.txtreport.Enabled = true;
            }
        }
    }
}
