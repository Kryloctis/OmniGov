using ACC.Data;
using AccountingSystem.Views.Manage.FeesChargesConfig.Classification;
using AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class frmFeesChargesClassification : Form
    {
        private int childImageIndexCounter = 1;

        public frmFeesChargesClassification()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private ImageList ImageList()
        {
            ImageList imageList = new ImageList();

            imageList.Images.Add("classification", Properties.Resources.folder_filled_20px);
            imageList.Images.Add("feescharges", Properties.Resources.document_color_green_filled_20px);

            return imageList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        internal void LoadTaxTypes()
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

        private void frmTaxTypes_Load(object sender, EventArgs e)
        {
            LoadTaxTypes();
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

                foreach (DataRow row in parentNodes)
                {
                    TreeNode parentNode = new TreeNode(row.Field<string>("description"));
                    parentNode.Tag = $"classification-{row.Field<int>("id")}";
                    parentNode.ImageKey = "classification";

                    mainTreeView.Nodes.Add(parentNode);
                    LoadFeesChargesNodes(row.Field<int>("id"), parentNode);

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    EnumerableRowCollection<DataRow> childNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") != null && row.Field<int>("parent") == row.Field<int>("id"));

                    foreach (DataRow childRow in childNodes)
                    {
                        TreeNode childNode = new TreeNode(row.Field<string>("description"));
                        childNode.Tag = $"classification-{row.Field<int>("id")}";
                        childNode.ImageKey = "classification";

                        parentNode.Nodes.Add(childNode);
                        LoadFeesChargesNodes(row.Field<int>("id"), parentNode);

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
                _ = new frmAddFeesChargesClassification(this).ShowDialog();
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

        private string GetNodeTitle(System.Windows.Forms.TreeView treeView)
        {
            var nodeTag = treeView.SelectedNode.Tag.ToString();
            string nodeTagTitle = nodeTag.Substring(0, nodeTag.IndexOf('-'));

            return nodeTagTitle;
        }

        private int GetNodeId(System.Windows.Forms.TreeView treeView)
        {
            var nodeTag = treeView.SelectedNode.Tag.ToString();
            int nodeId = Convert.ToInt32(nodeTag.Substring(nodeTag.IndexOf('-') + 1));

            return nodeId;
        }

        private void ShowModifyForm(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode?.Tag is null)
                return;

            var nodeTagTitle = GetNodeTitle(treeView);
            var nodeId = GetNodeId(treeView);

            //if node is a classification go to
            if (nodeTagTitle == "classification")
                _ = new frmEditFeesChargesClassification(nodeId, this).ShowDialog();
            else if (nodeTagTitle == "feescharges")
                _ = new frmEditFeesCharges(nodeId, this).ShowDialog();
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