using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsersAdd : Form
    {
        private frmUsers _frmUsers;
        private ucUsers uc;

        public frmUsersAdd(frmUsers frmUsers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmUsers = frmUsers;
            uc = ucUsers1;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var userModel = new UsersModel()
            {
                RoleId = ((byte)uc.cmbRoles.SelectedValue),
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstname.Text.Trim(),
                MidInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastname.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                UserName = uc.txtUsername.Text.Trim(),
                Password = uc.txtPassword.Text.Trim(),
            };

            return AccFactory.UsersRepository().Insert(userModel);
        }

        private void frmUsersAdd_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("User has been saved.");
                    _frmUsers.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}