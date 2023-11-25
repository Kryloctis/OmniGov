using DocumentFormat.OpenXml.Office2013.Excel;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments
{
    public partial class ucPaymentRegistry : UserControl
    {
        internal string title;

        public ucPaymentRegistry()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            groupBox1.Text = title;
        }

        private void ucRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            tabControlRegistry.SelectedTab = tabRegister;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControlRegistry.SelectedTab = tabRegistryList;
        }
    }
}