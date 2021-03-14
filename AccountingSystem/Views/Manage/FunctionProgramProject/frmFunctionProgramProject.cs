using System;
using System.Windows.Forms;
using ACC.Domain.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject;
using System.Data;
using AccountingSystem.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject;

namespace AccountingSystem.Views.Manage.FunctionProgramProject
{
    public partial class frmFunctionProgramProject : Form
    {
        public frmFunctionProgramProject()
        {
            InitializeComponent();
        }

        private void dgFunctionalClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassification"])
            {
                LoadFunctionalClassificationRecords();
                toolStripBtnOthers.Enabled = false;
            }
            else if (tabControlFunctionProgramProject.SelectedTab == tabControlFunctionProgramProject.TabPages["tabFunctionalClassificationService"])
            {
                LoadFunctionalClassificationServicesRecords();
                toolStripBtnOthers.Enabled = false;
            }
            else
                LoadFunctionProgramProjectRecords();
        }

        private void ShowOthersFPP() 
        {
            int functionProgramProjectID = Convert.ToInt32(dgFunctionalProgramProject.SelectedCells[0].Value);
            var frmOthersFunctionProgramProject = new frmOthersFunctionProgramProject();
            frmOthersFunctionProgramProject.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProject.ShowDialog();
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


        internal void LoadFunctionProgramProjectRecordsByGroup()
        {

            try
            {
                txtSearch.Clear();
                byte id = Convert.ToByte(cmbServiceName.SelectedValue);
                var dtfunctionProgramProjectRepository = Factory.FunctionProgramProjectRepository().GetViewRecordsByServiceNameId(id);
                HelperLoadRecords.FuntionProjectProgramDatagridView(dtfunctionProgramProjectRepository, dgFunctionalProgramProject);

                lblRecordCount.Text = dgFunctionalProgramProject.Rows.Count.ToString();
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

        internal void LoadFunctionProgramProjectRecords()
        {
            try
            {
                txtSearch.Clear();
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
                //GetRecordsWithFilter(id)
                var dtfunctionProgramProjectRepository = Factory.FunctionProgramProjectRepository().GetRecords();
                HelperLoadRecords.FuntionProjectProgramDatagridView(dtfunctionProgramProjectRepository, dgFunctionalProgramProject);

                lblRecordCount.Text = Factory.FunctionProgramProjectRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFunctionProgramProject_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgFunctionalClassification);
            Helper.DatagridDefaultStyle(dgFuntionalClassificationService);
            LoadFunctionalClassificationServicesRecords();
            Helper.DatagridDefaultStyle(dgFunctionalProgramProject);

            LoadSectorNameComboBox();
            LoadFunctionalClassificationServicesRecordsByGroup();
            LoadServiceNameComboBox();
            LoadFunctionProgramProjectRecords();

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
                        LoadFunctionProgramProjectRecords();
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

        internal void LoadFunctionProgramProjectRecordsBySearch()
        {

            try
            {
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtfunctionProgramProjectRepository = Factory.FunctionProgramProjectRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.FuntionProjectProgramDatagridView(dtfunctionProgramProjectRepository, dgFunctionalProgramProject);

                lblRecordCount.Text = dgFunctionalProgramProject.Rows.Count.ToString();
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
                LoadFunctionProgramProjectRecordsBySearch();
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

        private void dgFuntionalClassificationService_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgFunctionalProgramProject_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgFunctionalProgramProject, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalProgramProject, btnEdit, btnDelete);

            if (dgFunctionalProgramProject.SelectedRows.Count < 1)
                toolStripBtnOthers.Enabled = false;
            else
                toolStripBtnOthers.Enabled = true;

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
        public void LoadServiceNameComboBox()
        {
            try
            {
                DataTable dtServiceName = Factory.FunctionalClassificationServiceRepository().GetRecords();
                HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbServiceName, "service_name", "id");
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFunctionProgramProjectRecords();
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
       
		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
            LoadFunctionProgramProjectRecordsByGroup();
        }

        private void dgFunctionalProgramProject_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowOthersFPP();
        }
    }
}
