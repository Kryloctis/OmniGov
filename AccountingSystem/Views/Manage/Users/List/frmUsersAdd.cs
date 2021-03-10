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
    public partial class frmUsersAdd : Form
    {
        
        private frmUsers _frmUsers;
       
        public frmUsersAdd(frmUsers frmUsers)
        {
            InitializeComponent();
            _frmUsers = frmUsers;
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

                // proceed to insert
                var userModel = new UsersModel()
                {

                    RoleId = ((byte)uc.cmbRoles.SelectedValue),
                    FirstName = uc.txtFirstname.Text.Trim(),
                    MidInitial = uc.txtMiddleInitial.Text.Trim(),
                    LastName = uc.txtLastname.Text.Trim(),
                    UserName = uc.txtUsername.Text.Trim(),
                    Password = uc.txtPassword.Text.Trim(),

                };

                var usersRepository = Factory.UsersRepository();
                return usersRepository.Insert(userModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmUsersAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
            //LoadRecords();
            
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {

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

       

        private void frmUsersAdd_Load_1(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
            ucUsers1.LoadRoleName();
        }
    }
}
