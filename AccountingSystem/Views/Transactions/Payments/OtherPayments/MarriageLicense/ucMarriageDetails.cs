using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense
{
    public partial class ucMarriageDetails : UserControl
    {
        public ucMarriageDetails()
        {
            InitializeComponent();
        }

        private void OnLoad()
        {
            dtpIssuedDate.Value = Helper.GetCurrentDate();
            dtpPublishedDate.Value = Helper.GetCurrentDate();
        }
    }
}