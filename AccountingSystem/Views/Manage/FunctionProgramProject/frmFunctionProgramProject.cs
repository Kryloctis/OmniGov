using ACC.Data;
using ACC.Domain.Models;
using LFS.Views.Manage.FunctionProgramProject.FunctionalClassification;
using LFS.Views.Manage.FunctionProgramProject.FunctionProgramProject;
using LFS.Views.Manage.FunctionProgramProject.FunctonalClassificationService;
using LFS.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject;
using LFS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject
{
    public partial class frmFunctionProgramProject : Form
    {
        public frmFunctionProgramProject()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgFunctionalClassification, true);
            Helper.DatagridFullRowSelectStyle(dgFuntionalClassificationServices, true);
            Helper.DatagridFullRowSelectStyle(dgFunctionalProgramProject, true);
            Helper.DatagridFullRowSelectStyle(dgFunctionalProgramProject, true);
            HelperLoadRecords.FunctionProjectProgramDatagridView(dgFunctionalProgramProject);
        }

        #region Function Classifications

        internal void LoadFunctionalClassifications()
        {
            string searchkey = Convert.ToString(txtSearch.Text);
            var dtfunctionalClassificationRepository = AccFactory.FunctionalClassificationRepository().GetRecordsBySearch(searchkey);
            HelperLoadRecords.FunctionalClassificationDatagridView(dtfunctionalClassificationRepository, dgFunctionalClassification);

            dgFunctionalClassification.CurrentCell = dgFunctionalClassification.FirstDisplayedCell;
            lblRecordCount.Text = dgFunctionalClassification.Rows.Count.ToString();
        }

        private void dgFunctionalClassification_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                Helper.ShowRecordTimestamp(dgFunctionalClassification, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgFunctionalClassification, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Function Classifications

        #region Function Classification Services

        public void LoadSectorComboBox()
        {
            DataTable dtSectorName = AccFactory.FunctionalClassificationRepository().GetRecords();

            var dataTable = new DataTable();

            dataTable.Columns.Add("id");
            dataTable.Columns.Add("sector_name");

            dataTable.Rows.Add(0, "All");

            foreach (DataRow item in dtSectorName.Rows)
            {
                var items = new object[]
                {
                       item["id"],
                       item["sector_name"]
                };

                dataTable.Rows.Add(items);
            };

            HelperLoadRecords.SectorNameComboBox(dataTable, cmbxSector, "sector_name", "id");
        }

        private void cmbSectorName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadFunctionClassificationServices();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgFuntionalClassificationServices_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 5, 6 };
                Helper.ShowRecordTimestamp(dgFuntionalClassificationServices, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgFuntionalClassificationServices, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable FunctionClassificationServicesDataTable(string searchText, int sectorId)
        {
            DataTable functionClassificationServicesDataTable;

            if (sectorId == 0)
                functionClassificationServicesDataTable = AccFactory.FunctionalClassificationServiceRepository().GetViewRecordsBySearch(searchText);
            else
                functionClassificationServicesDataTable = AccFactory.FunctionalClassificationServiceRepository().GetViewRecordsBySearch_And_Sector(searchText, sectorId);

            return functionClassificationServicesDataTable;
        }

        internal void LoadFunctionClassificationServices()
        {
            string searchText = txtSearch.Text.Trim();
            int sectorId = Convert.ToInt32(cmbxSector.SelectedValue);

            HelperLoadRecords.FunctionalClassificationServiceDatagridView(FunctionClassificationServicesDataTable(searchText, sectorId), dgFuntionalClassificationServices);

            dgFuntionalClassificationServices.CurrentCell = dgFuntionalClassificationServices.FirstDisplayedCell;
            lblRecordCount.Text = dgFuntionalClassificationServices.Rows.Count.ToString();
        }

        #endregion Function Classification Services

        #region Function Program Project

        public void LoadServiceNameComboBox()
        {
            cmbServiceName.SelectedValueChanged -= new EventHandler(CmbServiceName_SelectedValueChanged);
            DataTable dtServiceName = new DataTable();

            dtServiceName.Columns.Add("id");
            dtServiceName.Columns.Add("service_name");

            dtServiceName.Rows.Add(0, "All");

            foreach (DataRow item in AccFactory.FunctionalClassificationServiceRepository().GetViewRecords().Rows)
            {
                string serviceName = $"{item["functional_classifications_sector_code"]} - {item["service_name"]}";

                var items = new object[]
                {
                       item["id"],
                       serviceName
                };

                dtServiceName.Rows.Add(items);
            };

            HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbServiceName, "service_name", "id");
            cmbServiceName.SelectedValueChanged += new EventHandler(CmbServiceName_SelectedValueChanged);
        }

        private DataTable FPPDatatable(string searchText, int serviceId, bool isSpecial)
        {
            DataTable fppDataTable;

            if (serviceId == 0)
                fppDataTable = AccFactory.FunctionProgramProjectRepository().GetViewRecordsBySearch_And_IsSpecial(searchText, isSpecial);
            else
                fppDataTable = AccFactory.FunctionProgramProjectRepository().GetViewRecordsByService_And_Search_And_IsSpecial(serviceId, searchText, isSpecial);

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

            dgFunctionalProgramProject.CurrentCell = dgFunctionalProgramProject.FirstDisplayedCell;
            lblRecordCount.Text = dgFunctionalProgramProject.Rows.Count.ToString();
        }

        private void CmbServiceName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFPP();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgFunctionalProgramProject_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgFunctionalProgramProject_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ShowOthersFPP();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckbxSpecial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFPP();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Function Program Project

        private void ShowOthersFPP()
        {
            int functionProgramProjectID = Convert.ToInt32(dgFunctionalProgramProject.SelectedCells[0].Value);
            var frmOthersFunctionProgramProject = new frmOthersFunctionProgramProject();
            frmOthersFunctionProgramProject.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProject.ShowDialog();
        }

        private void toolStripBtnOthers_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOthersFPP();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFunctionProgramProject_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSectorComboBox();
            LoadServiceNameComboBox();
            LoadFPP();
            LoadFunctionClassificationServices();
            LoadFunctionalClassifications();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabControlFunctionProgramProject.SelectedTab.Name)
                {
                    case "tabFunctionalClassification":
                        LoadFunctionalClassifications();
                        break;

                    case "tabFunctionalClassificationService":
                        LoadFunctionClassificationServices();
                        break;

                    case "tabFunctionProgramProject":
                        LoadFPP();
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControlFunctionProgramProject.SelectedTab.Name)
                {
                    case "tabFunctionalClassification":
                        _ = new frmFunctionalClassificationAdd(this).ShowDialog();
                        break;

                    case "tabFunctionalClassificationService":
                        _ = new frmFunctionalClassificationServiceAdd(this).ShowDialog();
                        break;

                    case "tabFunctionProgramProject":
                        _ = new frmFunctionProgramProjectAdd(this).ShowDialog();
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxSuccess(ex.Message); }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControlFunctionProgramProject.SelectedTab.Name)
                {
                    case "tabFunctionalClassification":
                        byte functionalClassificationId = byte.Parse(dgFunctionalClassification.SelectedCells[0].Value.ToString());
                        _ = new frmFunctionalClassificationEdit(this, functionalClassificationId).ShowDialog();
                        break;

                    case "tabFunctionalClassificationService":
                        byte functionalClassificationServiceId = byte.Parse(dgFuntionalClassificationServices.SelectedCells[0].Value.ToString());
                        _ = new frmFunctionalClassificationServiceEdit(this, functionalClassificationServiceId).ShowDialog();
                        break;

                    case "tabFunctionProgramProject":
                        byte fppID = byte.Parse(dgFunctionalProgramProject.SelectedCells[0].Value.ToString());
                        _ = new frmFunctionProgramProjectEdit(this, fppID).ShowDialog();
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteFunctionalClassificationRecords()
        {
            int selectedRowsCount = dgFunctionalClassification.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var functionalClassificationModelList = new List<FunctionalClassificationModel>();
                foreach (DataGridViewRow row in dgFunctionalClassification.SelectedRows)
                {
                    int functionalClassificationId = Convert.ToInt16(row.Cells[0].Value.ToString());
                    functionalClassificationModelList.Add(new FunctionalClassificationModel() { Id = functionalClassificationId });
                }

                return AccFactory.FunctionalClassificationRepository().Delete(functionalClassificationModelList);
            }
            return false;
        }

        private bool DeleteFunctionalClassificationServiceRecords()
        {
            int selectedRowsCount = dgFuntionalClassificationServices.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var functionalClassificationServiceModelList = new List<FunctionalClassificationServiceModel>();
                foreach (DataGridViewRow row in dgFuntionalClassificationServices.SelectedRows)
                {
                    int serviceId = Convert.ToInt16(row.Cells[0].Value.ToString());
                    functionalClassificationServiceModelList.Add(new FunctionalClassificationServiceModel() { Id = serviceId });
                }

                return AccFactory.FunctionalClassificationServiceRepository().Delete(functionalClassificationServiceModelList);
            }
            return false;
        }

        private bool DeleteFunctionProgramProjectRecords()
        {
            int selectedRowsCount = dgFunctionalProgramProject.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var functionProgramProjectModelList = new List<FunctionProgramProjectModel>();
                foreach (DataGridViewRow row in dgFunctionalProgramProject.SelectedRows)
                {
                    int fppID = Convert.ToInt16(row.Cells[0].Value.ToString());
                    functionProgramProjectModelList.Add(new FunctionProgramProjectModel() { Id = fppID });
                }

                return AccFactory.FunctionProgramProjectRepository().Delete(functionProgramProjectModelList);
            }
            return false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControlFunctionProgramProject.SelectedTab.Name)
                {
                    case "tabFunctionalClassification":
                        if (DeleteFunctionalClassificationRecords())
                        {
                            LoadFunctionalClassifications();
                            LoadSectorComboBox();
                        }
                        break;

                    case "tabFunctionalClassificationService":
                        if (DeleteFunctionalClassificationServiceRecords())
                        {
                            LoadFunctionClassificationServices();
                            LoadServiceNameComboBox();
                        }
                        break;

                    case "tabFunctionProgramProject":
                        if (DeleteFunctionProgramProjectRecords())
                        {
                            LoadFPP();
                        }
                        break;
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlFunctionProgramProject_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                switch (tabControlFunctionProgramProject.SelectedTab.Name)
                {
                    case "tabFunctionalClassification":
                        LoadFunctionalClassifications();
                        toolStripSeparator1.Visible = false;
                        btnSubFPP.Visible = false;
                        break;

                    case "tabFunctionalClassificationService":
                        LoadFunctionClassificationServices();
                        toolStripSeparator1.Visible = false;
                        btnSubFPP.Visible = false;
                        break;

                    case "tabFunctionProgramProject":
                        LoadFPP();
                        toolStripSeparator1.Visible = true;
                        btnSubFPP.Visible = true;
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}