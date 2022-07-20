using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptDiscount
{
    public partial class frmEditRptDiscounts : Form
    {
        private readonly frmRptDiscounts _frmRptDiscounts;
        public frmEditRptDiscounts(frmRptDiscounts frmRptDiscounts)
        {
            InitializeComponent();
            _frmRptDiscounts = frmRptDiscounts;
            Helper.LoadFormIcon(this);
        }

        private void frmEditRptDiscounts_Load(object sender, EventArgs e)
        {

        }
    }
}
