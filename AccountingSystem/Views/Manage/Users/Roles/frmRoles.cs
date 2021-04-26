using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                int count = dgRoles.Rows.Count;
                if (count >= 1)
                {
                    dgRoles.Columns.RemoveAt(4);
                }

                var rolesRepository = Factory.RolesRepository();
                var dtRoles = rolesRepository.GetRecords();
                HelperLoadRecords.RolesDatagridView(dtRoles, dgRoles);

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                {
                   
                    button.Name = "btnAddPermissions";
                    button.HeaderText = "Manage";
                    button.Text = "Add Permissions";
                    button.UseColumnTextForButtonValue = true;
                    button.FlatStyle = FlatStyle.Standard;
                    button.CellTemplate.Style.BackColor = Color.Honeydew;
                    this.dgRoles.Columns.Insert( 4, button);
                }

                lblRecordCount.Text = rolesRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadDataBySearch()
        {

            try
            {

                dgRoles.Columns.RemoveAt(4);
                if (dgRoles.Rows.Count == 0)
                {
                    dgRoles.Columns.RemoveAt(4);
                }
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtRoles = Factory.RolesRepository().GetRecordsBySearch(searchkey);
                
                HelperLoadRecords.RolesDatagridView(dtRoles, dgRoles);
                if (dgRoles.Rows.Count >=1 )
                {

                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "btnAddPermissions";
                        button.HeaderText = "Manage";
                        button.Text = "Add Permissions";
                        button.UseColumnTextForButtonValue = true;
                        button.FlatStyle = FlatStyle.Standard;
                        button.CellTemplate.Style.BackColor = Color.Honeydew;
                        this.dgRoles.Columns.Insert(4, button);
                    }
                }
                lblRecordCount.Text = dgRoles.Rows.Count.ToString();
            }
            catch (Exception ex) {
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtRoles = Factory.RolesRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.RolesDatagridView(dtRoles, dgRoles);
                if (dgRoles.Rows.Count >= 1)
                {
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "btnAddPermissions";
                        button.HeaderText = "Manage";
                        button.Text = "Add Permissions";
                        button.UseColumnTextForButtonValue = true;
                        button.FlatStyle = FlatStyle.Standard;
                        button.CellTemplate.Style.BackColor = Color.Honeydew;
                        this.dgRoles.Columns.Insert(4, button);
                    }
                }
            }

        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataBySearch();
        }

        private void dgRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)

            {
                DataGridViewRow row = dgRoles.Rows[e.RowIndex];
                //MessageBox.Show(("Selected Row " + (e.RowIndex + 1).ToString() +"Role Id: " + row.Cells["id"].Value));
                int roleId = int.Parse(row.Cells["id"].Value.ToString());
                _ = new frmAddPermissions(this, roleId).ShowDialog();

            }
        }

        
    }
}
