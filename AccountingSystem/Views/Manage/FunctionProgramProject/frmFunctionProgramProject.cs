using ACC.Domain.Models;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService;
using AccountingSystem.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject
{
    public partial class frmFunctionProgramProject : Form
    {
        public frmFunctionProgramProject()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgFunctionalClassification, true);
            Helper.DatagridFullRowSelectStyle(dgFuntionalClassificationService, true);
            Helper.DatagridFullRowSelectStyle(dgFunctionalProgramProject, true);
            Helper.DatagridFullRowSelectStyle(dgFunctionalProgramProject, true);
            HelperLoadRecords.FunctionProjectProgramDatagridView(dgFunctionalProgramProject);
        }


        internal void LoadFunctionalClassificationRecords()
        {
            try
            {
                txtSearch.Clear();
                var dtFunctionalClassification = Factory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.FuntionalClassificationDatagridView(dtFunctionalClassification, dgFunctionalClassification);

                lblRecordCount.Text = Factory.FunctionalClassificationRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadFunctionalClassificationServicesRecordsByGroup()
        {

            try
            {
                txtSearch.Clear();
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
                var dtfunctionProgramProjectServiceRepository = Factory.FunctionalClassificationServiceRepository().GetViewRecordsByClassificationId(id);
                HelperLoadRecords.FuntionalClassificationServiceDatagridView(dtfunctionProgramProjectServiceRepository, dgFuntionalClassificationService);

                lblRecordCount.Text = dgFuntionalClassificationService.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        internal void LoadFunctionalClassificationServicesRecords()
        {
            try
            {
                txtSearch.Clear();
                var dtfunctionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository().GetRecords();
                HelperLoadRecords.FuntionalClassificationServiceDatagridView(dtfunctionalClassificationServiceRepository, dgFuntionalClassificationService);

                lblRecordCount.Text = Factory.FunctionalClassificationServiceRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region FPP

        public void LoadServiceNameComboBox()
        {
            try
            {
                cmbServiceName.SelectedValueChanged -= new EventHandler(CmbServiceName_SelectedValueChanged);
                DataTable dtServiceName = new DataTable();

                dtServiceName.Columns.Add("id");
                dtServiceName.Columns.Add("service_name");

                dtServiceName.Rows.Add(0, "All");

                foreach (DataRow item in Factory.FunctionalClassificationServiceRepository().GetRecords().Rows)
                {
                    var items = new object[]
                    {
                       item["id"],
                       item["service_name"]
                    };

                    dtServiceName.Rows.Add(items);
                };

                HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbServiceName, "service_name", "id");
                cmbServiceName.SelectedValueChanged += new EventHandler(CmbServiceName_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable FPPDatatable(string searchText, int serviceId, bool isSpecial)
        {
            DataTable fppDataTable;

            if (serviceId == 0)
                fppDataTable = Factory.FunctionProgramProjectRepository().GetViewRecordsBySearch_And_IsSpecial(searchText, isSpecial);
            else
                fppDataTable = Factory.FunctionProgramProjectRepository().GetViewRecordsByService_And_Search_And_IsSpecial(serviceId, searchText, isSpecial);


            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("fpp_code");
            dataTable.Columns.Add("fpp_name");
            dataTable.Columns.Add("functional_classification_services_id");
            dataTable.Columns.Add("service_name");
            dataTable.Columns.Add("is_special");
            dataTable.Columns.Add("created_at");
            dataTable.Columns.Add("updated_at");

            foreach (DataRow row in fppDataTable.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowFPPCode = row["fpp_code"].ToString();
                string rowFPPName = row["fpp_name"].ToString();
                int rowFunctionalClassificationServicesId = Convert.ToInt32(row["functional_classification_services_id"]);
                string rowServiceName = row["service_name"].ToString();
                bool rowIsSpecial = Convert.ToBoolean(row["is_special"]);
                var rowCreatedAt = row["created_at"];
                var rowUpdatedAt = row["updated_at"];

                dataTable.Rows.Add(rowId, rowFPPCode, rowFPPName, rowFunctionalClassificationServicesId, rowServiceName, rowIsSpecial, rowCreatedAt, rowUpdatedAt);
            }

            return dataTable;
        }

        internal void LoadFPP()
        {
            try
            {
                dgFunctionalProgramProject.Rows.Clear();
                Image continuingIcon = Properties.Resources.ok14px;
                string searchText = txtSearch.Text.Trim();
                int serviceId = Convert.ToInt32(cmbServiceName.SelectedValue);
                bool isSpecial = chckbxSpecial.Checked;

                foreach (DataRow row in FPPDatatable(searchText, serviceId, isSpecial).Rows)
                {
                    bool rowIsSpecial = Convert.ToBoolean(row["is_special"]);

                    Image rowIsSpecialImage = rowIsSpecial ? continuingIcon : null;

                    dgFunctionalProgramProject.Rows.Add(row["id"], row["fpp_code"], row["fpp_name"], row["functional_classification_services_id"], row["service_name"], rowIsSpecialImage, row["created_at"], row["updated_at"]);
                }

                lblRecordCount.Text = dgFunctionalProgramProject.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbServiceName_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadFPP();
        }

        private void dgFunctionalProgramProject_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 6, 7 };
            Helper.ShowRecordTimestamp(dgFunctionalProgramProject, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalProgramProject, btnEdit, btnDelete);

            if (dgFunctionalProgramProject.SelectedRows.Count == 1)
                btnSubFPP.Enabled = true;
            else if (dgFunctionalProgramProject.SelectedRows.Count < 1)
                btnSubFPP.Enabled = false;
            else
                btnSubFPP.Enabled = false;
        }

        private void chckbxSpecial_CheckedChanged(object sender, EventArgs e)
        {
            LoadFPP();
        }

        #endregion

        private void ShowOthersFPP()
        {
            int functionProgramProjectID = Convert.ToInt32(dgFunctionalProgramProject.SelectedCells[0].Value);
            var frmOthersFunctionProgramProject = new frmOthersFunctionProgramProject();
            frmOthersFunctionProgramProject.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProject.ShowDialog();
        }


        private void frmFunctionProgramProject_Load(object sender, EventArgs e)
        {
            LoadFunctionalClassificationServicesRecords();


            LoadSectorNameComboBox();
            LoadFunctionalClassificationServicesRecordsByGroup();
            LoadServiceNameComboBox();

            LoadFPP();
            LoadFunctionalClassificationRecords();

        }

        private void DeleteFunctionalClassificationRecords()
        {
            int selectedRowsCount = dgFunctionalClassification.SelectedRows.Count;

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var functionalClassificationModelList = new List<FunctionalClassificationModel>();
                        foreach (DataGridViewRow row in dgFunctionalClassification.SelectedRows)
                        {
                            int functionalClassificationId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            functionalClassificationModelList.Add(new FunctionalClassificationModel() { Id = functionalClassificationId });
                        }

                        var functionalClassificationRepository = Factory.FunctionalClassificationRepository();
                        _ = functionalClassificationRepository.Delete(functionalClassificationModelList);
                        LoadFunctionalClassificationRecords();
                        LoadSectorNameComboBox();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void DeleteFunctionalClassificationServiceRecords()
        {
            int selectedRowsCount = dgFuntionalClassificationService.SelectedRows.Count;

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var functionalClassificationServiceModelList = new List<FunctionalClassificationServiceModel>();
                        foreach (DataGridViewRow row in dgFuntionalClassificationService.SelectedRows)
                        {
                            int serviceId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            functionalClassificationServiceModelList.Add(new FunctionalClassificationServiceModel() { Id = serviceId });
                        }

                        var functionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository();
                        _ = functionalClassificationServiceRepository.Delete(functionalClassificationServiceModelList);
                        LoadFunctionalClassificationServicesRecords();
                        LoadServiceNameComboBox();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void DeleteFunctionProgramProjectDGRecords()
        {
            int selectedRowsCount = dgFunctionalProgramProject.SelectedRows.Count;

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var functionProgramProjectModelList = new List<FunctionProgramProjectModel>();
                        foreach (DataGridViewRow row in dgFunctionalProgramProject.SelectedRows)
                        {
                            int fppID = Convert.ToInt16(row.Cells[0].Value.ToString());
                            functionProgramProjectModelList.Add(new FunctionProgramProjectModel() { Id = fppID });
                        }

                        var functionProgramProjectRepository = Factory.FunctionProgramProjectRepository();
                        _ = functionProgramProjectRepository.Delete(functionProgramProjectModelList);
                        LoadFPP();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadFunctionalClassificationRecordsBySearch()
        {

            try
            {
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtfunctionalClassificationRepository = Factory.FunctionalClassificationRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.FuntionalClassificationDatagridView(dtfunctionalClassificationRepository, dgFunctionalClassification);

                lblRecordCount.Text = dgFunctionalClassification.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        internal void LoadFunctionalClassificationServicesRecordsBySearch()
        {

            try
            {
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtfunctionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.FuntionalClassificationServiceDatagridView(dtfunctionalClassificationServiceRepository, dgFuntionalClassificationService);

                lblRecordCount.Text = dgFuntionalClassificationService.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                LoadFunctionalClassificationRecordsBySearch();
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                LoadFunctionalClassificationServicesRecordsBySearch();
            }
            else
                LoadFPP();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                _ = new frmFunctionalClassificationAdd(this).ShowDialog();
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                _ = new frmFunctonalClassificationServiceAdd(this).ShowDialog();
            }
            else
                _ = new frmFunctionProgramProjectAdd(this).ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgFunctionalClassification.Rows.Count == 0)
            {
                return;
            }
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                byte functionalClassificationId = byte.Parse(dgFunctionalClassification.SelectedCells[0].Value.ToString());
                _ = new frmFunctionalClassificationEdit(this, functionalClassificationId).ShowDialog();
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                byte functionalClassificationServiceId = byte.Parse(dgFuntionalClassificationService.SelectedCells[0].Value.ToString());
                _ = new frmFunctonalClassificationServiceEdit(this, functionalClassificationServiceId).ShowDialog();
            }
            else
            {
                byte fppID = byte.Parse(dgFunctionalProgramProject.SelectedCells[0].Value.ToString());
                _ = new frmFunctionProgramProjectEdit(this, fppID).ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                DeleteFunctionalClassificationRecords();
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                DeleteFunctionalClassificationServiceRecords();
            }
            else
                DeleteFunctionProgramProjectDGRecords();
        }

        private void toolStripBtnOthers_Click(object sender, EventArgs e)
        {
            ShowOthersFPP();
        }

        private void dgFunctionalClassification_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFunctionalClassification, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalClassification, btnEdit, btnDelete);
        }

        public void LoadSectorNameComboBox()
        {
            try
            {
                DataTable dtSectorName = Factory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.SectorNameComboBox(dtSectorName, cmbSectorName, "sector_name", "id");
                //  byte id = Convert.ToByte(cmbSectorName.SelectedValue);
                // txtCode.Text = Convert.ToString(id);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }


        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadFunctionalClassificationServicesRecords();
        }

        private void cmbSectorName_SelectionChangeCommitted_2(object sender, EventArgs e)
        {
            LoadFunctionalClassificationServicesRecordsByGroup();
        }

        private void dgFuntionalClassificationService_SelectionChanged_1(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFuntionalClassificationService, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFuntionalClassificationService, btnEdit, btnDelete);
        }

        private void dgFunctionalProgramProject_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowOthersFPP();
        }

        private void tabControlFunctionProgramProject_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                LoadFunctionalClassificationRecords();
                toolStripSeparator1.Visible = false;
                btnSubFPP.Visible = false;
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                LoadFunctionalClassificationServicesRecords();
                toolStripSeparator1.Visible = false;
                btnSubFPP.Visible = false;
            }
            else
            {
                LoadFPP();
                toolStripSeparator1.Visible = true;
                btnSubFPP.Visible = true;
            }
        }
    }
}
