using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class ucAllotmentClasses : UserControl
    {
        internal int allotmentId = 0;
        public ucAllotmentClasses()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epName.GetError(txtName);
            errorArray[1] = epCode.GetError(txtCode);


            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            txtCode.Clear();

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "Allotment class name");

            var allotmentClassesRepository = Factory.AllotmentClassesRepository();
            string allotmentName = txtName.Text.Trim();
            bool allotmentNameExist;

            if (allotmentId == 0)
                allotmentNameExist = allotmentClassesRepository.NameExist(allotmentName); // add form
            else
                allotmentNameExist = allotmentClassesRepository.NameExist(allotmentName, allotmentId); // edit form

            if (allotmentNameExist)
            {
                epName.SetError(txtName, "Allotment class name already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }


        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "Allotment class code");

            var allotmentClassesRepository = Factory.AllotmentClassesRepository();
            string allotmentCode = txtCode.Text.Trim();
            bool allotmentCodeExist;

            if (allotmentId == 0)
                allotmentCodeExist = allotmentClassesRepository.CodeExist(allotmentCode); // add form
            else
                allotmentCodeExist = allotmentClassesRepository.CodeExist(allotmentCode, allotmentId); // edit form

            if (allotmentCodeExist)
            {
                epCode.SetError(txtCode, "Allotment class code already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void ucAllotmentClasses_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
