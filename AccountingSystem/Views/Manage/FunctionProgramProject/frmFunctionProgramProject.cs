using System;
using System.Windows.Forms;
using ACC.Domain.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService;
using AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject;
using System.Data;

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

        }
      

        internal void LoadFunctionalClassificationRecords()
        {
            try
            {
                var dtFunctionalClassification = Factory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.FuntionalClassificationDatagridView(dtFunctionalClassification, dgFunctionalClassification);

                lblRecordCount.Text = Factory.FunctionalClassificationRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadFunctionalClassificationServicesRecords()
        {
            try
            {
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
            LoadFunctionalClassificationRecords();
            Helper.DatagridDefaultStyle(dgFuntionalClassificationService);
            LoadFunctionalClassificationServicesRecords();
            Helper.DatagridDefaultStyle(dgFunctionalProgramProject);
            LoadFunctionProgramProjectRecords();
                      

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

        private void dgFunctionalClassification_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFunctionalClassification, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalClassification, btnEdit, btnDelete);
        }

        private void dgFuntionalClassificationService_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFuntionalClassificationService, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFuntionalClassificationService, btnEdit, btnDelete);
        }

        private void dgFunctionalProgramProject_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgFunctionalProgramProject, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunctionalProgramProject, btnEdit, btnDelete);
        }

        private void cmbSectorName_SelectionChangeCommitted(object sender, EventArgs e)
        {
        
        }
    }
}
