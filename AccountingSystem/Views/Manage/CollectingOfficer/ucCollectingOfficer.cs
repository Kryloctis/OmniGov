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

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class ucCollectingOfficer : UserControl
    {
        internal int OfficerId = 0;
        public ucCollectingOfficer()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epFname.GetError(txtFname);
            errorArray[1] = epMI.GetError(txtMI);
            errorArray[2] = epLname.GetError(txtLname);
            errorArray[3] = epJobtitle.GetError(txtJobtitle);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }


        internal void ResetForm()
        {
            txtFname.Clear();
            txtMI.Clear();
            txtLname.Clear();
            txtJobtitle.Clear();
        }

        private void txtFname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFname, txtFname, "first name");

            var collectingOfficerRepository = Factory.CollectingOfficerRepository();
            string fName = txtFname.Text.Trim();
            string midInitial = txtMI.Text.Trim();
            string lname = txtLname.Text.Trim();
            bool fullNameExist;

           
                fullNameExist = collectingOfficerRepository.FullnameExist(fName,midInitial,lname,OfficerId); // add form
          

            if (fullNameExist)
            {
                epFname.SetError(txtFname, "Validation");              
                e.Cancel = true;
            }
        }

        private void txtFname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFname, txtFname);
        }

        private void txtMI_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epMI, txtMI);
        }

        private void txtMI_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epMI, txtMI, "middle initial");

            var collectingOfficerRepository = Factory.CollectingOfficerRepository();
            string fName = txtFname.Text.Trim();
            string midInitial = txtMI.Text.Trim();
            string lname = txtLname.Text.Trim();
            bool fullNameExist;


            fullNameExist = collectingOfficerRepository.FullnameExist(fName, midInitial, lname, OfficerId); // add form


            if (fullNameExist)
            {
                epMI.SetError(txtMI, "Officer's Fullname");
                e.Cancel = true;
            }
        }

        private void txtLname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epLname, txtLname, "last name");

            var collectingOfficerRepository = Factory.CollectingOfficerRepository();
            string fName = txtFname.Text.Trim();
            string midInitial = txtMI.Text.Trim();
            string lname = txtLname.Text.Trim();
            bool fullNameExist;


            fullNameExist = collectingOfficerRepository.FullnameExist(fName, midInitial, lname, OfficerId); // add form


            if (fullNameExist)
            {
                epLname.SetError(txtLname, "Fullname Details already exist in your records. ");
                e.Cancel = true;
            }
        }

        private void txtLname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epLname, txtLname);
        }
    }
}
