using ACC.Data;
using AccountingSystem.Views.Shared;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        public ucCattleOwnership()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            LoadOwners();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxType),
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudPrice),
                errorProvider1.GetError(cmbxOwner),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadOwners()
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

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxOwner, "id", "name");
        }

        private void cmbxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxType, "Type");
        }

        private void cmbxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxType);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudPrice, "Price") || Helper.ShowErrorNumericUpDownZero(errorProvider1, nudPrice, "Price");
        }

        private void nudPrice_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudPrice);
        }

        private bool OwnerValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "Taxpayer"))
                return false;
            else if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Taxpayer");
                return false;
            }

            return true;
        }

        private void cmbxOwner_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !OwnerValidated(errorProvider1, cmbxOwner);
        }

        private void cmbxOwner_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxOwner);
        }

        private void cmbxOwner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && (Control.ModifierKeys & Keys.Shift) != 0)
            {
                LoadOwners();
                cmbxOwner.DroppedDown = cmbxOwner.DroppedDown ? false : true;
                e.Handled = true;
            }
        }
    }
}