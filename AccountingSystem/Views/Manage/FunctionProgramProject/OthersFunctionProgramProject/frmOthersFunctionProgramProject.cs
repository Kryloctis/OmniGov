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
    }
}
