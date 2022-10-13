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
            Helper.DatagridFullRowSelectStyle(dgProperties, false);
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
                var dtTaxpayerType = AccFactory.TaxpayersRepository().GetRecords();
             
                dtTaxpayerType.Columns.Add("taxpayer_type", typeof(string), "taxpayer_type");
                cmbxTaxPayerType.DataSource = dtTaxpayerType;
                cmbxTaxPayerType.ValueMember = "id";
                cmbxTaxPayerType.DisplayMember = "taxpayer_type";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void ResetForm()
        {
            txtTIN.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtBarangay.Clear();
            txtStreet.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
            //cmbxTaxPayerType.SelectedIndex = 0;
            taxPayerId = 0;
            isEdit = false;

            dgProperties.DataSource = null;
            dgProperties.Rows.Clear();
            dgProperties.Refresh();
        }

        private void ucTaxPayers_Load_1(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (taxPayerId == 0 && string.IsNullOrEmpty(txtName.Text.Trim()))
                Helper.MessageBoxSuccess("No Taxpayer found.");
            else
                _ = new frmAddRealProperties(this).ShowDialog();
        }

        #region Properties
        internal void LoadProperties()
        {
            try
            {
                var dtRealProperties = AccFactory.RealPropertiesRepository().GetPropertiesByTaxpayerId(taxPayerId);

                HelperLoadRecords.RealPropertiesDatagridView(dgProperties, RealPropertiesDataTable(dtRealProperties));
                dgProperties.CurrentCell = dgProperties.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable RealPropertiesDataTable(DataTable dtRealProperties)
        {
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("property_identifier", typeof(string)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("barangay_name", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("assessed_value", typeof(string)),
                new DataColumn("municipality_name", typeof(string)),
                new DataColumn("province_name", typeof(string)),
            };
            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtRealProperties.Rows)
            {

                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["id"]);
                string rowPropertyIdentifier = row["property_identifier"].ToString();
                string completeArpNumber = row["complete_arp_no"].ToString();
                string propertyPin = row["property_pin"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string propertyKind = row["property_kind"].ToString();
                string assessedValue = row["assessed_value"].ToString();
                string municipalityName = row["municipality_name"].ToString();
                string provinceName = row["province_name"].ToString();

                newRow["id"] = rowId;
                newRow["property_identifier"] = rowPropertyIdentifier;
                newRow["complete_arp_no"] = completeArpNumber;
                newRow["property_pin"] = propertyPin;
                newRow["barangay_name"] = barangayName;
                newRow["property_kind"] = propertyKind;
                newRow["assessed_value"] = assessedValue;
                newRow["municipality_name"] = municipalityName;
                newRow["province_name"] = provinceName;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (Delete(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadProperties();
            }
        }

        private bool Delete(out int deletedCount)
        {
            try
            {
                var realPropertiesModelList = new List<RealPropertiesModel>();
                int rowCount = dgProperties.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgProperties.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new RealPropertiesModel() { Id = id };
                        realPropertiesModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.RealPropertiesRepository().Delete(realPropertiesModelList);
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        private void dgProperties_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableButtons(dgProperties, btnEdit, btnDelete);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private void ShowEditForm()
        {
            try
            {
                int rowIndex = dgProperties.CurrentCell.RowIndex;
                int propertyId = Convert.ToInt32(dgProperties.Rows[rowIndex].Cells["id"].Value);

                _ = new frmEditRealProperties(propertyId, this).ShowDialog();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

    }
}
