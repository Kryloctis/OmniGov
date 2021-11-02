using ACC.Domain.Models;
using MySql.Data.MySqlClient;
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
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        internal void LoadRoles()
        {
            try
            {
                var rolesRepository = Factory.RolesRepository();
                var dtRoles = rolesRepository.GetRecords();
                HelperLoadRecords.RolesDatagridView(dtRoles, dgRoles);

                lblRecordCount.Text = rolesRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRoles, true);
            LoadRoles();
            Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
        }

        private void LoadPermissionsByRoleId(byte roleId)
        {
            lstboxAuthorize.DataSource = Factory.RoleHasPermissionsRepository().GetRecordsByRoleId(roleId);
            lstboxAuthorize.DisplayMember = "permission_name";
            lstboxAuthorize.ValueMember = "permissions_id";
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRoles.SelectedRows.Count == 1)
                LoadPermissionsByRoleId(Convert.ToByte(dgRoles.SelectedCells[0].Value));
            else
            {
                lstboxAuthorize.DataSource = null;
                lstboxAuthorize.Items.Clear();
            }

            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgRoles, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRolesAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            byte roleId = byte.Parse(dgRoles.SelectedCells[0].Value.ToString());
            _ = new frmRolesEdit(this, roleId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgRoles.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var rolesModelList = new List<RolesModel>();
                        foreach (DataGridViewRow row in dgRoles.SelectedRows)
                        {
                            byte roleId = Convert.ToByte(row.Cells[0].Value.ToString());
                            rolesModelList.Add(new RolesModel() { Id = roleId });
                        }

                        var rolesRepository = Factory.RolesRepository();
                        _ = rolesRepository.Delete(rolesModelList);
                        LoadRoles();
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                switch (mysqlEx.Number)
                {
                    case 1451:
                        Helper.MessageBoxError("Cannot delete role because it is referenced to another record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
