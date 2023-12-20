using ACC.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    public partial class ucSpouseInfo : UserControl
    {
        public ucSpouseInfo()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(cmbxRegistry),
                errorProvider1.GetError(nudAge),
                errorProvider1.GetError(nudMonths),
                errorProvider1.GetError(txtReligion),
                errorProvider1.GetError(txtCurrenResidence)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
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

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxRegistry, "id", "name");
        }

        internal void OnLoad()
        {
            LoadRegistry();
        }

        private void cmbxRegistry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (ModifierKeys == Keys.Shift && e.KeyChar == (char)Keys.Enter)
                {
                    LoadRegistry();
                    cmbxRegistry.DroppedDown = cmbxRegistry.DroppedDown ? false : true;
                    cmbxRegistry.DroppedDown = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudAge_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAge, "Age") || Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAge, "Age");
        }

        private void nudAge_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAge);
        }

        private void nudMonths_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAge, "Age") || Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAge, "Age");
        }

        private void nudMonths_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudMonths);
        }

        private void txtReligion_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReligion, "Religion");
        }

        private void txtReligion_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReligion);
        }

        private void txtCurrenResidence_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCurrenResidence, "Current Residence");
        }

        private void txtCurrenResidence_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCurrenResidence);
        }

        private bool RegistryValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "Groom's Registry"))
                return false;
            else if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Groom's Registry");
                return false;
            }

            return true;
        }

        private void cmbxRegistry_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !RegistryValidated(errorProvider1, cmbxRegistry);
        }

        private void cmbxRegistry_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxRegistry);
        }
    }
}