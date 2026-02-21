using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.FeesChargesConfig.Classification;
using OmniGov.App.Views.Manage.FeesChargesConfig.FeesCharges;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.FeesChargesConfig
{
    public partial class frmFeesChargesConfig : Form
    {
        private string lastTextSearch;

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

        internal void LoadFeesCharges()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                treeViewFeesCharges.ImageList = ImageList();
                treeViewFeesCharges.Nodes.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
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

        private void LoadFeesChargesNodes(int feesChargesClassificationId, bool isDeleted, TreeNode nodeFeesChargesClassification)
        {
            var textSearch = txtSearch.Text;
            var dtFeesCharges = TreasuryFactory.OtherPaymentRatesRepository().GetRecordsByTaxTypeIDAndDescription(feesChargesClassificationId, textSearch);
            List<TreeNode> nodes = new List<TreeNode>();

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

                var dataTable = TreasuryFactory.TaxTypesRepository().GetRecords();

                EnumerableRowCollection<DataRow> parentNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") == null);

                int progressCount = 0;
                int totalProgressCount = dataTable.Rows.Count;

                foreach (DataRow parentRow in parentNodes)
                {
                    bool isParentDeleted = parentRow.Field<sbyte>("is_deleted") == 1 ? true : false;
                    string parentRawName = parentRow.Field<string>("description");
                    string parentNodeName = isParentDeleted ? $"{parentRawName} (Deleted)" : parentRawName;
                    TreeNode parentNode = new TreeNode(parentNodeName);
                    parentNode.Tag = $"classification-{parentRow.Field<int>("id")}";

                    var parentImageKey = isParentDeleted ? "classification_disabled" : "classification_active";
                    var parentForeColor = isParentDeleted ? System.Drawing.Color.Gray : parentNode.ForeColor;

                    parentNode.ImageKey = parentImageKey;
                    parentNode.SelectedImageKey = parentImageKey;
                    parentNode.ForeColor = parentForeColor;

                    mainTreeView.Nodes.Add(parentNode);
                    LoadFeesChargesNodes(parentRow.Field<int>("id"), isParentDeleted, parentNode);

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    EnumerableRowCollection<DataRow> childNodes = dataTable.AsEnumerable().Where(row => row.Field<dynamic>("parent") != null && row.Field<int>("parent") == parentRow.Field<int>("id"));

                    foreach (DataRow childRow in childNodes)
                    {
                        string childRawName = childRow.Field<string>("description");
                        bool isChildDeleted = childRow.Field<sbyte>("is_deleted") == 1 ? true : false;

                        string childNodeName = isChildDeleted ? $"{childRawName} (Deleted)" : childRawName;
                        TreeNode childNode = new TreeNode(childNodeName);
                        childNode.Tag = $"classification-{childRow.Field<int>("id")}";

                        var childImageKey = isChildDeleted ? "classification_disabled" : "classification_active";
                        var childForeColor = isChildDeleted ? System.Drawing.Color.Gray : childNode.ForeColor;

                        childNode.ImageKey = childImageKey;
                        childNode.SelectedImageKey = childImageKey;
                        childNode.ForeColor = childForeColor;

                        parentNode.Nodes.Add(childNode);

                        LoadFeesChargesNodes(childRow.Field<int>("id"), isChildDeleted, childNode);

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
            drpDownBtnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            btnNewFeesCharges.Enabled = false;
            btnUndelete.Enabled = false;
            btnUndelete.Visible = false;

            if (treeView.SelectedNode is not null && treeView.SelectedNode.Tag is not null)
            {
                var nodeParameters = GetNodeParameters(treeView.SelectedNode);

                if (nodeParameters.paramRef == "feescharges")
                {
                    btnDelete.Enabled = true;
                    btnModify.Enabled = true;
                    drpDownBtnNew.Enabled = false;
                    btnUndelete.Visible = false;
                }
                else
                {
                    drpDownBtnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnModify.Enabled = true;
                    btnNewFeesCharges.Enabled = true;
                    btnUndelete.Enabled = true;
                }

                if (treeView.SelectedNode.Text.ToLower().Contains("deleted") || treeView.SelectedNode.Parent.Text.ToLower().Contains("deleted"))
                {
                    btnDelete.Enabled = false;
                    btnUndelete.Visible = nodeParameters.paramRef == "feescharges" ? false : true;
                    btnModify.Enabled = false;
                    drpDownBtnNew.Enabled = false;
                }
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
                int? parentId = null;
                TreeNode selectedNode = treeViewFeesCharges.SelectedNode;
                if (selectedNode is not null && selectedNode.Tag is not null)
                    parentId = GetNodeParameters(selectedNode).paramId;

                _ = new frmAddFeesChargesClassification(parentId, this).ShowDialog();
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
                    if (Helper.MessageBoxConfirmCancel("Deleting this classification disable all linked fees & charges. Confirm deletion?"))
                    {
                        deleteMessage = "Classification";
                        return TreasuryFactory.TaxTypesRepository().DeleteTaxType(nodeParameter.paramId);
                    }

                    deleteMessage = string.Empty;
                    return false;

                case "feescharges":
                    if (Helper.MessageBoxConfirmCancel("Confirm permanent deletion?"))
                    {
                        var feesChargesModels = new List<OtherPaymentRatesModel>() { new OtherPaymentRatesModel() { Id = nodeParameter.paramId } };
                        deleteMessage = "Fees & Charges";
                        return TreasuryFactory.OtherPaymentRatesRepository().Delete(feesChargesModels);
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

        private bool UndeleteClassification(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode?.Tag is null)
                return false;

            var nodeParameters = GetNodeParameters(treeView.SelectedNode);

            if (nodeParameters.paramRef != "classification")
                return false;

            if (treeView.SelectedNode.Parent.Text.ToLower().Contains("deleted"))
            {
                Helper.MessageBoxError("Unable to proceed with the action as the parent fees and charges classification has been deleted.");
                return false;
            }

            return TreasuryFactory.TaxTypesRepository().UnDeleteTaxType(nodeParameters.paramId);
        }

        private void btnUndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UndeleteClassification(treeViewFeesCharges))
                {
                    LoadFeesCharges();
                    Helper.MessageBoxSuccess("Fees & Charges Classification undeleted.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFeesCharges();
        }
    }
}
