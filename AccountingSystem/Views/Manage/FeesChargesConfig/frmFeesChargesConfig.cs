using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.FeesChargesConfig.Classification;
using AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountingSystem.Views.Manage.FeesChargesConfig
{
    public partial class frmFeesChargesConfig : Form
    {
        private int childImageIndexCounter = 1;

        public frmFeesChargesConfig()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmFeesChargesConfig_Load(object sender, EventArgs e)
        {
            LoadFeesCharges();
            ToggleButtons(treeViewFeesCharges);
        }

        private bool UnDeleteTaxType()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to undelete selected tax type?"))
            {
                int taxTypeID = Convert.ToInt32(treeViewFeesCharges.SelectedNode.Tag);

                return AccFactory.TaxTypesRepository().UnDeleteTaxType(taxTypeID);
            }

            return false;
        }

        internal void LoadFeesCharges()
        {
            if (!backgroundWorker1.IsBusy)
            {
                treeViewFeesCharges.ImageList = ImageList();
                treeViewFeesCharges.Nodes.Clear();
                childImageIndexCounter = 1;
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private ImageList ImageList()
        {
            ImageList imageList = new ImageList();

            imageList.Images.Add("classification_active", Properties.Resources.folder_filled_20px);
            imageList.Images.Add("feescharges", Properties.Resources.document_color_green_filled_20px);
            imageList.Images.Add("classification_disabled", Properties.Resources.disabled_folder_filled_20px);

            return imageList;
        }

        private void LoadFeesChargesNodes(int feesChargesClassificationId, TreeNode nodeFeesChargesClassification)
        {
            var dtFeesCharges = AccFactory.OtherPaymentRatesRepository().GetRecordsByTaxTypeID(feesChargesClassificationId);
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (DataRow row in dtFeesCharges.Rows)
            {
                var feesChargesNode = new TreeNode
                {
                    Text = row["description"].ToString(),
                    Tag = $"feescharges-{row["id"]}",
                    ImageKey = "feescharges",
                    SelectedImageKey = "feescharges"
                };

                nodes.Add(feesChargesNode);
            }

            nodeFeesChargesClassification.Nodes.AddRange(nodes.ToArray());
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

                var dataTable = AccFactory.TaxTypesRepository().GetRecords();
                EnumerableRowCollection<DataRow> parentNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") == null);

                int progressCount = 0;
                int totalProgressCount = dataTable.Rows.Count;

                foreach (DataRow parentRow in parentNodes)
                {
                    string parentRawName = parentRow.Field<string>("description");
                    string parentNodeName = parentRow.Field<sbyte>("is_deleted") == 1 ? $"{parentRawName} (Deleted)" : parentRawName;
                    TreeNode parentNode = new TreeNode(parentNodeName);
                    parentNode.Tag = $"classification-{parentRow.Field<int>("id")}";

                    var parentImageKey = parentRow.Field<sbyte>("is_deleted") == 1 ? "classification_disabled" : "classification_active";
                    var parentForeColor = parentRow.Field<sbyte>("is_deleted") == 1 ? System.Drawing.Color.Gray : parentNode.ForeColor;

                    parentNode.ImageKey = parentImageKey;
                    parentNode.SelectedImageKey = parentImageKey;
                    parentNode.ForeColor = parentForeColor;

                    mainTreeView.Nodes.Add(parentNode);
                    LoadFeesChargesNodes(parentRow.Field<int>("id"), parentNode);

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    EnumerableRowCollection<DataRow> childNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") != null && row.Field<int>("parent") == parentRow.Field<int>("id"));

                    foreach (DataRow childRow in childNodes)
                    {
                        string childRawName = childRow.Field<string>("description");
                        string childNodeName = childRow.Field<sbyte>("is_deleted") == 1 ? $"{childRawName} (Deleted)" : childRawName;
                        TreeNode childNode = new TreeNode(childNodeName);
                        childNode.Tag = $"classification-{childRow.Field<int>("id")}";

                        var childImageKey = childRow.Field<sbyte>("is_deleted") == 1 ? "classification_disabled" : "classification_active";
                        var childForeColor = childRow.Field<sbyte>("is_deleted") == 1 ? System.Drawing.Color.Gray : childNode.ForeColor;

                        childNode.ImageKey = childImageKey;
                        childNode.SelectedImageKey = childImageKey;
                        childNode.ForeColor = childForeColor;

                        parentNode.Nodes.Add(childNode);

                        LoadFeesChargesNodes(childRow.Field<int>("id"), childNode);

                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }
                }

                e.Result = mainTreeView;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Result is not TreeNode treeNode)
                return;

            treeViewFeesCharges.Nodes.Add(treeNode);
            treeViewFeesCharges.ExpandAll();
        }

        private void ToggleButtons(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode is null)
            {
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnNewFeesCharges.Enabled = false;
                btnUndelete.Enabled = false;
                return;
            }
            else

            //Check if selected node tag is null
            if (treeView.SelectedNode.Tag is null)
            {
                drpDownBtnNew.Enabled = true;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnNewFeesCharges.Enabled = false;
                btnUndelete.Enabled = false;
            }
            else
            {
                drpDownBtnNew.Enabled = true;
                btnDelete.Enabled = true;
                btnModify.Enabled = true;
                btnNewFeesCharges.Enabled = true;
                btnUndelete.Enabled = true;

                var nodeParameters = GetNodeParameters(treeView.SelectedNode);

                if (nodeParameters.paramRef == "feescharges")
                    drpDownBtnNew.Enabled = false;
                else
                    drpDownBtnNew.Enabled = true;
            }

            if (treeView.SelectedNode.Text.ToLower().Contains("deleted"))
            {
                btnDelete.Enabled = false;
                btnUndelete.Enabled = true;
                btnModify.Enabled = false;
                drpDownBtnNew.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnUndelete.Enabled = false;
                btnModify.Enabled = true;
                drpDownBtnNew.Enabled = true;
            }
        }

        private void treeViewFeesCharges_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ToggleButtons(treeViewFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnNewClassification_Click(object sender, EventArgs e)
        {
            try
            {
                var nodeParameter = GetNodeParameters(treeViewFeesCharges.SelectedNode);
                _ = new frmAddFeesChargesClassification(nodeParameter.paramId, this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnNewFeesCharges_Click(object sender, EventArgs e)
        {
            try
            {
                var nodeParameter = GetNodeParameters(treeViewFeesCharges.SelectedNode);
                _ = new frmAddFeesCharges(nodeParameter.paramId, this).ShowDialog();
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

        private void ShowModifyForm(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode?.Tag is null)
                return;

            var parameters = GetNodeParameters(treeView.SelectedNode);

            //if node is a classification go to
            if (parameters.paramRef == "classification")
                _ = new frmEditFeesChargesClassification(parameters.paramId, this).ShowDialog();
            else if (parameters.paramRef == "feescharges")
            {
                var getParentNodeParameters = GetNodeParameters(treeView.SelectedNode.Parent);
                _ = new frmEditFeesCharges(parameters.paramId, getParentNodeParameters.paramId, this).ShowDialog();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                ShowModifyForm(treeViewFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecord(out string deleteMessage)
        {
            var nodeParameter = GetNodeParameters(treeViewFeesCharges.SelectedNode);

            switch (nodeParameter.paramRef)
            {
                case "classification":
                    if (Helper.MessageBoxConfirmCancel("Deleting this classification removes all linked fees & charges. Confirm deletion?"))
                    {
                        deleteMessage = "Classification";
                        return AccFactory.TaxTypesRepository().DeleteTaxType(nodeParameter.paramId);
                    }

                    deleteMessage = string.Empty;
                    return false;

                case "feescharges":
                    if (Helper.MessageBoxConfirmCancel("Confirm deletion?"))
                    {
                        var feesChargesModels = new List<OtherPaymentRatesModel>() { new OtherPaymentRatesModel() { Id = nodeParameter.paramId } };
                        deleteMessage = "Fees & Charges";
                        return AccFactory.OtherPaymentRatesRepository().Delete(feesChargesModels);
                    }
                    deleteMessage = string.Empty;
                    return false;

                default:
                    deleteMessage = string.Empty;
                    return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteMessage;
                if (DeleteRecord(out deleteMessage))
                {
                    LoadFeesCharges();
                    Helper.MessageBoxSuccess($"{deleteMessage} has been deleted");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}