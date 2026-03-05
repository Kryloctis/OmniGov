using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassification;
using OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassificationService;
using OmniGov.App.Views.Manage.FunctionProgramProject.FunctionProgramProject;
using OmniGov.App.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using System.Data;

namespace OmniGov.App.Views.Manage.FunctionProgramProject
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
            var dtfunctionalClassificationRepository = Factory.FunctionalClassificationRepository().GetRecordsBySearch(searchkey);
            HelperLoadRecords.FunctionalClassificationDatagridView(dtfunctionalClassificationRepository, dgFunctionalClassification);

            dgFunctionalClassification.CurrentCell = dgFunctionalClassification.FirstDisplayedCell;
            lblRecordCount.Text = dgFunctionalClassification.Rows.Count.ToString();
        }

        private void dgFunctionalClassification_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFunctionalClassification, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalClassification, btnEdit, btnDelete);
        }

        #endregion Function Classifications

        #region Function Classification Services

        public void LoadSectorComboBox()
        {
            DataTable dtSectorName = Factory.FunctionalClassificationRepository().GetRecords();

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
            }
            ;

            HelperLoadRecords.SectorNameComboBox(dataTable, cmbxSector, "sector_name", "id");
        }

        internal void LoadFunctionClassificationServices()
        {
            string searchText = txtSearch.Text.Trim();
            int sectorId = Convert.ToInt32(cmbxSector.SelectedValue);

            HelperLoadRecords.FunctionalClassificationServiceDatagridView(FunctionClassificationServicesDataTable(searchText, sectorId), dgFuntionalClassificationServices);

            dgFuntionalClassificationServices.CurrentCell = dgFuntionalClassificationServices.FirstDisplayedCell;
            lblRecordCount.Text = dgFuntionalClassificationServices.Rows.Count.ToString();
        }

        private void cmbSectorName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadFunctionClassificationServices();
        }

        private void dgFuntionalClassificationServices_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 5, 6 };
            Helper.ShowRecordTimestamp(dgFuntionalClassificationServices, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFuntionalClassificationServices, btnEdit, btnDelete);
        }

        private DataTable FunctionClassificationServicesDataTable(string searchText, int sectorId)
        {
            DataTable functionClassificationServicesDataTable;

            if (sectorId == 0)
                functionClassificationServicesDataTable = Factory.FunctionalClassificationServiceRepository().GetViewRecordsBySearch(searchText);
            else
                functionClassificationServicesDataTable = Factory.FunctionalClassificationServiceRepository().GetViewRecordsBySearch_And_Sector(searchText, sectorId);

            return functionClassificationServicesDataTable;
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

            foreach (DataRow item in Factory.FunctionalClassificationServiceRepository().GetViewRecords().Rows)
            {
                string serviceName = $"{item["functional_classifications_sector_code"]} - {item["service_name"]}";

                var items = new object[]
                {
                       item["id"],
                       serviceName
                };

                dtServiceName.Rows.Add(items);
            }
            ;

            HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbServiceName, "service_name", "id");
            cmbServiceName.SelectedValueChanged += new EventHandler(CmbServiceName_SelectedValueChanged);
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

        private void chckbxSpecial_CheckedChanged(object sender, EventArgs e)
        {
            LoadFPP();
        }

        private void CmbServiceName_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadFPP();
        }

        private void dgFunctionalProgramProject_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowOthersFPP();
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

        #endregion Function Program Project

        private void BtnAdd_Click(object sender, EventArgs e)
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

        private void BtnDelete_Click(object sender, EventArgs e)
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

        private void BtnEdit_Click(object sender, EventArgs e)
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

                return Factory.FunctionalClassificationRepository().Delete(functionalClassificationModelList);
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

                return Factory.FunctionalClassificationServiceRepository().Delete(functionalClassificationServiceModelList);
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

                return Factory.FunctionProgramProjectRepository().Delete(functionProgramProjectModelList);
            }
            return false;
        }

        private void frmFunctionProgramProject_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            LoadSectorComboBox();
            LoadServiceNameComboBox();
            LoadFPP();
            LoadFunctionClassificationServices();
            LoadFunctionalClassifications();
        }

        private void ShowOthersFPP()
        {
            int functionProgramProjectID = Convert.ToInt32(dgFunctionalProgramProject.SelectedCells[0].Value);
            var frmOthersFunctionProgramProject = new frmOthersFunctionProgramProject();
            frmOthersFunctionProgramProject.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProject.ShowDialog();
        }

        private void tabControlFunctionProgramProject_Selected(object sender, TabControlEventArgs e)
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

        private void toolStripBtnOthers_Click(object sender, EventArgs e)
        {
            ShowOthersFPP();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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
    }
}