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
        }

        private void LoadTaxTypes()
        {
            var dtTaxTypes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();
 
            TreeNode parentNode;

            foreach (DataRow dr in dtTaxTypes.Rows)
            {
                parentNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());
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


                PopulateTreeView(dr["id"].ToString(), childNode);
            }
        }

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtDesciption.Text = treeViewTaxTypes.SelectedNode.Text;
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
        }

        private void frmTaxTypes_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadTaxTypes();
            LoadParentCode();
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

    }
}
