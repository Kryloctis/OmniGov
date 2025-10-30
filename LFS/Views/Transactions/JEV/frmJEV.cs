using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using LFS.Views.Dashboard;
using LFS.Views.Reports.JEV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class frmJev : Form
    {
        internal ucJev uc;
        internal ucJevDashboard ucJEVDashboard;
        internal int createdById;

        public frmJev(ucJevDashboard ucJEVDashboard)
        {
            InitializeComponent();
            uc = ucjev1;
            this.ucJEVDashboard = ucJEVDashboard;
            Helper.LoadFormIcon(this);
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            lblCreatedBy.Text = UserHelper.loggedUser.FullName;
            uc.SumDebitCredit();
            //VerifyUserPrivileges();
        }

        //private void VerifyUserPrivileges()
        //{
        //    if (!PrivilegesHelper.HasPrivilege(Privileges.TransJEV))
        //    {
        //        btnSave.Enabled = false;
        //        btnDelete.Enabled = false;
        //        uc.SetJevReadOnly(true);
        //    }

        //    if (!PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval))
        //    {
        //        btnApprove.Visible = false;
        //        btnDisapprove.Visible = false;
        //        btnCancelJEV.Visible = false;
        //        toolStripSeparator2.Visible = false;
        //    }

        //    btnPrint.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptJEVs);

        //    //Verify logged in user if able to access dissaproval message
        //    lblShowMessage.Enabled = createdById != UserHelper.loggedUser.Id
        //                             && !PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval);

        //    //Verify logged in user if user is the same who create the JEV for edit purposes only
        //    if (uc.isEdit && UserHelper.loggedUser.Id != createdById)
        //    {
        //        string jevStatus = AccFactory.JEVRepository().GetJevStatus(uc.jevId);

        //        btnSave.Enabled = false;
        //        btnDelete.Enabled = false;
        //        uc.SetJevReadOnly(true);

        //        if (PrivilegesHelper.HasPrivilege(Privileges.TransEditApprJEV) && jevStatus == "approved")
        //        {
        //            btnSave.Enabled = true;
        //            uc.SetJevReadOnly(false);
        //        }
        //    }
        //    else
        //        uc.SetJevReadOnly(false);
        //}

        internal bool FormValidations()
        {
            if (uc.tlStrpLblDebit.Text != uc.tlStrpLblCredit.Text)
            {
                Helper.MessageBoxError("Debit & Credit amounts must be equal.");
                return false;
            }

            return true;
        }

        //private bool DeleteData()
        //{
        //    if (MessageBox.Show("Are you sure you want to delete this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        var jevModel = new JevModel();
        //        jevModel.Id = uc.jevId;

        //        var jevRepository = AccFactory.JEVRepository();
        //        return jevRepository.Delete(jevModel);
        //    }
        //    return false;
        //}

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (SaveData())
            //    {
            //        if (!uc.isEdit)
            //        {
            //            Helper.MessageBoxSuccess("JEV has been saved");
            //            ucjev1.ResetForm();
            //            ucJEVDashboard.LoadJEVCounter();
            //        }
            //        else
            //        {
            //            int jevId = uc.jevId;
            //            Helper.MessageBoxSuccess("JEV has been updated");
            //            GetJevStatus(jevId);
            //            VerifyUserPrivileges();
            //            frmJEVList.LoadJEVList();
            //            ucJEVDashboard.LoadJEVCounter();
            //            Close();
            //        }
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        //private void TransferJournalToNewJournal()
        //{
        //    switch (uc.journalId)
        //    {
        //        case 1:
        //            var generalJournalModel = new GeneralJournalModel()
        //            {
        //                JevId = uc.jevId,
        //                //DVNo = uc.txtDVRCDNo.Text.Trim(),
        //                //CheckNo = uc.txtCheckNo.Text.Trim(),
        //                //ORNo = uc.txtRCIORADA.Text.Trim()
        //            };

        //            AccFactory.GeneralJournalRepository().Insert(generalJournalModel);
        //            return;

        //        case 2:
        //            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
        //            {
        //                JevId = uc.jevId,
        //                //CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
        //                //RCDNo = uc.txtDVRCDNo.Text.Trim(),
        //                //ORNo = uc.txtRCIORADA.Text.Trim(),
        //                //ORDate = uc.dtpCheckORPaid.Value
        //            };

        //            AccFactory.CashReceiptsJournalRepository().Insert(cashReceiptsJournalModel);
        //            return;

        //        case 3:
        //            //DO NOTHING
        //            return;

        //        case 4:
        //            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
        //            {
        //                JevId = uc.jevId,
        //                //DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
        //                //DVNo = uc.txtDVRCDNo.Text.Trim(),
        //                //DatePaid = uc.dtpCheckORPaid.Value
        //            };

        //            AccFactory.CashDisbursementsJournalRepository().Insert(cashDisbursementsJournalModel);
        //            return;

        //        case 5:

        //            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
        //            {
        //                JevId = uc.jevId,
        //                //CheckDate = uc.dtpCheckORPaid.Value,
        //                //CheckNo = uc.txtCheckNo.Text.Trim(),
        //                //DVNo = uc.txtDVRCDNo.Text.Trim(),
        //                //RCINo = uc.txtRCIORADA.Text.Trim()
        //            };

        //            AccFactory.CheckDisbursementsJournalRepository().Insert(checkDisbursementsModel);
        //            return;

        //        case 6:
        //            //DO NOTHING
        //            return;
        //    }
        //}

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DeleteData())
            //    {
            //        Helper.MessageBoxSuccess("JEV has been deleted.");
            //        frmJEVList.LoadJEVList();
            //        Close();
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //_ = new frmJEVReport(uc.jevId, uc.journalId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void GetJevStatus(int jevId)
        {
            string jevStatus = AccFactory.JEVRepository().GetJevStatus(jevId).ToLower();

            switch (jevStatus)
            {
                case "pending":
                    lblJevStatus.Text = "PENDING";
                    lblJevStatus.ForeColor = Color.FromArgb(216, 146, 22);
                    lblShowMessage.Visible = false;
                    btnPrint.Enabled = false;
                    btnApprove.Enabled = true;
                    btnDisapprove.Enabled = true;
                    btnCancelJEV.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    break;

                case "approved":
                    lblJevStatus.Text = "APPROVED";
                    lblJevStatus.ForeColor = Color.FromArgb(78, 159, 61);
                    lblShowMessage.Visible = false;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = true;
                    btnPrint.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    break;

                case "disapproved":
                    lblJevStatus.Text = "DISAPPROVED";
                    lblJevStatus.ForeColor = Color.FromArgb(149, 1, 1);
                    lblShowMessage.Visible = true;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = true;
                    btnPrint.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    break;

                case "cancelled":
                    lblJevStatus.Text = "CANCELLED";
                    lblJevStatus.ForeColor = Color.FromArgb(66, 63, 62);
                    lblShowMessage.Visible = false;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = false;
                    btnPrint.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (uc.isEdit)
            //    {
            //        if (UpdateData("approved"))
            //        {
            //            Helper.MessageBoxSuccess("JEV has been approved.");
            //            GetJevStatus(uc.jevId);
            //            uc.txtFundsJevNo.Text = uc.GenerateJevTemplateNo();
            //            uc.txtJEVNo.Text = uc.GetJEVSeriesNo();
            //            frmJEVList.LoadJEVList();
            //            ucJEVDashboard.LoadJEVCounter();
            //        }
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)"); }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (uc.jevId != 0)
            //    {
            //        var frmRemarks = new frmJevDisapproval(this);
            //        frmRemarks.btnDisapprove.Visible = true;
            //        frmRemarks.btnAccept.Visible = false;
            //        frmRemarks.btnSaveMessage.Visible = false;
            //        frmRemarks.ShowDialog();
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (uc.jevId != 0)
            //    {
            //        var frmRemarks = new frmJevDisapproval(this);
            //        frmRemarks.btnDisapprove.Visible = false;
            //        frmRemarks.btnCancel.Text = "Close";
            //        frmRemarks.ShowDialog();
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            //try
            //{
            //    if (uc.jevId != 0)
            //    {
            //        var frmRemarks = new frmJevDisapproval(this);
            //        frmRemarks.btnDisapprove.Visible = false;
            //        frmRemarks.btnCancel.Text = "Close";
            //        frmRemarks.ShowDialog();
            //    }
            //}
            //catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}