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
            if(ucrcd1.Id > 0)
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("RCD has been updated.");
                    ucrcd1.LoadCollections();
                    _frmrcd.LoadRecords();

                }
            }
            else
            {
                if(SaveData())
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

        private void ButtonToolsInitialize()
        {
            var uRepository = Factory.UsersRepository();
            bool is_liquidate = uRepository.GetUserRole(Helper.UserId) == "Liquidating Officer" ? true : false;
            if (is_liquidate)
            {
                ucrcd1.btnadd.Visible = false;
                ucrcd1.btndelete.Visible = false;
                ucrcd1.btnclear.Visible = false;
                btnApprove.Visible = true;
                btnDisapprove.Visible = true;
            }
            else
            {
                ucrcd1.btnadd.Visible = true;
                ucrcd1.btndelete.Visible = true;
                ucrcd1.btnclear.Visible = true;
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
            }

            btnDelete.Enabled = ucrcd1.Id > 0 ? true : false;
            btnCancel.Enabled = ucrcd1.Id > 0 ? true : false;
            btnPrint.Enabled = ucrcd1.Id > 0 ? true : false;
            btnApprove.Enabled = ucrcd1.Id > 0 ? ucrcd1.approved > 0 ? false : true : false;
            btnDisapprove.Enabled = ucrcd1.Id > 0 ? ucrcd1.approved > 0 ? true : false : false;
            statusStrip.Visible = ucrcd1.Id > 0 ? ucrcd1.approved > 0 ? false : true : false;
        }

        private bool DeleteData()
        {
            try
            {
                if(ucrcd1.Id > 0)
                {
                    List<CollectorReportModel> entity = new List<CollectorReportModel>();
                    entity.Add(new CollectorReportModel()
                    {
                        Id = ucrcd1.Id
                    });
                    if (Helper.MessageBoxConfirmDelete(1))
                    {
                        var rcdRepository = Factory.CollectorReportRepository();
                        return rcdRepository.Delete(entity);
                    }
                }
            }catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool Approved(int is_approved)
        {
            try {
                if (ucrcd1.Id > 0)
                {
                    CollectorReportModel model = new CollectorReportModel()
                    {
                        Id = ucrcd1.Id,
                        Approved = is_approved
                    };
                    var rcdRepository = Factory.CollectorReportRepository();
                    return rcdRepository.Approved(model);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool Cancel()
        {
            try
            {
                if (ucrcd1.Id > 0)
                {
                    var rcdRepository = Factory.CollectorReportRepository();
                    return rcdRepository.Cancel(ucrcd1.Id);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
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
                else
                {
                    var rcdModel = new CollectorReportModel()
                    {
                        CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                        ReportNo = uc.txtreport.Text.Trim(),
                        Date = Convert.ToDateTime(uc.dtdate.Value),
                        Approved = uc.approved,
                        Fid = uc.Fid,
                        status = uc.status
                    };
                    var rcdRepository = Factory.CollectorReportRepository();
                    if (!rcdRepository.CodeExist(uc.txtreport.Text.Trim()))
                    {
                        int id = rcdRepository.InsertId(rcdModel);
                        if (id > 0)
                        {
                            uc.Id = id;
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
        private bool UpdateData()
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
                    Approved = uc.approved,
                    Fid = uc.Fid,
                    status = uc.status
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
            if(ucrcd1.Id > 0)
            {
                LoadSelectedValue();
            }
            else
            {
                if (ucrcd1.cmbcollector.Items.Count > 0)
                {
                    var uRepository = Factory.UsersRepository();
                    if (uRepository.LinkedCollector(Helper.UserId))
                    {
                        var colRepository = Factory.CollectingOfficerRepository();
                        var data = colRepository.GetRecordByUserID(Helper.UserId);
                        ucrcd1.cmbcollector.SelectedValue = data["id"];
                        ucrcd1.cmbcollector.Enabled = false;
                    }

                    ButtonToolsInitialize();
                }
            }          
           

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
                uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == Convert.ToInt16(rcdData["funds_id"])) ? r.Checked = true : r.Checked = false);
                uc.cmbcollector.SelectedValue = rcdData["collecting_officers_id"];
                uc.txtreport.Text = rcdData["report_no"];
                uc.dtdate.Value = Convert.ToDateTime(rcdData["date"]);
                uc.approved = int.Parse(rcdData["is_approved"]);
                uc.status = rcdData["status"];
                lblStatus.Text = rcdData["status"];
                uc.remarks = rcdData["remarks"];
                uc.LoadCollections();
                uc.cmbcollector.Enabled = false;
                uc.txtreport.Enabled = false;

                ButtonToolsInitialize();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteData())
            {
                Helper.MessageBoxSuccess("RCD has been deleted.");
                _frmrcd.LoadRecords();
                var uc = ucrcd1;
                uc.ResetForm();
                uc.cmbcollector.Enabled = true;
                uc.txtreport.Enabled = true;
                ButtonToolsInitialize();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (Approved(1))
            {
                _frmrcd.LoadRecords();
                ucrcd1.approved = 1;
                ucrcd1.status = "COMPLETED";
                ButtonToolsInitialize();
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (Approved(0))
            {
                _frmrcd.LoadRecords();
                ucrcd1.approved = 0;
                ucrcd1.status = "PENDING";
                ButtonToolsInitialize();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancel())
            {
                if (Approved(0))
                {
                    _frmrcd.LoadRecords();
                    ucrcd1.approved = 0;
                    ucrcd1.status = "CANCELLED";
                    ButtonToolsInitialize();
                }
            }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            if(ucrcd1.Id > 0)
            {
                _ = new frmRemarks(ucrcd1.Id).ShowDialog();
            }
        }
    }
}
