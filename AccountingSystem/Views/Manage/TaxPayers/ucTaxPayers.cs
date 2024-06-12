using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucTaxPayers : UserControl
    {
        private int taxPayerId;

        public ucTaxPayers()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtName),
                errorProvider1.GetError(cmbxRepresentative),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadTaxPayersType()
        {
            var dtTaxpayerType = AccFactory.TaxpayerTypeRepository().GetRecords();

            cmbxTaxPayerType.DataSource = dtTaxpayerType;
            cmbxTaxPayerType.ValueMember = "id";
            cmbxTaxPayerType.DisplayMember = "taxpayer_type";
        }

        internal void ResetForm()
        {
            txtTIN.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
            txtContact.Clear();
            LoadTaxPayersType();
            chckIsActive.Checked = true;
        }

        internal TaxpayersModel TaxpayersModel()
        {
            return new TaxpayersModel()
            {
                Tin = txtTIN.Text.Trim(),
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Municipality = txtMunicipality.Text.Trim(),
                Province = txtProvince.Text.Trim(),
                ContactInfo = txtContact.Text.Trim(),
                IsActive = chckIsActive.Checked,
                TaxpayerTypeId = Convert.ToInt32(cmbxTaxPayerType.SelectedValue),
                RepresentativeRegistryId = cmbxRepresentative.SelectedValue as int?
            };
        }

        private void LoadRegistry()
        {
            var registryColumn = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "name", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(registryColumn);

            var dtRegistry = AccFactory.RegistryRepository().GetRecords();

            foreach (DataRow row in dtRegistry.Rows)
            {
                var newRow = dataTable.NewRow();

                int Id = Convert.ToInt32(row["id"]);
                string name = $"{row["first_name"]} {row["middle_name"].ToString().Substring(0)}, {row["last_name"]}";

                newRow["id"] = Id;
                newRow["name"] = name;

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxRepresentative, "id", "name");
        }

        private void LoadSelectedRecord(int taxpayerId)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(taxpayerId);

            txtTIN.Text = dictTaxpayer["tin"];
            txtName.Text = dictTaxpayer["name"];
            txtAddress.Text = dictTaxpayer["address"];
            txtMunicipality.Text = dictTaxpayer["municipality"];
            txtProvince.Text = dictTaxpayer["province"];
            cmbxTaxPayerType.SelectedValue = Convert.ToInt32(dictTaxpayer["taxpayer_type_id"]);
            txtContact.Text = dictTaxpayer["contact_info"];
            chckIsActive.Checked = Convert.ToBoolean(Convert.ToByte(dictTaxpayer["is_active"]));

            var representativeId = dictTaxpayer["representative_registry_id"];
            chckRepresentative.Checked = string.IsNullOrWhiteSpace(representativeId) ? true : false;
            if (!string.IsNullOrWhiteSpace(representativeId)) cmbxRepresentative.SelectedValue = representativeId;
        }

        internal void OnLoad(bool isEdit, int taxpayerId = 0)
        {
            LoadRegistry();
            LoadTaxPayersType();
            ToggleRepresentative();

            if (isEdit)
            {
                this.taxPayerId = taxpayerId;
                LoadSelectedRecord(taxpayerId);
            }
        }

        private void ToggleRepresentative()
        {
            if (chckRepresentative.Checked)
            {
                cmbxRepresentative.Enabled = false;
                cmbxRepresentative.SelectedIndex = -1;
                cmbxRepresentative.Text = string.Empty;
            }
            else
                cmbxRepresentative.Enabled = true;
        }

        private void chckRepresentative_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleRepresentative();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRepresentative_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && e.KeyChar == (char)Keys.Enter)
            {
                LoadRegistry();
                cmbxRepresentative.DroppedDown = cmbxRepresentative.DroppedDown ? false : true;
                cmbxRepresentative.DroppedDown = true;
                e.Handled = true;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }
    }
}