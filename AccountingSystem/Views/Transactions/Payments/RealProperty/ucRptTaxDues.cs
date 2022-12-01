using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class ucRptTaxDues : UserControl
    {
        public ucRptTaxDues()
        {
            InitializeComponent();
        }

        private void OnLoad() 
        {
            Helper.DatagridFullRowSelectStyle(dgProperties, true, false);
            Helper.DatagridFullRowSelectStyle(dgTaxDues, true, false);
        }

        private void ucRptTaxDues_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }
    }
}
