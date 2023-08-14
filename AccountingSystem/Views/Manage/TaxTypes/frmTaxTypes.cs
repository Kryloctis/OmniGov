using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
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
        private int childImageIndexCounter = 1;
        private int tabCount = 10;

        public frmTaxTypes()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void ClearFields()
        {
            txtCode.Clear();
            txtCode.Focus();
            txtDesciption.Clear();
            cmbxFundType.SelectedIndex = -1;
            txtCOAAccountCode.Clear();
            txtBLFGAccountCode.Clear();
            cmbxParent.Text = string.Empty;
            cmbxFundType.Text = string.Empty;

            LoadParentCode();
        }

        private void ResetForm()
        {
            panel2.Enabled = false;
            toolStrip2.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Visible = true;
            btnSave.Enabled = false;
            btnUpdate.Visible = false;
            btnUndelete.Visible = false;
            toolStripSeparator1.Visible = false;
            ClearFields();
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

            string code = txtCode.Text.Trim();
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
            nodeImageList.Images.Add("0", Properties.Resources.heirarchy1_20px);
            nodeImageList.Images.Add("1", Properties.Resources.heirarchy2_20px);
            nodeImageList.Images.Add("2", Properties.Resources.heirarchy3_20px);
            nodeImageList.Images.Add("3", Properties.Resources.heirarchy4_20px);
            nodeImageList.Images.Add("4", Properties.Resources.heirarchy4_20px);

            treeViewTaxTypes.ImageList = nodeImageList;
            treeViewTaxTypes.ImageIndex = 0;
            treeViewTaxTypes.SelectedImageIndex = 0;
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

        private void treeViewTaxTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool isDeleted = treeViewTaxTypes.SelectedNode.ForeColor != Color.Gray;
            if (isDeleted)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                toolStripSeparator1.Visible = false;
                btnUndelete.Visible = false;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                toolStripSeparator1.Visible = true;
                btnUndelete.Visible = true;
            }

            if (panel2.Enabled)
                ShowSelectedTaxTypeDetails();
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

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            panel2.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            int recordCount = AccFactory.TaxTypesRepository().CountRecords();
            if (recordCount != 0)
            {
                int taxTypeParentCodeID = treeViewTaxTypes.SelectedNode.Parent == null ? 0 : Convert.ToInt32(treeViewTaxTypes.SelectedNode.Parent.Tag);
                cmbxParent.Text = AccFactory.TaxTypesRepository().GetParentCodeByID(taxTypeParentCodeID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => ResetForm();

        internal void LoadFunds()
        {
            try
            {
                var dtFunds = AccFactory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFundType, "fund_name", "id");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                TreeNode childNode = new();

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

                LoadChildNodes(taxTypeID, parentNode);

                if (Convert.ToBoolean(dr["is_deleted"]))
                    parentNode.ForeColor = Color.Gray;
            }
        }

        private void LoadChildCode(int parent, ref Dictionary<int, string> dtSource)
        {
            DataTable dtChildTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(parent);

            if (dtChildTaxTypes.Rows.Count == 0)
            {
                tabCount = 10;
                return;
            }

            foreach (DataRow row in dtChildTaxTypes.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string code = row["code"].ToString();
                string description = row["description"].ToString();
                string cmbDisplay = $"{new string(' ', tabCount)}{code} - {description}";
                dtSource.Add(id, cmbDisplay);
                tabCount += 10;
                LoadChildCode(id, ref dtSource);
            }
        }

        private void LoadParentCode()
        {
            DataTable dtTaxTypesCodes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();
            Dictionary<int, string> dtSource = new Dictionary<int, string>();
            foreach (DataRow row in dtTaxTypesCodes.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string code = row["code"].ToString();
                string parent = row["parent"].ToString();
                string description = row["description"].ToString();
                string cmbDisplay = $"{code} - {description}";
                dtSource.Add(id, cmbDisplay);
                LoadChildCode(id, ref dtSource);
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

        private void treeViewTaxTypes_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
                e.Cancel = true;
        }

        private bool DeleteTaxType()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to delete selected tax type?"))
            {
                //taxtypeID = 18;
                object selectedNodeTag = treeViewTaxTypes.SelectedNode.Tag;
                int taxTypeID = Convert.ToInt32(selectedNodeTag);

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
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete tax type. Tax type is used as reference to another record.");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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
                    ResetForm();
                    LoadTaxTypes();
                    treeViewTaxTypes.Refresh();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => cmbxParent.Text = cmbxParent.SelectedText.Trim()));
        }

        private void cmbxParent_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics graphics = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (object text in ((ComboBox)sender).Items)
            {
                newWidth = (int)graphics.MeasureString(text.ToString(), font).Width + vertScrollBarWidth;
                if (width < newWidth)
                    width = newWidth;
            }
            senderComboBox.DropDownWidth = width;
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

        #endregion Validations
    }
}