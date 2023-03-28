using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountingSystem.Views.Manage.TaxTypes
{
    public partial class frmTaxTypes : Form
    {
        private bool isUpdate = false;
        public frmTaxTypes()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxParentCode.Text))
            {
                TreeNode node = new TreeNode(txtDesciption.Text);
                treeViewTaxTypes.Nodes.Add(node);
            }
            else 
            {
                TreeNode node = new TreeNode(txtDesciption.Text);
                treeViewTaxTypes.SelectedNode.Nodes.Add(node); 
            }

            if (!isUpdate)
            {
                if (InsertNewTaxTypes())
                {
                    Helper.MessageBoxSuccess("Tax type has been saved.");
                    LoadTaxTypes();
                    ResetForm();
                    ClearFields();
                }
            }
            else
            {
                if (UpdateTaxTypes())
                {
                    Helper.MessageBoxSuccess("Tax type has been updated.");
                    LoadTaxTypes();
                    ResetForm();
                    ClearFields();
                }
            }
           
        }

        private bool InsertNewTaxTypes()
        {
            string code = txtCode.Text;
            string desciption = txtDesciption.Text;
            var parent = string.IsNullOrEmpty(cmbxParentCode.Text) ? null : treeViewTaxTypes.SelectedNode.Tag.ToString();
            int fundID = Convert.ToInt32(cmbxFundType.SelectedValue);
            string coaAccountCode = txtCOAAccountCode.Text;
            string BLFGAccountCode = txtBLFGAccountCode.Text;

            var taxTypesModel = new TaxTypesModel()
            {
                Code = code, 
                Description = desciption,
                ParentID = parent, 
                FundID = fundID,
                COAAccountCode = coaAccountCode,
                BLGFAccountCode = BLFGAccountCode
            };

            return AccFactory.TaxTypesRepository().Insert(taxTypesModel);
        }

        private bool UpdateTaxTypes()
        {
            int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
            string code = txtCode.Text;
            string desciption = txtDesciption.Text;
            var parent = string.IsNullOrEmpty(cmbxParentCode.Text) ? null : treeViewTaxTypes.SelectedNode.Tag.ToString();
            int fundID = Convert.ToInt32(cmbxFundType.SelectedValue);
            string coaAccountCode = txtCOAAccountCode.Text;
            string BLFGAccountCode = txtBLFGAccountCode.Text;

            var taxTypesModel = new TaxTypesModel()
            {
                ID = taxTypeID,
                Code = code,
                Description = desciption,
                ParentID = parent,
                FundID = fundID,
                COAAccountCode = coaAccountCode,
                BLGFAccountCode = BLFGAccountCode
            };

            return AccFactory.TaxTypesRepository().Update(taxTypesModel);
        }

        private void LoadTaxTypes()
        {
            treeViewTaxTypes.Nodes.Clear();

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

        private void PopulateTreeView(string parentID, TreeNode parentNode)
        {
            var dtChildNoTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(Convert.ToInt32(parentID));

            foreach (DataRow dr in dtChildNoTaxTypes.Rows)
            {
                TreeNode childNode;
                if (parentNode == null)
                    childNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());
                else
                    childNode = parentNode.Nodes.Add(dr["description"].ToString());

                string taxTypeID = dr["id"].ToString();
                childNode.Tag = taxTypeID;
                PopulateTreeView(taxTypeID, childNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    parentNode.ForeColor = Color.Gray;
            }
        }

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewTaxTypes.SelectedNode.ForeColor != Color.Gray)
            {
                toolStripButtonEdit.Enabled = true;
                toolStripButtonDelete.Enabled = true;
                toolStripSeparator1.Visible = false;
                toolStripButtonUndelete.Visible = false;
            }
            else
            {
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                toolStripSeparator1.Visible = true;
                toolStripButtonUndelete.Visible = true;
            }

            if (panel2.Enabled)
                ShowDetailsOfSelectedTaxType();

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            panel2.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            btnSave.Text = "Save";
            isUpdate = false;

            int taxTypeParentCodeID = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);
            cmbxParentCode.Text = AccFactory.TaxTypesRepository().GetParentCodeByID(taxTypeParentCodeID); 

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            ClearFields();
        }

        private void ResetForm()
        {
            panel2.Enabled = false;
            toolStrip2.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            btnSave.Text = "Save";
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            isUpdate = false;
        }

        private void ClearFields()
        {
            txtCode.Focus();
            txtCode.Clear();
            txtDesciption.Clear();
            cmbxParentCode.Text = string.Empty;
            cmbxFundType.SelectedIndex = 0;
            txtCOAAccountCode.Clear();
            txtBLFGAccountCode.Clear();
            isUpdate = false;
        }

        private void frmTaxTypes_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadTaxTypes();
            //LoadParentCode();
        }

        private void LoadParentCode()
        {
            try
            {
                DataTable dtParentCode = AccFactory.TaxTypesRepository().GetTaxTypeCodes();
                cmbxParentCode.DataSource = dtParentCode;
                cmbxParentCode.ValueMember = "id";
                cmbxParentCode.DisplayMember = "code";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadFunds()
        {
            try
            {
                var fundRepository = AccFactory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                cmbxFundType.DataSource = dtFund;
                cmbxFundType.ValueMember = "id";
                cmbxFundType.DisplayMember = "fund_name";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;  
            btnSave.Text = "Update";
            btnSave.Enabled = true; 
            btnCancel.Enabled = true;
            toolStrip2.Enabled = false;
            isUpdate = true;

            ShowDetailsOfSelectedTaxType();
        }

        private void ShowDetailsOfSelectedTaxType()
        {
            try
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
                int taxTypeParentCodeID = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);

                var dictTaxTypes = AccFactory.TaxTypesRepository().GetRecordByID(taxTypeID);
                string parentCode = AccFactory.TaxTypesRepository().GetParentCodeByID(taxTypeParentCodeID);

                txtCode.Text = dictTaxTypes["code"];
                txtDesciption.Text = dictTaxTypes["description"];
                cmbxParentCode.Text = parentCode;
                cmbxFundType.SelectedValue = Convert.ToInt32(dictTaxTypes["funds_id"]);
                txtCOAAccountCode.Text = dictTaxTypes["coa_account_code"];
                txtBLFGAccountCode.Text = dictTaxTypes["blgf_account_code"];
            }
            catch (Exception)
            { }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteTaxType())
                {
                    Helper.MessageBoxSuccess("Tax type has been deleted.");
                    LoadTaxTypes();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool DeleteTaxType()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to delete selected tax type?"))
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);

                return AccFactory.TaxTypesRepository().DeleteTaxType(taxTypeID);
            }

            return false;
        }

        private void treeViewTaxTypes_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
                e.Cancel = true;
        }

        private void toolStripButtonUndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UnDeleteTaxType())
                {
                    Helper.MessageBoxSuccess("Tax type has been undeleted.");
                    LoadTaxTypes();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool UnDeleteTaxType()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to undelete selected tax type?"))
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);

                return AccFactory.TaxTypesRepository().UnDeleteTaxType(taxTypeID);
            }

            return false;
        }
    }
}
