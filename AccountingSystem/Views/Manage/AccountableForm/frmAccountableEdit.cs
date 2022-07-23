using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAccountableEdit : Form
    {
        private frmAccountable _frmacc;
        public frmAccountableEdit(frmAccountable frmacc,int accId)
        {
            InitializeComponent();
            _frmacc = frmacc;
            ucAccountable1.accId = accId;
        }
        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucAccountable1;
                var accRepository = AccFactory.AccountableFormsRepository();
                var accData = accRepository.GetRecordByID(uc.accId);
                uc.txtformno.Text = accData["acc_form_no"];
                uc.txtformdesc.Text = accData["acc_form_desc"];


            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmAccountableEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucAccountable1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var accModel = new AccountableModel()
                {
                    Id = uc.accId,
                    AccFormNo = uc.txtformno.Text.Trim(),
                    AccFormDesc = uc.txtformdesc.Text.Trim()

                };

                var accrepository = AccFactory.AccountableFormsRepository();
                return accrepository.Update(accModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Accountable Form has been updated.");
                _frmacc.LoadRecords();
            }
        }
    }
}
