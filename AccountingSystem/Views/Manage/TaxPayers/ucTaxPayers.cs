using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.RptTaxRates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucTaxPayers : UserControl
    {
        internal int taxPayerId = 0;
        internal bool isEdit;

        public ucTaxPayers()
        {
            InitializeComponent();
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[]
           {
                errorProvider1.GetError(txtName)
           };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private void LoadTaxPayersType()
        {
            try
            {
                var dtTaxpayerType = AccFactory.TaxpayerTypeRepository().GetRecords();
             
                cmbxTaxPayerType.DataSource = dtTaxpayerType;
                cmbxTaxPayerType.ValueMember = "id";
                cmbxTaxPayerType.DisplayMember = "taxpayer_type";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void LoadBarangay()
        {
            try
            {
                var dtBarangay = AccFactory.BarangayRepository().GetRecords();

                cmbxBarangay.DataSource = dtBarangay;
                cmbxBarangay.ValueMember = "id";
                cmbxBarangay.DisplayMember = "name";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void ResetForm()
        {
            txtTIN.Clear();
            txtName.Clear();
            txtContact.Clear();
            cmbxBarangay.SelectedIndex = 0;
            cmbxTaxPayerType.SelectedIndex = 0;
            taxPayerId = 0;
            isEdit = false;
        }

        private void ucTaxPayers_Load_1(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBarangay();
                LoadTaxPayersType();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

    }
}
