using ACC.Domain.Interfaces;
using AccountingSystem.Views.Manage.LinkUser;
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
        internal int UserId = 0;
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

           
                fullNameExist = collectingOfficerRepository.FullNameExist(fName,midInitial,lname,OfficerId); // add form
          

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


            fullNameExist = collectingOfficerRepository.FullNameExist(fName, midInitial, lname, OfficerId); // add form


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


            fullNameExist = collectingOfficerRepository.FullNameExist(fName, midInitial, lname, OfficerId); // add form


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

        private void ucCollectingOfficer_Load(object sender, EventArgs e)
        {

        }

        private void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserId > 0)
            {
                UserId = 0;
                linkuser.Text = "+ Link User";
            }
            else
            {
                frmlinkuser fuser = new frmlinkuser();
                fuser.table = "collector";
                if (fuser.ShowDialog() == DialogResult.OK)
                {
                    UserId = fuser.UserId;
                    linkuser.Text = String.Format("@{0}", fuser.Username);
                    if(txtLname.Text == string.Empty && txtFname.Text == string.Empty && txtMI.Text == string.Empty)
                    {
                        txtLname.Text = fuser.lname;
                        txtFname.Text = fuser.fname;
                        txtMI.Text = fuser.mname;
                    }
                }
            }

        }


        internal void LoadLink(int id)
        {
            try
            {
                var userRepository = Factory.UsersRepository();
                var data = userRepository.GetUserByID(id);
                if(data.Count > 0)
                {
                    UserId = id;
                    linkuser.Text = String.Format("@{0}", data["username"]);
                }
                else
                {
                    UserId = 0;
                    linkuser.Text = "+ Link User";
                }                
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
