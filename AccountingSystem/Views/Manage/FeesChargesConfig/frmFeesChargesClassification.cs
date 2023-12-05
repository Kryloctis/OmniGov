using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges;
using DocumentFormat.OpenXml.EMMA;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security.Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void CreateImageList(ref ImageList nodeImageList)
        {
            nodeImageList.Images.Add("0", Properties.Resources.folder_filled_20px);
            nodeImageList.Images.Add("1", Properties.Resources.folder_filled_20px);
            nodeImageList.Images.Add("2", Properties.Resources.folder_filled_20px);
            nodeImageList.Images.Add("3", Properties.Resources.folder_filled_20px);
            nodeImageList.Images.Add("4", Properties.Resources.folder_filled_20px);

            treeViewFeesCharges.ImageList = nodeImageList;
            treeViewFeesCharges.ImageIndex = 0;
            treeViewFeesCharges.SelectedImageIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void LoadTaxTypes()
        {
            if (!backgroundWorker1.IsBusy)
            {
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

        private void LoadChildNodes(int parentID, TreeNode parentNode)
        {
            DataTable dtChildNodeTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(parentID);

            ImageList nodeImageList = new();
            CreateImageList(ref nodeImageList);

            foreach (DataRow dr in dtChildNodeTaxTypes.Rows)
            {
                string taxTypeCode = dr["code"].ToString();
                string taxTypeDescription = dr["description"].ToString();
                string displayText = $"({taxTypeCode}) {taxTypeDescription}";

                TreeNode childNode;

                childNode = parentNode.Nodes.Add(displayText);
                childNode.ImageIndex = childImageIndexCounter;
                childNode.SelectedImageIndex = childImageIndexCounter;

                if (childImageIndexCounter >= nodeImageList.Images.Count)
                    childImageIndexCounter = 1;
                else
                    childImageIndexCounter++;

                int taxTypeID = Convert.ToInt32(dr["id"]);
                childNode.Tag = taxTypeID;
                LoadChildNodes(taxTypeID, childNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    childNode.ForeColor = Color.Gray;

                childImageIndexCounter = 1;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    var rootNode = new TreeNode();
                    rootNode.Text = "Classifications";
                    var dataTable = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();

                    int progressCount = 0;
                    int totalProgressCount = dataTable.Rows.Count;

                    treeViewFeesCharges.Nodes.Add(rootNode);

                    TreeNode node;

                    foreach (DataRow dr in dataTable.Rows)
                    {
                        int taxTypeID = Convert.ToInt32(dr["id"]);
                        string taxTypeCode = dr["code"].ToString();
                        string taxTypeDescription = dr["description"].ToString();
                        string displayText = $"({taxTypeCode}) {taxTypeDescription}";

                        node = rootNode.Nodes.Add(displayText);
                        node.Tag = taxTypeID;

                        LoadChildNodes(taxTypeID, node);

                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                        if (Convert.ToBoolean(dr["is_deleted"]))
                            node.ForeColor = Color.Gray;
                    }

                    e.Result = dataTable;
                }));
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled)
            //    return;
            //if (e.Result is not DataTable dataTable)
            //    return;
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

            if (treeView.SelectedNode.ForeColor == Color.Gray)
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
                _ = new frmAddFeesChargesClassification().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnFeesCharges_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddFeesCharges().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowModifyForm()
        {
            //if node is a classification go to
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                ShowModifyForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}