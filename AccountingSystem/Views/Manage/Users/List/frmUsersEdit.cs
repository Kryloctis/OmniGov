using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsersEdit : Form
    {
        private frmUsers _frmUsers;
        private ucUsers uc;

        public frmUsersEdit(frmUsers frmUsers, int userId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _frmUsers = frmUsers;
            uc = ucUsers1;
            uc.userId = userId;
        }

        private void LoadSelectedRecord()
        {
            var dictUser = AccFactory.UsersRepository().GetRecordByID(uc.userId);
            var dictRoles = AccFactory.RolesRepository().GetRecordByID(Convert.ToInt32(dictUser["roles_id"]));

            uc.cmbOffice.Text = dictRoles["office"];
            uc.cmbRoles.SelectedValue = dictUser["roles_id"];
            uc.txtPrefix.Text = dictUser["prefix"];
            uc.txtFirstname.Text = dictUser["first_name"];
            uc.txtMiddleInitial.Text = dictUser["mid_initial"];
            uc.txtLastname.Text = dictUser["last_name"];
            uc.txtSuffix.Text = dictUser["suffix"];
            uc.txtUsername.Text = dictUser["username"];
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var userModel = new UsersModel()
            {
                Id = uc.userId,
                UserName = uc.txtUsername.Text.Trim(),
                Password = uc.txtPassword.Text.Trim(),
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstname.Text.Trim(),
                MidInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastname.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                RoleId = (byte)uc.cmbRoles.SelectedValue,
            };

            if (string.IsNullOrWhiteSpace(uc.txtPassword.Text))
                return AccFactory.UsersRepository().Update(userModel);
            else
                return AccFactory.UsersRepository().UpdateWithPassword(userModel);
        }

        private void frmUsersEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
            uc.txtUsername.ReadOnly = true;
            uc.lblPassword.Text = "New Password";
            uc.lblConfirmPassword.Text = $"Confirm New{Environment.NewLine}Password";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("User has been saved.");
                    uc.txtPassword.Clear();
                    uc.txtConfirmPassword.Clear();
                    _frmUsers.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}