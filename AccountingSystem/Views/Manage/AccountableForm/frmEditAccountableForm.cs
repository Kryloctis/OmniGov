using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmEditAccountableForm : Form
    {
        private frmAccountableForm _frmAccountable;
        private ucAccountableForm uc;

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
            var accRepository = AccFactory.AccountableFormsRepository();
            var accData = accRepository.GetRecordByID(uc.accountableFormId);
            uc.txtformno.Text = accData["acc_form_no"];
            uc.txtformdesc.Text = accData["acc_form_desc"];
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

            var accModel = new AccountableModel()
            {
                Id = uc.accountableFormId,
                AccFormNo = uc.txtformno.Text.Trim(),
                AccFormDesc = uc.txtformdesc.Text.Trim()
            };

            return AccFactory.AccountableFormsRepository().Update(accModel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
    }
}