using ACC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments
{
    public partial class ucFeesCharges : UserControl
    {
        private int childImageIndexCounter = 1;
        internal string description = string.Empty;
        internal string accountableForm = string.Empty;
        internal int unit = 1;
        internal decimal debitAmount;
        internal decimal subTotalAmount;
        private string error;

        public ucFeesCharges()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgOtherPaymentCharges);
        }

        #region Private Methods

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                error
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal bool FormValidated()
        {
            if (dgOtherPaymentCharges.Rows.Count < 1 || GetTotalOtherCharges() < 1)
            {
                error = "No Fees/Charges has been applied";
                return false;
            }
            error = string.Empty;
            return true;
        }

        private void LoadOtherPaymentCharges()
        {
            treeViewTaxTypes.Nodes.Clear();
            childImageIndexCounter = 1;

            var dtTaxTypes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();

            TreeNode parentNode;

            foreach (DataRow dr in dtTaxTypes.Rows)
            {
                parentNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());

                string taxTypeID = dr["id"].ToString();
                parentNode.Tag = taxTypeID;
                PopulateTreeView(taxTypeID, parentNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    parentNode.ForeColor = Color.Gray;
            }
        }

        internal void OnLoad()
        {
            LoadOtherPaymentCharges();
            CreatedOtherPaymentChargesColumns(dgOtherPaymentCharges);
        }

        private void AddOtherPaymentCharge()
        {
            _ = dgOtherPaymentCharges.Rows.Add(new object[] { description, debitAmount, $"AF {accountableForm}", unit, subTotalAmount });
        }

        internal decimal GetTotalOtherCharges()
        {
            decimal totalPayment = 0;
            foreach (DataGridViewRow row in dgOtherPaymentCharges.Rows)
                totalPayment += Convert.ToDecimal(row.Cells["total_amount"].Value);

            return totalPayment;
        }

        private void RemovedOtherPaymentCharge(DataGridViewRow row, DataGridView dgOtherPaymentCharges)
        {
            dgOtherPaymentCharges.Rows.Remove(row);
        }

        internal void CreatedOtherPaymentChargesColumns(DataGridView datagrid)
        {
            datagrid.ColumnCount = 5;
            datagrid.Columns[0].Name = "description";
            datagrid.Columns[1].Name = "debit_amount";
            datagrid.Columns[2].Name = "accountable_form_type";
            datagrid.Columns[3].Name = "unit";
            datagrid.Columns[4].Name = "total_amount";

            datagrid.Columns[0].HeaderText = "Description";
            datagrid.Columns[1].HeaderText = "Debit Amount";
            datagrid.Columns[2].HeaderText = "AF Type";
            datagrid.Columns[3].HeaderText = "Unit";
            datagrid.Columns[4].HeaderText = "Total Amount";

            datagrid.RowHeadersVisible = false;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            datagrid.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["description"].MinimumWidth = 150;
            datagrid.Columns["accountable_form_type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["accountable_form_type"].MinimumWidth = 80;
            datagrid.Columns["accountable_form_type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["debit_amount"].DefaultCellStyle.Format = "#,0.00###";
            datagrid.Columns["debit_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["unit"].MinimumWidth = 50;
            datagrid.Columns["unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["debit_amount"].MinimumWidth = 80;
            datagrid.Columns["total_amount"].DefaultCellStyle.Format = "#,0.00###";
            datagrid.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["total_amount"].MinimumWidth = 80;
        }

        private void CreateImageList(ref ImageList nodeImageList)
        {
            //nodeImageList.Images.Add("0", Properties.Resources.heirarchy1_20px);
            //nodeImageList.Images.Add("1", Properties.Resources.heirarchy2_20px);
            //nodeImageList.Images.Add("2", Properties.Resources.heirarchy3_20px);
            //nodeImageList.Images.Add("3", Properties.Resources.heirarchy4_20px);
            //nodeImageList.Images.Add("4", Properties.Resources.heirarchy4_20px);

            treeViewTaxTypes.ImageList = nodeImageList;
            treeViewTaxTypes.ImageIndex = 0;
            treeViewTaxTypes.SelectedImageIndex = 0;
        }

        private void PopulateTreeView(string parentID, TreeNode parentNode)
        {
            var dtChildNoTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(Convert.ToInt32(parentID));

            ImageList nodeImageList = new ImageList();
            CreateImageList(ref nodeImageList);

            foreach (DataRow dr in dtChildNoTaxTypes.Rows)
            {
                TreeNode childNode;

                if (parentNode == null)
                {
                    childNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());
                    childNode.ImageIndex = 0;
                    childNode.SelectedImageIndex = 0;
                }
                else
                {
                    childNode = parentNode.Nodes.Add(dr["description"].ToString());
                    childNode.ImageIndex = childImageIndexCounter;
                    childNode.SelectedImageIndex = childImageIndexCounter;

                    if (childImageIndexCounter >= nodeImageList.Images.Count)
                        childImageIndexCounter = 1;
                    else
                        childImageIndexCounter++;
                }

                string taxTypeID = dr["id"].ToString();
                childNode.Tag = taxTypeID;
                PopulateTreeView(taxTypeID, childNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    childNode.ForeColor = Color.Gray;
            }
        }

        #endregion Private Methods

        #region Event Methods

        private void dgOtherPaymentCharges_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgOtherPaymentCharges.CurrentRow.Index;

            try
            {
                int unit = Convert.ToInt32(dgOtherPaymentCharges.Rows[rowIndex].Cells["unit"].Value);

                decimal debitAmount = Convert.ToDecimal(dgOtherPaymentCharges.Rows[rowIndex].Cells["debit_amount"].Value);
                dgOtherPaymentCharges.Rows[rowIndex].Cells["total_amount"].Value = debitAmount * unit;
            }
            catch (Exception)
            {
                dgOtherPaymentCharges.Rows[rowIndex].Cells["unit"].Value = 1;
            }
        }

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
                Dictionary<string, string> dictPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecordsByTaxTypeID(taxTypeID);

                if (dictPaymentRates.Count <= 0)
                    return;

                description = dictPaymentRates["description"];
                debitAmount = Convert.ToDecimal(dictPaymentRates["amount"]);
                subTotalAmount = unit * debitAmount;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgOtherPaymentCharges.SelectedRows)
                {
                    RemovedOtherPaymentCharge(row, dgOtherPaymentCharges);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddOtherPaymentCharge();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dgOtherPaymentCharges.Rows.Clear();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}