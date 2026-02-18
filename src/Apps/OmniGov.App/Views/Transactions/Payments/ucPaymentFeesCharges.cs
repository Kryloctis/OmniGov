using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.Payments
{
    public partial class ucPaymentFeesCharges : UserControl
    {
        public ucPaymentFeesCharges()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgPaymentFeesCharges);
        }

        internal void OnLoad()
        {
            LoadFeesCharges();
            ToggleTreeViewButtons(treeViewFeesCharges);
            LoadPaymentFeesCharges();
            ToggleDatagridViewButtons(dgPaymentFeesCharges);
        }

        internal List<PaymentFeesChargesModel> PaymentFeesChargesModels()
        {
            var paymentFeesChargesModels = new List<PaymentFeesChargesModel>();
            var dtSelectedFeesCharges = (DataTable)dgPaymentFeesCharges.DataSource;

            foreach (DataRow row in dtSelectedFeesCharges.Rows)
            {
                var model = new PaymentFeesChargesModel()
                {
                    OtherPaymentRatesId = Convert.ToInt32(row["fees_charges_id"]),
                    Unit = Convert.ToInt32(row["unit"]),
                    SubTotal = Convert.ToDecimal(row["sub_total"])
                };
                paymentFeesChargesModels.Add(model);
            }

            return paymentFeesChargesModels;
        }

        private DataTable DataTablePaymentFeesCharges()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "fees_charges_id", typeof(int)),
                new DataColumn(Name = "classification", typeof(string)),
                new DataColumn(Name = "description", typeof(string)),
                new DataColumn(Name = "is_rate_editable", typeof(bool)),
                new DataColumn(Name = "amount", typeof(decimal)),
                new DataColumn(Name = "unit", typeof(int)),
                new DataColumn(Name = "sub_total", typeof(decimal))
            };

            DataTable tableFeesCharges = new DataTable();
            tableFeesCharges.Columns.AddRange(dataColumns);

            return tableFeesCharges;
        }

        internal void ResetForm()
        {
            ((DataTable)dgPaymentFeesCharges.DataSource)?.Rows.Clear();
            LoadFeesCharges();

            dgPaymentFeesCharges.Refresh();
        }

        private void LoadPaymentFeesCharges()
        {
            if (dgPaymentFeesCharges.DataSource is null)
                HelperLoadRecords.DataGridViewPaymentFeesCharges(DataTablePaymentFeesCharges(), dgPaymentFeesCharges);
        }

        private void RemovedOtherPaymentCharge(DataGridView dataGridView)
        {
            DataTable dtPayementCharges = (DataTable)dataGridView.DataSource;

            foreach (DataGridViewRow dgRow in dataGridView.SelectedRows)
            {
                dtPayementCharges.Rows.RemoveAt(dgRow.Index);
            }

            dgPaymentFeesCharges.Refresh();
        }

        private void ApplyPaymentFeesCharges(TreeNode treeNode, DataGridView dataGridView)
        {
            var feesChargesNodeParameter = GetNodeParameters(treeNode);

            var dictFeesCharges = TreasuryFactory.OtherPaymentRatesRepository().GetRecordByID(feesChargesNodeParameter.paramId);
            sbyte isEditable = Convert.ToSByte(dictFeesCharges["is_rate_editable"]);
            DataTable dtPaymentFees = (DataTable)dataGridView.DataSource;

            var newRow = dtPaymentFees.NewRow();

            decimal amount = Convert.ToDecimal(dictFeesCharges["amount"]);
            decimal unit = 1;

            newRow["fees_charges_id"] = feesChargesNodeParameter.paramId;
            newRow["classification"] = treeNode.Parent.Text;
            newRow["description"] = treeNode.Text;
            newRow["is_rate_editable"] = Convert.ToBoolean(isEditable);
            newRow["amount"] = amount;
            newRow["unit"] = unit;
            newRow["sub_total"] = amount * unit;

            dtPaymentFees.Rows.Add(newRow);
            dataGridView.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatedFeesCharges(treeViewFeesCharges))
                    ApplyPaymentFeesCharges(treeViewFeesCharges.SelectedNode, dgPaymentFeesCharges);

                treeViewFeesCharges.SelectedNode = null;
                ToggleTreeViewButtons(treeViewFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemovedOtherPaymentCharge(dgPaymentFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ValidatedFeesCharges(TreeView treeView)
        {
            if (treeView.SelectedNode is null)
                return false;
            else if (treeView.SelectedNode.Tag is null)
                return false;

            return true;
        }

        private void LoadFeesCharges()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                treeViewFeesCharges.ImageList = ImageList();
                treeViewFeesCharges.Nodes.Clear();
                backgroundWorker1.RunWorkerAsync(tStrpTxtSearch.Text.Trim());
            }
        }

        private bool LoadFeesChargesNodes(int feesChargesClassificationId, bool isDeleted, TreeNode nodeFeesChargesClassification)
        {
            string searchText = tStrpTxtSearch.Text.Trim();
            var dtFeesCharges = TreasuryFactory.OtherPaymentRatesRepository().GetRecordsByTaxTypeIDAndDescription(feesChargesClassificationId, searchText);
            bool hasFeesCharges = false;

            foreach (DataRow row in dtFeesCharges.Rows)
            {
                var imageKey = isDeleted ? "feescharges_disabled" : "feescharges_active";

                var feesChargesNode = new TreeNode
                {
                    Text = row["description"].ToString(),
                    Tag = $"feescharges-{row["id"]}",
                    ImageKey = imageKey,
                    SelectedImageKey = imageKey,
                    ForeColor = isDeleted ? System.Drawing.Color.Gray : ForeColor
                };

                nodeFeesChargesClassification.Nodes.Add(feesChargesNode);
                hasFeesCharges = true;
            }

            return hasFeesCharges;
        }

        private bool RemoveEmptyNodes(TreeNodeCollection nodes)
        {
            bool hasValidChildren = false;

            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                TreeNode node = nodes[i];

                // Recursively process child nodes
                bool childHasFeesCharges = RemoveEmptyNodes(node.Nodes);

                // Check if the node is a fees charge node
                bool isFeesChargeNode = node.Tag != null && node.Tag.ToString().Contains("feescharges");

                // Remove nodes that are classification but have no valid fees charge children
                if (!isFeesChargeNode && !childHasFeesCharges)
                    nodes.RemoveAt(i);
                else
                    hasValidChildren = true;
            }

            return hasValidChildren;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var mainTreeView = new TreeNode()
                {
                    Text = "Classifications",
                    Tag = null,
                    ImageKey = "classification",
                };

                mainTreeView.ExpandAll();
                var dtTaxTypes = TreasuryFactory.TaxTypesRepository().GetRecords();
                var parentNodes = dtTaxTypes.AsEnumerable().Where(row => row.Field<dynamic>("parent") == null);

                int progressCount = 0;
                int totalProgressCount = parentNodes.Count();

                foreach (DataRow parentRow in parentNodes)
                {
                    bool isParentDeleted = parentRow.Field<sbyte>("is_deleted") == 1;
                    string parentRawName = parentRow.Field<string>("description");
                    string parentNodeName = isParentDeleted ? $"{parentRawName} (Deleted)" : parentRawName;

                    TreeNode parentNode = new TreeNode(parentNodeName)
                    {
                        Tag = $"classification-{parentRow.Field<int>("id")}",
                        ImageKey = isParentDeleted ? "classification_disabled" : "classification_active",
                        SelectedImageKey = isParentDeleted ? "classification_disabled" : "classification_active",
                        ForeColor = isParentDeleted ? System.Drawing.Color.Gray : System.Drawing.Color.Black
                    };

                    mainTreeView.Nodes.Add(parentNode);
                    // Update progress for each classification
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    bool hasFeesCharges = LoadFeesChargesNodes(parentRow.Field<int>("id"), isParentDeleted, parentNode);

                    // Process child nodes
                    var childNodes = dtTaxTypes.AsEnumerable().Where(row => row.Field<dynamic>("parent") != null && row.Field<int>("parent") == parentRow.Field<int>("id"));
                    foreach (DataRow childRow in childNodes)
                    {
                        string childRawName = childRow.Field<string>("description");
                        bool isChildDeleted = childRow.Field<sbyte>("is_deleted") == 1;
                        string childNodeName = isChildDeleted ? $"{childRawName} (Deleted)" : childRawName;

                        TreeNode childNode = new TreeNode(childNodeName)
                        {
                            Tag = $"classification-{childRow.Field<int>("id")}",
                            ImageKey = isChildDeleted ? "classification_disabled" : "classification_active",
                            SelectedImageKey = isChildDeleted ? "classification_disabled" : "classification_active",
                            ForeColor = isChildDeleted ? System.Drawing.Color.Gray : System.Drawing.Color.Black
                        };

                        parentNode.Nodes.Add(childNode);
                        bool hasChildFeesCharges = LoadFeesChargesNodes(childRow.Field<int>("id"), isChildDeleted, childNode);

                        if (!hasChildFeesCharges)
                            RemoveEmptyNodes(childNode.Nodes);
                    }

                    // Remove empty nodes from the main tree
                    RemoveEmptyNodes(mainTreeView.Nodes);
                }

                e.Result = mainTreeView;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Result is not TreeNode treeNode)
                return;

            treeViewFeesCharges.Nodes.Add(treeNode);
            treeViewFeesCharges.ExpandAll();
            treeViewFeesCharges.SelectedNode = treeViewFeesCharges.Nodes[0];
        }

        private void ComputeSubTotal(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count < 1)
                return;

            DataGridViewRow currentRow = dataGridView.CurrentRow;

            // Get values from "amount" and "unit" cells in the current row
            decimal amountValue = Convert.ToDecimal(currentRow.Cells["amount"].Value ?? 0);
            decimal unitValue = Convert.ToDecimal(currentRow.Cells["unit"].Value ?? 1);

            // Calculate the total amount and update the "total" cell
            decimal totalAmount = amountValue * unitValue;
            currentRow.Cells["sub_total"].Value = totalAmount;
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                dgPaymentFeesCharges.Tag is null? string.Empty : dgPaymentFeesCharges.Tag.ToString()
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal decimal ComputeTotalAmountPayable()
        {
            decimal totalAmountPayable = 0;

            foreach (DataGridViewRow row in dgPaymentFeesCharges.Rows)
            {
                if (row.Cells["sub_total"].Value != null && decimal.TryParse(row.Cells["sub_total"].Value.ToString(), out decimal cellValue))
                    totalAmountPayable += cellValue;
            }
            return totalAmountPayable;
        }

        internal bool PaymentFeesChargesValidated(DataGridView dataGridView)
        {
            if (ComputeTotalAmountPayable() < 1)
            {
                dataGridView.Tag = "Please enter a valid payment amount.";
                return false;
            }

            return true;
        }

        private void dgPaymentFeesCharges_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ComputeSubTotal(dgPaymentFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgPaymentFeesCharges_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewCell currentCell = dgPaymentFeesCharges.CurrentCell;

                if (currentCell != null && currentCell.OwningColumn.Name == "amount" || currentCell.OwningColumn.Name == "unit")
                {
                    if (e.Control is TextBox textBox)
                    {
                        textBox.KeyPress -= dgPaymentFeesCharges_KeyPress;
                        textBox.KeyPress += dgPaymentFeesCharges_KeyPress;
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgPaymentFeesCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                    e.Handled = true;
                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
                    e.Handled = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgPaymentFeesCharges_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bool isAmountEditable = Convert.ToBoolean(dgPaymentFeesCharges.Rows[e.RowIndex].Cells["is_rate_editable"].Value);
                dgPaymentFeesCharges.Rows[e.RowIndex].Cells["amount"].ReadOnly = !isAmountEditable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private (string paramRef, int paramId) GetNodeParameters(TreeNode treeNode)
        {
            var nodeTag = treeNode.Tag.ToString();
            string paramRef = nodeTag.Substring(0, nodeTag.IndexOf('-'));
            int paramId = Convert.ToInt32(nodeTag.Substring(nodeTag.IndexOf('-') + 1));

            return (paramRef, paramId);
        }

        private ImageList ImageList()
        {
            ImageList imageList = new ImageList();

            imageList.Images.Add("classification_active", Properties.Resources.folder_filled_20px);
            imageList.Images.Add("classification_disabled", Properties.Resources.disabled_folder_filled_20px);

            imageList.Images.Add("feescharges_active", Properties.Resources.document_color_green_filled_20px);
            imageList.Images.Add("feescharges_disabled", Properties.Resources.disabled_document_filled_20px);

            return imageList;
        }

        private void ToggleTreeViewButtons(TreeView treeView)
        {
            btnAdd.Enabled = false;

            var selectedNode = treeView.SelectedNode;

            if (selectedNode != null && selectedNode.Tag != null)
            {
                var nodeParameters = GetNodeParameters(selectedNode);

                if (nodeParameters.paramRef == "feescharges")
                    btnAdd.Enabled = true;
                else
                    btnAdd.Enabled = false;
            }
        }

        private void ToggleDatagridViewButtons(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count < 1 || dataGridView.SelectedRows.Count < 1)
            {
                btnDelete.Enabled = false;
                return;
            }
            btnDelete.Enabled = true;
        }

        private void treeViewFeesCharges_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ToggleTreeViewButtons(treeViewFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgPaymentFeesCharges_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !PaymentFeesChargesValidated(dgPaymentFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgPaymentFeesCharges_Validated(object sender, EventArgs e)
        {
            dgPaymentFeesCharges.Tag = null;
        }

        private void dgPaymentFeesCharges_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleDatagridViewButtons(dgPaymentFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tStrpTxtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFeesCharges();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}