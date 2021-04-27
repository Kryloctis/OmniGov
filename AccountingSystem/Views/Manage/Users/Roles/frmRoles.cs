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

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
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
            Helper.DatagridDefaultStyle(dgRoles);
            LoadRecords();
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 2, 3 };
            Helper.ShowRecordTimestamp(dgRoles, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRolesAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int roleId = int.Parse(dgRoles.SelectedCells[0].Value.ToString());
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
                            int roleId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            rolesModelList.Add(new RolesModel() { Id = roleId });
                        }

                        var rolesRepository = Factory.RolesRepository();
                        _ = rolesRepository.Delete(rolesModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
