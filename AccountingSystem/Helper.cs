using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public class Helper
    {
        internal static byte UserId = Factory.UserId;

        public static void LoadFormIcon(Form form)
        {
            form.Icon = Properties.Resources.accounting;
        }

        #region DataGrid Default Styles

        public static void DatagridDefaultStyle(DataGridView dgv, Boolean Fill = false)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dgv.ColumnHeadersHeight = 30;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (Fill == true) dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void DatagridFullRowSelectStyle(DataGridView dgv, Boolean Fill = false)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowTemplate.Height = 20;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (Fill == true) dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void DatagridEditableRowStyle(DataGridView dgv, Boolean Fill = false)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.ReadOnly = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowTemplate.Height = 20;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowTemplate.Height = 20;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            if (Fill == true) dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion

        public static Dictionary<string, string> LGUDetails()
        {
            var lguDict = new Dictionary<string, string>
            {
                { "lgu_name", "Municipality of Buug" }
            };

            return lguDict;
        }

        public static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Approved":
                    return Color.FromArgb(201, 228, 197);

                case "Disapproved":
                    return Color.FromArgb(246, 169, 169);


                case "Cancelled":
                    return Color.FromArgb(200, 198, 198);

                case "Pending":
                    return Color.FromArgb(255, 230, 153);

                default:
                    return Color.Black;
            }
        }

        public static Dictionary<string, string> GetSignatoryDataBy_Reference_DocumentName(string reference, string documentName)
        {
            var dictSignatoriesReferencedDocument = new Dictionary<string, string>();

            try
            {
                dictSignatoriesReferencedDocument = Factory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName(reference, documentName);

                string prefix = dictSignatoriesReferencedDocument["signatories_prefix"].ToString();
                string firstName = dictSignatoriesReferencedDocument["signatories_first_name"].ToString();
                string middleInitial = dictSignatoriesReferencedDocument["signatories_middle_initial"].ToString();
                string lastName = dictSignatoriesReferencedDocument["signatories_last_name"].ToString();
                string suffix = dictSignatoriesReferencedDocument["signatories_suffix"].ToString();

                string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";



                dictSignatoriesReferencedDocument.Add("signatories_full_name", signatoryName);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return dictSignatoriesReferencedDocument;
        }

        public static Dictionary<string, dynamic> GetUserDataById(int userId)
        {
            var dictUser = new Dictionary<string, dynamic>();
            try
            {
                dictUser = Factory.UsersRepository().GetViewRecordById(userId);

                string prefix = dictUser["prefix"];
                string suffix = dictUser["suffix"];

                string userFullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {dictUser["first_name"]} {dictUser["mid_initial"]}. {dictUser["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
                dictUser.Add("user_full_name", userFullName);

                return dictUser;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return dictUser;
        }

        internal static Dictionary<string, dynamic> LoggedInUserData()
        {
            var dictUser = new Dictionary<string, dynamic>();
            try
            {

                dictUser = Factory.UsersRepository().GetViewRecordById(UserId);
                string prefix = dictUser["prefix"];
                string suffix = dictUser["suffix"];


                string userFullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {dictUser["first_name"]} {dictUser["mid_initial"]}. {dictUser["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
                dictUser.Add("user_full_name", userFullName);

                return dictUser;

            }
            catch (Exception ex)
            {
                MessageBoxError(ex.Message);
            }

            return dictUser;
        }


        #region ErrorProviders on Controls

        private static string GetFirstLetter(string word)
        {
            return word.Substring(0, 1);
        }

        private static string ErrorMessageForEmpty(string fieldName)
        {

            if (GetFirstLetter(fieldName) == "A" || GetFirstLetter(fieldName) == "a")
                return $"Please enter an {fieldName.ToLower()}";
            else
                return $"Please enter a {fieldName.ToLower()}";
        }

        public static string ErrorMessage(string fieldName)
        {
            if (GetFirstLetter(fieldName) == "A")
                return $"Please enter an {fieldName}.";
            else
                return $"Please enter a {fieldName}.";
        }

        public static bool ShowErrorTextBoxEmpty(ErrorProvider ep, TextBox txtBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text.Trim()))
            {
                ep.SetError(txtBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;

            }

            return false;
        }

        public static bool ShowErrorRichTextBoxEmpty(ErrorProvider ep, RichTextBox richTxtBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(richTxtBox.Text.Trim()))
            {
                ep.SetError(richTxtBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorComboBoxEmpty(ErrorProvider ep, ComboBox cmbBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(cmbBox.Text))
            {
                ep.SetError(cmbBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorNumericUpDownEmpty(ErrorProvider ep, NumericUpDown numUpDown, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(numUpDown.Text.ToString()))
            {
                ep.SetError(numUpDown, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorNumericUpDownZero(ErrorProvider ep, NumericUpDown numericUpDown, string fieldName = "Field")
        {
            if (numericUpDown.Value == 0)
            {
                ep.SetError(numericUpDown, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorCheckedListBox(ErrorProvider ep, CheckedListBox chklstBox, string fieldName = "Field")
        {
            if (chklstBox.CheckedIndices.Count == 0)
            {
                ep.SetError(chklstBox, $"{fieldName} is required");
                return true;
            }

            return false;
        }

        public static bool ShowErrorDatagridView(ErrorProvider ep, DataGridView dgView, string fieldName = "Field")
        {
            if (dgView.Rows.Count == 0)
            {
                ep.SetError(dgView, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorDateTimePickerRange(ErrorProvider ep, DateTime firstDate, DateTime secondDate, DateTimePicker dtp, string fieldName = "Field")
        {
            //bool isValidDate = Convert.ToBoolean(DateTime.Compare(firstDate, secondDate));
            bool isValidDate = firstDate <= secondDate;

            if (isValidDate)
            {
                ep.SetError(dtp, $"{fieldName} is invalid");
                return true;
            }

            return false;
        }
        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, DateTimePicker dtpDateRange)
        {
            ep.SetError(dtpDateRange, string.Empty);
        }

        public static void ClearErrorNumericUpDown(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }


        public static bool ShowMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox, string fieldName)
        {
            if (!maskedTextBox.MaskCompleted)
            {
                ep.SetError(maskedTextBox, $"{fieldName} is required");
                return true;
            }
            return false;
        }

        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }

        public static void ClearErrorComboBox(ErrorProvider ep, ComboBox cmbBox)
        {
            ep.SetError(cmbBox, string.Empty);
        }

        public static void ClearErrorTextBox(ErrorProvider ep, TextBox txtBox)
        {
            ep.SetError(txtBox, string.Empty);
        }

        public static void ClearErrorRichTextBox(ErrorProvider ep, RichTextBox richtxtBox)
        {
            ep.SetError(richtxtBox, string.Empty);
        }

        public static void ClearErrorCheckedListBox(ErrorProvider ep, CheckedListBox chklstBox)
        {
            ep.SetError(chklstBox, string.Empty);
        }

        public static void ClearErrorDatagridView(ErrorProvider ep, DataGridView dgView)
        {
            ep.SetError(dgView, string.Empty);
        }

        public static void ClearMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox)
        {
            ep.SetError(maskedTextBox, string.Empty);
        }


        #endregion

        #region MessageBoxes
        // prompt a success messagebox

        public static void MessageBoxWarning(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MessageBoxSuccess(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // prompt an error messagebox
        public static void MessageBoxError(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool MessageBoxConfirmDelete(int rowCount)
        {
            string message = string.Empty;

            if (rowCount == 1)
                message = "Are you sure you want to delete a record?";
            else if (rowCount > 1)
                message = $"Are you sure you want to delete {rowCount} records?";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;

            return false;
        }

        public static bool MessageBoxConfirmCancel(string confirmMessage)
        {
            string message = confirmMessage;

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;

            return false;
        }


        #endregion

        #region HideEditDeleteButtons

        #endregion

        #region EnableDisableButtons
        public static void EnableDisableButtons(DataGridView dgv, Button btnEdit, Button btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
            }
        }

        public static void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
                tsBtnDelete.Text = "Delete";
            }
        }

        #endregion

        public static void ShowRecordTimestamp(DataGridView dataGridView, byte[] index, ToolStripStatusLabel lblCreatedAt, ToolStripStatusLabel lblUpdatedAt)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                lblCreatedAt.Text = dataGridView.SelectedCells[index[0]].Value.ToString();
                lblUpdatedAt.Text = dataGridView.SelectedCells[index[1]].Value.ToString();
            }
            else
            {
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
            }
        }

        public static void ShowRecordTimestamp(DataGridView dataGridView, byte[] index, ToolStripStatusLabel lblCreatedAt, ToolStripStatusLabel lblUpdatedAt, ToolStripStatusLabel lblCreatedBy, ToolStripStatusLabel lblUpdatedBy)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                lblCreatedAt.Text = dataGridView.SelectedCells[index[0]].Value.ToString();
                lblUpdatedAt.Text = dataGridView.SelectedCells[index[1]].Value.ToString();
                lblCreatedBy.Text = dataGridView.SelectedCells[index[2]].Value.ToString();
                lblUpdatedBy.Text = dataGridView.SelectedCells[index[3]].Value.ToString();
            }
            else
            {
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
                lblCreatedBy.Text = string.Empty;
                lblUpdatedBy.Text = string.Empty;
            }
        }

        public static string TruncateString(string myString, int maxLength)
        {
            return myString.Length > maxLength ? $"{myString.Substring(0, 20)}..." : $"{myString}";
        }

        public static Dictionary<int, string> MonthsDatasource()
        {
            var month = new Dictionary<int, string>();
            month.Add(1, "January");
            month.Add(2, "February");
            month.Add(3, "March");
            month.Add(4, "April");
            month.Add(5, "May");
            month.Add(6, "June");
            month.Add(7, "July");
            month.Add(8, "August");
            month.Add(9, "September");
            month.Add(10, "October");
            month.Add(11, "November");
            month.Add(12, "December");

            return month;
        }

        public static bool HasPermission(string permissionName)
        {
            try
            {
                return Factory.UsersRepository().HasPermission(UserId, permissionName);
            }
            catch (Exception ex)
            {
                MessageBoxError(ex.Message);
            }

            return false;
        }

        public static string FormatReceiptNumber(string receiptNumber)
        {
            if (string.IsNullOrEmpty(receiptNumber) == false)
                return receiptNumber.PadLeft(8, '0');

            return string.Empty;
        }

        public static void DatagridViewRecordFinder(DataGridView dataGridView, string columnName, string value)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // 0 is the column index
                if (row.Cells[columnName].Value.ToString().Equals(value))
                {
                    dataGridView.CurrentCell = row.Cells[columnName];
                    break;
                }
            }
        }

        public static bool IsJobOrder(int userId)
        {
            try
            {
                var jobOrderRepo = Factory.JobOrderRepository();
                return jobOrderRepo.IsUserJobOrder(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
