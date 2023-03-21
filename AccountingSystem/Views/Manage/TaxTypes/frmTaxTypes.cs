using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cmbxParentCode.Text = treeViewTaxTypes.SelectedNode.Text;
        }
    }
}
