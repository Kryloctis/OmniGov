using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

using System.Data;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject

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

            if (toolStripTxtSearch.Text.Length > 3 && !string.IsNullOrEmpty(toolStripTxtSearch.Text))

                dtOthersFPP = Factory.SubFPPRepository().GetRecorsByIDSearchCode(functionProgramProjectID, searchTxt);
            else

                dtOthersFPP = Factory.SubFPPRepository().GetRecordsByFppId(functionProgramProjectID);

            HelperLoadRecords.OthersFPPDatagridView(dtOthersFPP, dgOthersFPP);

            lblRecordCount.Text = dgOthersFPP.Rows.Count.ToString();
        }

        private bool DeleteData()

        {
            int selectedRowsCount = dgOthersFPP.SelectedRows.Count;

            var otherFPPModelList = new List<SubFPPModel>();

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

                return Factory.SubFPPRepository().Delete(otherFPPModelList);
            }

            return false;
        }

        private void dgOthersFPP_SelectionChanged(object sender, EventArgs e)

        {
            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgOthersFPP, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgOthersFPP, toolStripBtnEdit, toolStripBtnDelete);
        }

        private void frmOthersFunctionProgramProject_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void OnLoad()

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
            if (DeleteData())
                LoadRecords();
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