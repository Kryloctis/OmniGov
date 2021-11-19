using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCD : Form
    {
        private readonly ucCollectorsRCD uc;
        public frmCollectorsRCD()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            uc = ucCollectorsRCD1;
        }

        private void CollectorsRCD_Load(object sender, EventArgs e)
        {

        }


    }
}
