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
            try
            {
                if (toolStripTxtSearch.Text.Length > 3 && !string.IsNullOrEmpty(toolStripTxtSearch.Text))
                {
                    dtOthersFPP = Factory.OthersFPPRepository().GetRecorsBySearchAndID(functionProgramProjectID, toolStripTxtSearch.Text.Trim());
                }
                else 
                {
                    dtOthersFPP = Factory.OthersFPPRepository().GetRecordsByID(functionProgramProjectID);
                }

                HelperLoadRecords.OthersFPPDatagridView(dtOthersFPP, dgOthersFPP);
                lblRecordCount.Text = dgOthersFPP.Rows.Count.ToString();
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        private void ShowOthersFunctionProgramProjectAdd() 
        {
            var frmOthersFunctionProgramProjectAdd = new frmOthersFunctionProgramProjectAdd(this);
            frmOthersFunctionProgramProjectAdd.ucOthersFunctionProgramProject1.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProjectAdd.ShowDialog();
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e) 
        {
            ShowOthersFunctionProgramProjectAdd();
        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e) 
        {
            ShowOthersFunctionProgramProjectEdit();
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e) 
        {
            int selectedRowsCount = dgOthersFPP.SelectedRows.Count;
           
            var otherFPPModelList = new List<OthersFPPModel>();

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        foreach (DataGridViewRow row in dgOthersFPP.SelectedRows)
                        {
                            int otherFPPId= int.Parse(row.Cells[0].Value.ToString());
                            var otherFPPModel = new OthersFPPModel()
                            {
                                Id = otherFPPId
                            };

                            otherFPPModelList.Add(otherFPPModel);
                        }

                        _ = Factory.OthersFPPRepository().Delete(otherFPPModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void toolStripTxtSearch_TextChanged(object sender, EventArgs e) 
        {
            LoadRecords();
        }

        private void frmOthersFunctionProgramProject_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dgOthersFPP_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgOthersFPP, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgOthersFPP, toolStripBtnEdit, toolStripBtnDelete); 
        }
    }
}
