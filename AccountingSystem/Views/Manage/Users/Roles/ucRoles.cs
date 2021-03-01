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

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        internal int roleId = 0;
        public ucRoles()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
           
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "role name");

            var rolesRepository = Factory.RolesRepository();
            string roleName = txtName.Text.Trim();
            bool roleNameExist;

            if (roleId == 0)
                roleNameExist = rolesRepository.NameExist(roleName); // add form
            else
                roleNameExist = rolesRepository.NameExist(roleName, roleId); // edit form

            if (roleNameExist)
            {
                epName.SetError(txtName, "Role name already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}
