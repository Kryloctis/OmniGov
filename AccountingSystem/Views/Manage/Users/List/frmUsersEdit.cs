using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _frmUsers = frmUsers;
            uc = ucUsers1;
            uc.userId = userId;

        }

        private void LoadSelectedRecord()
        {
            try
            {
                var usersRepository = Factory.UsersRepository();
                var userData = usersRepository.GetRecordByID(uc.userId);
                var dictRoles = Factory.RolesRepository().GetRecordByID(Convert.ToInt32(userData["roles_id"]));


                uc.cmbOffice.Text = dictRoles["office"];
                uc.cmbRoles.SelectedValue = userData["roles_id"];
                uc.txtFirstname.Text = userData["first_name"];
                uc.txtMiddleInitial.Text = userData["mid_initial"];
                uc.txtLastname.Text = userData["last_name"];
                uc.txtUsername.Text = userData["username"];

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucUsers1;


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
                    FirstName = uc.txtFirstname.Text.Trim(),
                    MidInitial = uc.txtMiddleInitial.Text.Trim(),
                    LastName = uc.txtLastname.Text.Trim(),
                    RoleId = (byte)uc.cmbRoles.SelectedValue,

                };

                if (string.IsNullOrWhiteSpace(uc.txtPassword.Text))
                    return Factory.UsersRepository().Update(userModel);
                else
                    return Factory.UsersRepository().UpdateWithPassword(userModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmUsersEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();

            uc.txtUsername.ReadOnly = true;
            uc.lblPassword.Text = "New Password";
            uc.lblConfirmPassword.Text = $"Confirm New{Environment.NewLine}Password";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("User has been saved.");
                uc.txtPassword.Clear();
                uc.txtConfirmPassword.Clear();
                _frmUsers.LoadRecords();
                
            }
        }
    }
}
