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
        public frmUsersEdit(frmUsers frmUsers, int userId)
        {
            InitializeComponent();
            _frmUsers = frmUsers;
            ucUsers1.userId = userId;
        }
        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucUsers1;
                var usersRepository = Factory.UsersRepository();
                var userData = usersRepository.GetRecordByID(uc.userId);


               uc.txtUsername.Text = userData["username"];
               uc.txtPassword.Text = userData["password"];
                //uc.txtRole.Text = userData["roles_id"];
                uc.txtFirstname.Text = userData["first_name"];
                uc.txtMiddleInitial.Text = userData["mid_initial"];
                uc.txtLastname.Text = userData["last_name"];
                
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
                    RoleId = ((byte)uc.cmbRoles.SelectedValue),

                };

                var usersRepository = Factory.UsersRepository();
                return usersRepository.Update(userModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

   

        private void frmUsersEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucUsers1.LoadRoleName();
            LoadSelectedRecord();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("User has been saved.");
                _frmUsers.LoadRecords();
                ucUsers1.ResetForm();
            }
        }
    }
}
