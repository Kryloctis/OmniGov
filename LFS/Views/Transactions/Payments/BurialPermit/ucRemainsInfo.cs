using ACC.Data;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.BurialPermit
{
    public partial class ucRemainsInfo : UserControl
    {
        protected internal DateTime deathDate;

        public ucRemainsInfo()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(cmbxRegistry)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            LoadRegistry();
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

        internal void ResetForm()
        {
            LoadRegistry();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            radMale.Checked = true;
            txtNationality.Clear();
            dtBirthDate.Value = Helper.GetCurrentDate();
            nudAge.Value = 1;
            txtMunicipality.Clear();
            txtProvince.Clear();
            txtCountry.Clear();
            txtContactInfo.Clear();
        }

        internal (int remainRegistryId, int remainAge) GetRemainsInfo()
        {
            return (Convert.ToInt32(cmbxRegistry.SelectedValue), (int)nudAge.Value);
        }

        private void ClearRemainsInfo()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            radMale.Checked = true;
            txtNationality.Clear();
            dtBirthDate.Value = Helper.GetCurrentDate();
            nudAge.Value = 0;
            txtMunicipality.Clear();
            txtProvince.Clear();
            txtCountry.Clear();
            txtContactInfo.Clear();
        }

        private void LoadSelectedRegistryInfo()
        {
            int registryId = Convert.ToInt32(cmbxRegistry.SelectedValue);
            var dictRegistry = AccFactory.RegistryRepository().GetRecordByID(registryId);

            txtFirstName.Text = dictRegistry["first_name"];
            txtMiddleName.Text = dictRegistry["middle_name"];
            txtLastName.Text = dictRegistry["last_name"];
            radMale.Checked = dictRegistry["sex"].ToLower() == "male";
            radFemale.Checked = dictRegistry["sex"].ToLower() ==
                "female";
            dtBirthDate.Value = Convert.ToDateTime(dictRegistry["birth_date"]);
            txtNationality.Text = dictRegistry["nationality"];
            txtMunicipality.Text = dictRegistry["municipality"];
            txtProvince.Text = dictRegistry["province"];
            txtCountry.Text = dictRegistry["country"];
            txtContactInfo.Text = dictRegistry["contact_info"];
            nudAge.Value = Math.Max(0, (int)((deathDate - dtBirthDate.Value).TotalDays / 365));
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

        private void cmbxRegistry_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxRegistry.SelectedValue is null)
                    return;

                LoadSelectedRegistryInfo();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool RegistryValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "Registry  not found"))
            {
                ClearRemainsInfo();
                return false;
            }
            else if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Registry not found");
                ClearRemainsInfo();
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