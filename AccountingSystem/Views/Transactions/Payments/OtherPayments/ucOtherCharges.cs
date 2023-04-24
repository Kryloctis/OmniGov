using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments
{
    public partial class ucOtherCharges : UserControl
    {

        int childImageIndexCounter = 1;
        internal decimal totalAmount = 124210;

        public ucOtherCharges()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgOtherPaymentCharges);
        }

        #region OtherPaymentCharges
        private void LoadOtherPaymentCharges()
        {
            treeViewTaxTypes.Nodes.Clear();
            childImageIndexCounter = 1;

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


            ImageList nodeImageList = new ImageList();
            CreateImageList(ref nodeImageList);

            foreach (DataRow dr in dtChildNoTaxTypes.Rows)
            {
                TreeNode childNode = new();

                if (parentNode == null)
                {
                    childNode = treeViewTaxTypes.Nodes.Add(dr["description"].ToString());
                    childNode.ImageIndex = 0;
                    childNode.SelectedImageIndex = 0;
                }

                else
                {
                    childNode = parentNode.Nodes.Add(dr["description"].ToString());
                    childNode.ImageIndex = childImageIndexCounter;
                    childNode.SelectedImageIndex = childImageIndexCounter;

                    if (childImageIndexCounter >= nodeImageList.Images.Count)
                        childImageIndexCounter = 1;
                    else
                        childImageIndexCounter++;
                }


                string taxTypeID = dr["id"].ToString();
                childNode.Tag = taxTypeID;
                PopulateTreeView(taxTypeID, childNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    childNode.ForeColor = Color.Gray;

            }
        }

        private void CreateImageList(ref ImageList nodeImageList)
        {
            nodeImageList.Images.Add("0", Properties.Resources.tree_view_tax_18);
            nodeImageList.Images.Add("1", Properties.Resources.tree_view_accounting_18);
            nodeImageList.Images.Add("2", Properties.Resources.tree_view_estimates_18);
            nodeImageList.Images.Add("3", Properties.Resources.tree_view_receipt_dollar_18);
            nodeImageList.Images.Add("4", Properties.Resources.tree_view_bill_18);

            treeViewTaxTypes.ImageList = nodeImageList;
            treeViewTaxTypes.ImageIndex = 0;
            treeViewTaxTypes.SelectedImageIndex = 0;

        }
        #endregion

        private void ucOtherCharges_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadOtherPaymentCharges();

            }
        }

        internal DataTable OthersChargesDataTable()
        {

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(OtherPaymentChargesColumns());
            var newRow = dataTable.NewRow();

            newRow["description"] = "asd";
            newRow["debit_amount"] = 2141;
            newRow["accountable_form_type"] = "zxczx";
            newRow["unit"] = 1;
            newRow["total_amount"] = 21451;

            dataTable.Rows.Add(newRow);
            return dataTable;
        }

        private DataColumn[] OtherPaymentChargesColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("description", typeof(string)),
                new DataColumn("debit_amount", typeof(decimal)),
                new DataColumn("accountable_form_type", typeof(string)),
                new DataColumn("unit", typeof(int)),
                new DataColumn("total_amount", typeof(decimal)),
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HelperLoadRecords.OtherPaymentChargesDatagridView(dgOtherPaymentCharges, OthersChargesDataTable());
        }

    }
}
