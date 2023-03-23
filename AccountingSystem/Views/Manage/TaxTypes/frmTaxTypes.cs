using ACC.Domain.Models;
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
        public frmTaxTypes()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                TreeNode node = new TreeNode(txtDesciption.Text);
                treeViewTaxTypes.Nodes.Add(node);
            }
            else 
            {
                TreeNode node = new TreeNode(txtDesciption.Text);
                treeViewTaxTypes.SelectedNode.Nodes.Add(node); 
            }

            if (InsertNewNode())
            {
                Helper.MessageBoxSuccess("New node has been saved.");
                LoadTaxTypes();
                //uc.ResetForm();
            }
        }

        private bool InsertNewNode()
        {
            if (!ValidateChildren())
            {
                //Helper.MessageBoxError(GetFormErrors());
                //return false;
            }

            string code = txtCode.Text;
            string desciption = txtDesciption.Text;
            int parent = 1;
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

        private void LoadTaxTypes()
        {
            treeViewTaxTypes.Nodes.Clear();

            var dtTaxTypes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();
 
            TreeNode parentNode;

            foreach (DataRow dr in dtTaxTypes.Rows)
            {
                parentNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());

                parentNode.Tag = dr["id"].ToString();
                PopulateTreeView(dr["id"].ToString(), parentNode);
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

                childNode.Tag = dr["id"].ToString();
                PopulateTreeView(dr["id"].ToString(), childNode);
            }
        }

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolStripButtonEdit.Enabled = true;

            if (panel2.Enabled)
                GetSelectedNode();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            cmbxParentCode.Text = AccFactory.TaxTypesRepository().GetParentCodeByID(Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag.ToString()));
            ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            btnSave.Text = "Save";
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            ClearFields();

        }

        private void ClearFields()
        {
            txtCode.Focus();
            txtCode.Clear();
            txtDesciption.Clear();
            cmbxParentCode.Items.Clear();
            cmbxFundType.SelectedIndex = 0;
            txtCOAAccountCode.Clear();
            txtBLFGAccountCode.Clear();
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
            GetSelectedNode();
        }

        private void GetSelectedNode()
        {
            try
            {

                int selectedNode = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
                int selectedNodeParent = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);

                var dictTaxTypes = AccFactory.TaxTypesRepository().GetRecordByID(selectedNode);
                string parentCode = AccFactory.TaxTypesRepository().GetParentCodeByID(selectedNodeParent);

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

    }
}
