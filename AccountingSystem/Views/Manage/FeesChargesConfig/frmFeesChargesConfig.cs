using ACC.Data;
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

            imageList.Images.Add("classification", Properties.Resources.folder_filled_20px);
            imageList.Images.Add("feescharges", Properties.Resources.document_color_green_filled_20px);

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
                    TreeNode parentNode = new TreeNode($"{parentRow.Field<string>("code")}: {parentRow.Field<string>("description")}");
                    parentNode.Tag = $"classification-{parentRow.Field<int>("id")}";
                    parentNode.ImageKey = "classification";

                    mainTreeView.Nodes.Add(parentNode);
                    LoadFeesChargesNodes(parentRow.Field<int>("id"), parentNode);

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    EnumerableRowCollection<DataRow> childNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") != null && row.Field<int>("parent") == parentRow.Field<int>("id"));

                    foreach (DataRow childRow in childNodes)
                    {
                        TreeNode childNode = new TreeNode($"{childRow.Field<string>("code")}: {childRow.Field<string>("description")}");
                        childNode.Tag = $"classification-{childRow.Field<int>("id")}";
                        childNode.ImageKey = "classification";

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
            //Check if no selected node
            if (treeView.SelectedNode is null)
            {
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnFeesCharges.Enabled = false;
                btnUndelete.Enabled = false;
                return;
            }

            //Check if selected node tag is null
            if (treeView.SelectedNode.Tag is null)
            {
                drpDownBtnNew.Enabled = true;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnFeesCharges.Enabled = false;
                btnUndelete.Enabled = false;
            }
            else
            {
                drpDownBtnNew.Enabled = true;
                btnDelete.Enabled = true;
                btnModify.Enabled = true;
                btnFeesCharges.Enabled = true;
                btnUndelete.Enabled = true;
            }

            if (treeView.SelectedNode.ForeColor == System.Drawing.Color.Gray)
                btnUndelete.Enabled = true;
            else
                btnUndelete.Enabled = false;
        }

        private void treeViewFeesCharges_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ToggleButtons(treeViewFeesCharges);
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

        private void btnFeesCharges_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddFeesCharges(this).ShowDialog();
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
                _ = new frmEditFeesCharges(parameters.paramId, this).ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                ShowModifyForm(treeViewFeesCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}