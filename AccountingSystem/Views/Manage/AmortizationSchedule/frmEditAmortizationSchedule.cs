using AccountingSystem.Views.Manage.Amortization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AmortizationSchedule
{
    public partial class frmEditAmortizationSchedule : Form
    {

        private ucAmortizationSchedule uc;
        internal int amortizationId;
        internal string amortizationTerm;
        private frmAmortizationSchedule _frmAmortizationSchedule;

        public frmEditAmortizationSchedule(frmAmortizationSchedule frmAmortizationSchedule)
        {
            InitializeComponent();
            _frmAmortizationSchedule = frmAmortizationSchedule;
            uc = ucAmortizationSchedule1;
        }


        private void LoadSelectedAmortizationSchedule() 
        {
            
        }

        private void frmEditAmortizationSchedule_Load(object sender, EventArgs e)
        {
            uc.amortizationId = amortizationId;
            uc.amortizationTerm = amortizationTerm;
            uc.SetAmortizationTerm();
        }
    }
}
