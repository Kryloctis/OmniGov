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
        internal int functionProgramProjectID;
        public frmOthersFunctionProgramProject()
        {
            InitializeComponent();
        }

        internal void LoadRecords() 
        {
            var dtOthersFPP = Factory.OthersFPPRepository().GetRecords();
            HelperLoadRecords.OthersFPPDatagridView(dtOthersFPP, dgOthersFPP);
            lblRecordCount.Text = dgOthersFPP.Rows.Count.ToString();
        }

        private void ShowOthersFunctionProgramProjectAdd() 
        {
            var frmOthersFunctionProgramProjectAdd = new frmOthersFunctionProgramProjectAdd();
            frmOthersFunctionProgramProjectAdd.ucOthersFunctionProgramProject1.functionProgramProjectID = functionProgramProjectID;
            frmOthersFunctionProgramProjectAdd.ShowDialog();
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e) 
        {
            ShowOthersFunctionProgramProjectAdd();
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
