using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
{
    public partial class frmOthersFunctionProgramProject : Form
    {
        internal int functionProgramProjectID = 0;

        public frmOthersFunctionProgramProject()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            DataTable dtOthersFPP;
            string searchTxt = toolStripTxtSearch.Text.Trim();

            try
            {
                if (toolStripTxtSearch.Text.Length > 3 && !string.IsNullOrEmpty(toolStripTxtSearch.Text))
                {
                    dtOthersFPP = AccFactory.SubFPPRepository().GetRecorsByIDSearchCode(functionProgramProjectID, searchTxt);
                }
                else
                {
                    dtOthersFPP = AccFactory.SubFPPRepository().GetRecordsByFPPId(functionProgramProjectID);
                }

                HelperLoadRecords.OthersFPPDatagridView(dtOthersFPP, dgOthersFPP);
                lblRecordCount.Text = dgOthersFPP.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgOthersFPP_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgOthersFPP, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgOthersFPP, toolStripBtnEdit, toolStripBtnDelete);
        }

        private void frmOthersFunctionProgramProject_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void ShowOthersFunctionProgramProjectAdd()
        {
            var frmOthersFunctionProgramProjectAdd = new frmOthersFunctionProgramProjectAdd(this);
            frmOthersFunctionProgramProjectAdd.ucOthersFunctionProgramProject1.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProjectAdd.ShowDialog();
        }

        private void ShowOthersFunctionProgramProjectEdit()
        {
            int rowIndex = dgOthersFPP.CurrentCell.RowIndex;
            var frmOthersFunctionProgramProjectEdit = new frmOthersFunctionProgramProjectEdit(this);
            int othersFPPID = Convert.ToInt32(dgOthersFPP.Rows[rowIndex].Cells["id"].Value);

            frmOthersFunctionProgramProjectEdit.ucOthersFunctionProgramProject1.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProjectEdit.ucOthersFunctionProgramProject1.othersFPPID = othersFPPID;
            frmOthersFunctionProgramProjectEdit.ShowDialog();
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            ShowOthersFunctionProgramProjectAdd();
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgOthersFPP.SelectedRows.Count;

            var otherFPPModelList = new List<SubFPPModel>();

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        foreach (DataGridViewRow row in dgOthersFPP.SelectedRows)
                        {
                            int otherFPPId = int.Parse(row.Cells[0].Value.ToString());
                            var otherFPPModel = new SubFPPModel()
                            {
                                Id = otherFPPId
                            };

                            otherFPPModelList.Add(otherFPPModel);
                        }

                        _ = AccFactory.SubFPPRepository().Delete(otherFPPModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e)
        {
            ShowOthersFunctionProgramProjectEdit();
        }

        private void toolStripTxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}