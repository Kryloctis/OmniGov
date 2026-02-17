using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.AccountableForm
{
    public partial class frmEditAccountableForm : Form
    {
        private readonly frmAccountableForm _frmAccountable;
        private readonly ucAccountableForm uc;

        public frmEditAccountableForm(frmAccountableForm frmAccountable, int accountableFormId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmAccountable = frmAccountable;
            uc = ucAccountable1;
            uc.accountableFormId = accountableFormId;
        }

        private void LoadSelectedRecord()
        {
            var uc = ucAccountable1;
            var accData = TreasuryFactory.AccountableFormsRepository().GetRecordByID(uc.accountableFormId);
            uc.txtFormNo.Text = accData["acc_form_no"];
            uc.txtFormDescription.Text = accData["acc_form_desc"];
        }

        private void frmAccountableEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = true;
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var accModel = new AccountableFormsModel()
            {
                Id = uc.accountableFormId,
                AccFormNo = uc.txtFormNo.Text.Trim(),
                AccFormDesc = uc.txtFormDescription.Text.Trim(),
                IsCashTicket = uc.cbIsCashTickets.Checked,
            };

            return TreasuryFactory.AccountableFormsRepository().Update(accModel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountableForm();
        }

        private void UpdateAccountableForm()
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Accountable Form has been updated.");
                    _frmAccountable.LoadRecords();
                    this.Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditAccountableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                UpdateAccountableForm();
            }
        }
    }
}
