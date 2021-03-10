using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        

        public frmJEV()
        {
            InitializeComponent();
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
        }

        private bool SaveData()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
        }

        

        
    }
}
