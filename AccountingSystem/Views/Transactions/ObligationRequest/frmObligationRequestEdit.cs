using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestEdit : Form
    {

        private ucObligationRequest uc;
        private ucObligationRequestMain _ucObligationRequestMain;

        public frmObligationRequestEdit(ucObligationRequestMain ucObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
            _ucObligationRequestMain = ucObligationRequestMain;
            uc.LoadReferences(_ucObligationRequestMain);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
            }
            else
            {
                var rowIndex = _ucObligationRequestMain.dgObligationRequests.CurrentCell.RowIndex;
                var amount = uc.nudAmount.Value;

                _ucObligationRequestMain.dgObligationRequests.Rows[rowIndex].Cells["amount"].Value = amount;
                Close();
            }
        }
    }
}
