using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    public partial class ucPropertyTaxPayment : UserControl
    {
        private readonly string accountableFormNo = "56";

        public ucPropertyTaxPayment()
        {
            InitializeComponent();
        }

        private string GetAccountableFormData(string columName)
        {
            var dictAccForm = AccFactory.AccountableFormsRepository().GetRecordByAccFormNo(accountableFormNo);

            if (dictAccForm.Values.Count < 1)
                return string.Empty;

            return dictAccForm[columName];
        }

        private void LoadAccountableForm() 
        {
            try
            {
                txtAccountableForm.Text = $"{accountableFormNo} - {GetAccountableFormData("acc_form_desc")}";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucPropertyTaxPayment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccountableForm();
                txtCollectingOfficer.Text = Helper.LoggedInUserData()["user_full_name"];
            }
        }


        private void chckBxJobOrders_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
