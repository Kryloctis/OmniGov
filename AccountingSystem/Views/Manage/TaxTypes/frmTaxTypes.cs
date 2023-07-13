using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxTypes
{
    public partial class frmTaxTypes : Form
    {
        int childImageIndexCounter = 1;

        public frmTaxTypes()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void ClearFields()
        {
            txtCode.Focus();
            txtCode.Clear();
            txtDesciption.Clear();
            cmbxParent.Text = string.Empty;
            cmbxFundType.Text = string.Empty;
            cmbxFundType.SelectedIndex = -1;
            txtCOAAccountCode.Clear();
            txtBLFGAccountCode.Clear();
            LoadParentCode();
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
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDesciption),
                errorProvider1.GetError(txtCode)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private bool SaveTaxType()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            string code = txtCode.Text;
            string desciption = txtDesciption.Text;
            object parent = (cmbxParent.SelectedIndex == -1) ? null : cmbxParent.SelectedValue;
            object fundID = (cmbxFundType.SelectedIndex == -1) ? null : cmbxFundType.SelectedValue;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveTaxType())
                {
                    Helper.MessageBoxSuccess("Tax type has been saved.");
                    LoadTaxTypes();
                    ResetForm();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool UpdateTaxTypes()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
            string code = txtCode.Text;
            string desciption = txtDesciption.Text;
            object parent = (cmbxParent.SelectedIndex == -1) ? null : cmbxParent.SelectedValue;
            object fundID = (cmbxFundType.SelectedIndex == -1) ? null : cmbxFundType.SelectedValue;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateTaxTypes())
                {
                    Helper.MessageBoxSuccess("Tax type has been updated.");
                    LoadTaxTypes();
                    ResetForm();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

        private void PopulateTreeView(int parentID, TreeNode parentNode)
        {
            var dtChildNodeTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(Convert.ToInt32(parentID));

            ImageList nodeImageList = new();
            CreateImageList(ref nodeImageList);

            foreach (DataRow dr in dtChildNodeTaxTypes.Rows)
            {
                string taxTypeCode = dr["code"].ToString();
                string taxTypeDescription = dr["description"].ToString();
                string displayText = $"({taxTypeCode}) {taxTypeDescription}";

                TreeNode childNode = new();

                if (parentNode == null)
                {
                    childNode = treeViewTaxTypes.Nodes.Add(displayText);
                    childNode.ImageIndex = 0;
                    childNode.SelectedImageIndex = 0;
                }

                else
                {
                    childNode = parentNode.Nodes.Add(displayText);
                    childNode.ImageIndex = childImageIndexCounter;
                    childNode.SelectedImageIndex = childImageIndexCounter;

                    if (childImageIndexCounter >= nodeImageList.Images.Count)
                        childImageIndexCounter = 1;
                    else
                        childImageIndexCounter++;
                }

                int taxTypeID = Convert.ToInt32(dr["id"]);
                childNode.Tag = taxTypeID;
                PopulateTreeView(taxTypeID, childNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    childNode.ForeColor = Color.Gray;

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
                ShowSelectedTaxTypeDetails();

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtCode.Focus();
            panel2.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            btnSave.Text = "Save";

            if (AccFactory.TaxTypesRepository().CountRecords() != 0)
            {
                int taxTypeParentCodeID = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);
                cmbxParent.Text = AccFactory.TaxTypesRepository().GetParentCodeByID(taxTypeParentCodeID);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            ClearFields();
        }

        internal void LoadFunds()
        {
            try
            {
                var dtFunds = AccFactory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFundType, "fund_name", "id");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadTaxTypes()
        {
            treeViewTaxTypes.Nodes.Clear();
            childImageIndexCounter = 1;

            var dtTaxTypes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();

            TreeNode parentNode;

            foreach (DataRow dr in dtTaxTypes.Rows)
            {
                int taxTypeID = Convert.ToInt32(dr["id"]);
                string taxTypeCode = dr["code"].ToString();
                string taxTypeDescription = dr["description"].ToString();
                string displayText = $"({taxTypeCode}) {taxTypeDescription}";

                parentNode = treeViewTaxTypes.Nodes.Add(displayText);
                parentNode.Tag = taxTypeID;

                PopulateTreeView(taxTypeID, parentNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    parentNode.ForeColor = Color.Gray;
            }
        }

        private void LoadParentCode()
        {
            DataTable dtTaxTypesCodes = AccFactory.TaxTypesRepository().GetTaxTypeCodes();
            Dictionary<int, string> dtSource = new Dictionary<int, string>();

            foreach (DataRow row in dtTaxTypesCodes.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string code = row["code"].ToString();
                string parent = row["parent"].ToString();

                if (!string.IsNullOrEmpty(parent))
                    dtSource.Add(id, code);
                else
                    dtSource.Add(id, code);
            }

            cmbxParent.DataSource = new BindingSource(dtSource, null); ;
            cmbxParent.ValueMember = "Key";
            cmbxParent.DisplayMember = "Value";
            cmbxParent.SelectedIndex = -1;
        }

        private void frmTaxTypes_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFunds();
                LoadTaxTypes();
                LoadParentCode();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ShowSelectedTaxTypeDetails()
        {
            try
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);
                int taxTypeParentCodeID = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);

                var dictTaxTypes = AccFactory.TaxTypesRepository().GetRecordByID(taxTypeID);
                string parentCode = AccFactory.TaxTypesRepository().GetParentCodeByID(taxTypeParentCodeID);

                txtCode.Text = dictTaxTypes["code"];
                txtDesciption.Text = dictTaxTypes["description"];
                cmbxParent.Text = parentCode;
                cmbxFundType.SelectedValue = string.IsNullOrEmpty(dictTaxTypes["funds_id"]) ? 0 : Convert.ToInt32(dictTaxTypes["funds_id"]);
                txtCOAAccountCode.Text = dictTaxTypes["coa_account_code"];
                txtBLFGAccountCode.Text = dictTaxTypes["blgf_account_code"];
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            txtCode.Focus();
            panel2.Enabled = true;
            btnCancel.Enabled = true;
            toolStrip2.Enabled = false;
            btnUpdate.Visible = true;
            btnSave.Visible = false;

            ShowSelectedTaxTypeDetails();
        }

        private void treeViewTaxTypes_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
                e.Cancel = true;
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

        private bool UnDeleteTaxType()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to undelete selected tax type?"))
            {
                int taxTypeID = Convert.ToInt32(treeViewTaxTypes.SelectedNode.Tag);

                return AccFactory.TaxTypesRepository().UnDeleteTaxType(taxTypeID);
            }

            return false;
        }

        private void toolStripButtonUndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UnDeleteTaxType())
                {
                    Helper.MessageBoxSuccess("Tax type has been undeleted.");
                    LoadTaxTypes();
                    treeViewTaxTypes.Refresh();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        #region Validations
        private void txtDesciption_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDesciption, "Description.");
        }

        private void txtDesciption_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDesciption);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Code.");
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }
        #endregion
    }
}
