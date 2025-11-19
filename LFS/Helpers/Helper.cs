using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LFS.Helpers
{
    public static class Helper
    {
        internal static string updateReleaseLnk = "https://sites.google.com/view/perzeus/products/lfs";
        internal static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static Dictionary<string, string> GetSignatoryDataBy_Reference_DocumentName(string reference, string documentName)
        {
            var dictSignatoriesReferencedDocument = new Dictionary<string, string>();

            dictSignatoriesReferencedDocument = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName(reference, documentName);

            if (dictSignatoriesReferencedDocument.Count < 1)
                return dictSignatoriesReferencedDocument;

            string prefix = dictSignatoriesReferencedDocument["signatories_prefix"].ToString();
            string firstName = dictSignatoriesReferencedDocument["signatories_first_name"].ToString();
            string middleInitial = dictSignatoriesReferencedDocument["signatories_middle_initial"].ToString();
            string lastName = dictSignatoriesReferencedDocument["signatories_last_name"].ToString();
            string suffix = dictSignatoriesReferencedDocument["signatories_suffix"].ToString();

            string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

            dictSignatoriesReferencedDocument.Add("signatories_full_name", signatoryName);

            return dictSignatoriesReferencedDocument;
        }

        public static void LoadFormIcon(Form form)
        {
            form.Icon = Properties.Resources.accounting;
        }

        #region Amount to Words

        public class AmountToWords
        {
            /// <summary>
            /// Logic to convert amount to words
            /// 1. validate input
            /// 2. separate input number string to 2 parts by "."(if have): integer and decimal
            /// 3. convert to English words independently
            /// 4. combine the result
            /// </summary>
            /// <param name="strNum">the amount to be converted</param>
            /// return the converted result
            public string ConvertAmountToWords(string strNum)
            {
                if (string.IsNullOrEmpty(strNum))
                {
                    throw new ArgumentException(UtilConst.IllegalMsgEmpty);
                }
                // validate the legal input
                if (!ValidateFormat(strNum))
                {
                    throw new ArgumentException(UtilConst.IllegalMsgCommon);
                }

                // remove comma symbol from string
                strNum = strNum.Replace(",", string.Empty);

                int integerPart;
                int decimalPart;

                // separate input number string to 2 parts by "."(if have): integer and decimal
                try
                {
                    int pos = strNum.IndexOf('.');

                    if (pos == -1)
                    {
                        integerPart = int.Parse(strNum);
                        decimalPart = 0;
                    }
                    else
                    {
                        integerPart = int.Parse(strNum.Substring(0, pos));

                        string strDecimalPart = strNum.Substring(pos + 1);
                        if (strDecimalPart == "00")
                        {
                            strDecimalPart = "0";
                        }
                        if (strDecimalPart.Length == 1 && strDecimalPart[0] != '0')
                        {
                            strDecimalPart = strDecimalPart + '0';
                        }
                        decimalPart = int.Parse(strDecimalPart);
                    }
                }
                catch (OverflowException)
                {
                    throw new ArgumentException(UtilConst.IllegalMsgOutOfRange);
                }
                catch (FormatException)
                {
                    throw new ArgumentException(UtilConst.IllegalMsgCommon);
                }

                // convert integer part to English words
                string strIntegerWords = ConvertIntegerPartToWords(integerPart);
                if (strIntegerWords.Length == 0)
                {
                    strIntegerWords = "Zero";
                }

                // convert decimal part to English words
                string strDecimalWords = ConvertDecimalPartToWords(decimalPart);
                if (strDecimalWords.Length == 0)
                {
                    strDecimalWords = "Zero";
                }

                // tidy and combine the result
                return TidyAndCombineWords(strIntegerWords, strDecimalWords);
            }

            /// <summary>
            /// Logic to convert decimal part [0,99] to words
            /// recursive
            /// </summary>
            /// <param name="num">the number to be converted</param>
            /// return the convert result - string
            private string ConvertDecimalPartToWords(int num)
            {
                string result;
                if (num == 0) result = "";
                else if (num < 10) result = UtilConst.BelowTen[num];
                else if (num < 20) result = UtilConst.BelowTwenty[num - 10];
                else if (num < 100) result = UtilConst.BelowHundred[num / 10] + " " + ConvertDecimalPartToWords(num % 10);
                else throw new ArgumentException(UtilConst.IllegalMsgDecimal);

                return result.Trim();
            }

            /// <summary>
            /// Logic to convert integer part [0,2147483647] to words
            /// recursive
            /// </summary>
            /// <param name="num">the number to be converted</param>
            /// return the convert result - string
            private string ConvertIntegerPartToWords(int num)
            {
                string result;
                if (num == 0) result = "";
                else if (num < 10) result = UtilConst.BelowTen[num];
                else if (num < 20) result = UtilConst.BelowTwenty[num - 10];
                else if (num < 100) result = UtilConst.BelowHundred[num / 10] + " " + ConvertIntegerPartToWords(num % 10);
                else if (num < 1000) result = ConvertIntegerPartToWords(num / 100) + " Hundred " + ConvertIntegerPartToWords(num % 100);
                else if (num < 1000000) result = ConvertIntegerPartToWords(num / 1000) + " Thousand " + ConvertIntegerPartToWords(num % 1000);
                else if (num < 1000000000) result = ConvertIntegerPartToWords(num / 1000000) + " Million " + ConvertIntegerPartToWords(num % 1000000);
                else result = ConvertIntegerPartToWords(num / 1000000000) + " Billion " + ConvertIntegerPartToWords(num % 1000000000);

                return result.Trim();
            }

            /// <summary>
            /// tidy and combine the result string
            /// </summary>
            /// <param name="strIntegerWords">integer part words</param>
            /// <param name="strDecimalWords">decimal part words</param>
            /// return the combined result string
            private string TidyAndCombineWords(string strIntegerWords, string strDecimalWords)
            {
                if (string.IsNullOrEmpty(strIntegerWords) || string.IsNullOrEmpty(strDecimalWords))
                {
                    throw new ArgumentException(UtilConst.IllegalMsgEmpty);
                }

                string result;

                // deal with dollar&dollars, cent&cents
                string currancyDollar = " Pesos";
                if (strIntegerWords == "Zero" || strIntegerWords == "One")
                {
                    currancyDollar = " Peso";
                }

                string currancyCent = " Cents";
                if (strDecimalWords == "Zero" || strDecimalWords == "One")
                {
                    currancyCent = " Cent";
                }

                // combine the result string
                if (strDecimalWords == "Zero")
                {
                    result = strIntegerWords + currancyDollar;
                }
                else if (strIntegerWords == "Zero")
                {
                    result = strDecimalWords + currancyCent;
                }
                else
                {
                    result = strIntegerWords + currancyDollar + " and " + strDecimalWords + currancyCent;
                }

                return result.Trim();
            }

            /// <summary>
            /// Use regular expression to validate input
            /// positive number, up to 2 decimal
            /// </summary>
            /// <param name="input">the amount to be validate</param>
            /// return the validate result, true or false
            private bool ValidateFormat(string input)
            {
                Regex reg = new Regex("^[0-9,]+([.][0-9]{1,2})?$");
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                if (reg.Match(input).Success)
                {
                    return true;
                }
                return false;
            }
        }

        public class UtilConst
        {
            public const string IllegalMsgCommon = "Illegal input, please input amount like '123', '123.0', '123.00'";
            public const string IllegalMsgDecimal = "Illegal decimal";
            public const string IllegalMsgEmpty = "Input is empty";
            public const string IllegalMsgOutOfRange = "Illegal input, amount must between 0 and 2147483647.99";
            public static readonly string[] BelowHundred = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            public static readonly string[] BelowTen = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            public static readonly string[] BelowTwenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        }

        #endregion Amount to Words

        #region DataGrid Default Styles

        public static void DatagridDefaultStyle(DataGridView dgv, bool Fill = false)
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
            dgv.AutoSizeColumnsMode = Fill ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        public static void DatagridEditableRowStyle(DataGridView dgv, bool Fill = false)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8f);
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.ReadOnly = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;

            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.MinimumHeight = 30;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ShowCellToolTips = false;
            dgv.AutoSizeColumnsMode = Fill ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        public static void DatagridFullRowSelectStyle(DataGridView dgv,
                                                        bool Fill = false,
                                                        bool isReadOnly = true,
                                                        bool showRowHeader = false,
                                                        bool showColumnHeaders = true)
        {
            dgv.RowHeadersVisible = showRowHeader;
            dgv.ColumnHeadersVisible = showColumnHeaders;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ReadOnly = isReadOnly;
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

        #endregion DataGrid Default Styles

        #region Check Box Column Utility Datagrid

        public static void CheckUncheckCheckBoxHeader(DataGridView dataGridView, string checkBoxColumnName, CheckBox checkBox)
        {
            if (dataGridView.Rows.Count < 1)
                return;

            int totalRowCount = dataGridView.Rows.Count;
            int checkedRowCount = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[checkBoxColumnName].Value) == true)
                    checkedRowCount += 1;
            }

            if (totalRowCount == checkedRowCount)
                checkBox.Checked = true;
            else
                checkBox.Checked = false;
        }

        public static void CheckUncheckCheckBoxRows(DataGridView dataGridView, string checkBoxColumnName, bool isChecked)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[checkBoxColumnName].Value = isChecked;
            }
        }

        #endregion Check Box Column Utility Datagrid

        #region Miscellaneous

        public static string GetStatus(bool isApproved, bool isDisapproved, bool isCancelled)
        {
            if (isCancelled)
                return "Cancelled";
            else if (isDisapproved)
                return "Disapproved";
            else if (isApproved)
                return "Approved";
            else
                return "Pending";
        }

        public static void ProgressCounter(BackgroundWorker backgroundWorker, int totalProgressCount, int progressCount, string progressText = "")
        {
            if (totalProgressCount <= 0)
            {
                backgroundWorker.ReportProgress(0, progressText);
                return;
            }

            int progressBarPercentage = (int)((double)progressCount / totalProgressCount * 100);
            backgroundWorker.ReportProgress(progressBarPercentage, progressText);
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static string GenerateFullAddress(string address, string barangay, string municipality, string province)
        {
            string _address = string.IsNullOrEmpty(address) ? string.Empty : $"{address}, ";
            string _barangay = string.IsNullOrEmpty(barangay) ? string.Empty : $"{barangay}, ";
            string _municipality = string.IsNullOrEmpty(municipality) ? string.Empty : $"{municipality}, ";
            string _province = string.IsNullOrEmpty(province) ? string.Empty : $"{province}";

            return $"{_address}{_barangay}{_municipality}{_province}";
        }

        public static void DatagridViewRecordFinder(DataGridView dataGridView, string columnName, string value)
        {
            int visibleColumCount = 0;
            var visibleColumn = new DataGridViewColumn();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                {
                    visibleColumn = column;
                    visibleColumCount++;
                    break;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnName].Value == null && visibleColumCount == 0)
                    continue;

                string currentRowValue = row.Cells[columnName].Value.ToString();

                if (currentRowValue == value)
                {
                    dataGridView.CurrentCell = row.Cells[visibleColumn.Name];
                    row.Selected = true;
                    break;
                }
            }
        }

        public static DateTime GetCurrentDate()
        {
            return DateTime.Now;
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

        public static string AddOrdinalSuffix(int number)
        {
            if (number < 0)
                return number.ToString();

            if (number % 100 >= 11 && number % 100 <= 13)
                return number + "th";

            // Handle the general case
            switch (number % 10)
            {
                case 1: return number + "st";
                case 2: return number + "nd";
                case 3: return number + "rd";
                default: return number + "th";
            }
        }

        public static void RemoveTabcontrolTabs(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Padding = new Point(0, 0);
        }

        public static string GenerateFullName(string prefix, string firstName, string MiddleName, string LastName, string suffix)
        {
            string fullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {firstName} {(string.IsNullOrWhiteSpace(MiddleName) ? string.Empty : MiddleName.Substring(0, 1))}. {LastName} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";

            return fullName;
        }

        #endregion Miscellaneous

        #region Get User Data

        public static Dictionary<string, dynamic> GetUserDataById(int userId)
        {
            var dictUser = new Dictionary<string, dynamic>();
            try
            {
                dictUser = AccFactory.UsersRepository().GetViewRecordById(userId);

                string prefix = dictUser["prefix"];
                string suffix = dictUser["suffix"];

                string userFullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {dictUser["first_name"]} {dictUser["mid_initial"]}. {dictUser["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
                dictUser.Add("user_full_name", userFullName);

                return dictUser;
            }
            catch (Exception ex) { MessageBoxError(ex.Message); }
            return dictUser;
        }

        #endregion Get User Data

        #region ErrorProviders on Controls

        public static void ClearErrorCheckedListBox(ErrorProvider ep, CheckedListBox chklstBox)
        {
            ep.SetError(chklstBox, string.Empty);
        }

        public static void ClearErrorComboBox(ErrorProvider ep, ComboBox cmbBox)
        {
            ep.SetError(cmbBox, string.Empty);
        }

        public static void ClearErrorDatagridView(ErrorProvider ep, DataGridView dgView)
        {
            ep.SetError(dgView, string.Empty);
        }

        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, DateTimePicker dtpDateRange)
        {
            ep.SetError(dtpDateRange, string.Empty);
        }

        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }

        public static void ClearErrorNumericUpDown(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }

        public static void ClearErrorRichTextBox(ErrorProvider ep, RichTextBox richtxtBox)
        {
            ep.SetError(richtxtBox, string.Empty);
        }

        public static void ClearErrorTextBox(ErrorProvider ep, TextBox txtBox)
        {
            ep.SetError(txtBox, string.Empty);
        }

        public static void ClearMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox)
        {
            ep.SetError(maskedTextBox, string.Empty);
        }

        public static string ErrorMessage(string fieldName)
        {
            if (GetFirstLetter(fieldName) == "A")
                return $"Please enter an {fieldName}.";
            else
                return $"Please enter a {fieldName}.";
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

        public static bool ShowErrorComboBoxEmpty(ErrorProvider ep, ComboBox cmbBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(cmbBox.Text))
            {
                ep.SetError(cmbBox, $"{ErrorMessageForEmpty(fieldName)}");
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
            bool isValidDate = firstDate > secondDate;

            if (!isValidDate)
            {
                ep.SetError(dtp, $"{fieldName} is invalid.");
                return true;
            }
            return false;
        }

        public static bool ShowErrorNumericUpDownEmpty(ErrorProvider ep, NumericUpDown numUpDown, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(numUpDown.Text.ToString()))
            {
                ep.SetError(numUpDown, $"{ErrorMessageForEmpty(fieldName)}.");
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

        public static bool ShowErrorRichTextBoxEmpty(ErrorProvider ep, RichTextBox richTxtBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(richTxtBox.Text.Trim()))
            {
                ep.SetError(richTxtBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
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

        public static bool ShowMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox, string fieldName)
        {
            if (!maskedTextBox.MaskCompleted)
            {
                ep.SetError(maskedTextBox, $"{fieldName} is required");
                return true;
            }
            return false;
        }

        private static string ErrorMessageForEmpty(string fieldName)
        {
            if (GetFirstLetter(fieldName) == "A" || GetFirstLetter(fieldName) == "a")
                return $"Please enter an {fieldName.ToLower()}";
            else
                return $"Please enter a {fieldName.ToLower()}";
        }

        private static string GetFirstLetter(string word)
        {
            return word.Substring(0, 1);
        }

        #endregion ErrorProviders on Controls

        #region MessageBoxes

        // prompt a success messagebox

        public static bool MessageBoxConfirmCancel(string confirmMessage)
        {
            string message = confirmMessage;

            if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;

            return false;
        }

        public static bool MessageBoxConfirmDelete(int rowCount)
        {
            string message = string.Empty;

            if (rowCount == 1)
                message = "This action cannot be undone.\nDo you wish to delete record?";
            else if (rowCount > 1)
                message = $"This action cannot be undone.\nDo you wish to delete {rowCount} records?";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;

            return false;
        }

        // prompt an error messagebox
        public static void MessageBoxError(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageBoxSuccess(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MessageBoxWarning(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool MessageBoxConfirm(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }

        #endregion MessageBoxes

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

        public static void EnableDisableToolStripMenuItems(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
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

        #endregion EnableDisableButtons

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

        public static void ShowRecordTimestamp(DataGridView dataGridView, byte[] index, ToolStripStatusLabel lblCreatedAt, ToolStripStatusLabel lblUpdatedAt)
        {
            string placeHolder = "--";

            if (dataGridView.SelectedRows.Count == 1)
            {
                lblCreatedAt.Text = Convert.ToDateTime(dataGridView.SelectedCells[index[0]].Value).ToShortDateString();
                lblUpdatedAt.Text = string.IsNullOrWhiteSpace(dataGridView.SelectedCells[index[1]].Value.ToString()) ? placeHolder : Convert.ToDateTime(dataGridView.SelectedCells[index[1]].Value).ToShortDateString();
            }
            else
            {
                lblCreatedAt.Text = placeHolder;
                lblUpdatedAt.Text = placeHolder;
            }
        }

        public static void ShowRecordTimestampMod(DataGridView dataGridView, ToolStripLabel lblCreatedAt, ToolStripLabel lblUpdatedAt)
        {
            // Check if a row is selected
            if (dataGridView.Columns.Contains("created_at") && dataGridView.Columns.Contains("updated_at") && dataGridView.SelectedRows.Count > 0)
            {
                // Retrieve the values from the "created_at" and "updated_at" columns
                var createdAtValue = dataGridView.CurrentRow.Cells["created_at"].Value;
                var updatedAtValue = dataGridView.CurrentRow.Cells["updated_at"].Value;

                // Convert values to string (or handle null values appropriately)
                lblCreatedAt.Text = !string.IsNullOrWhiteSpace(createdAtValue.ToString()) ? Convert.ToDateTime(createdAtValue).ToShortDateString() : string.Empty;
                lblUpdatedAt.Text = !string.IsNullOrWhiteSpace(updatedAtValue.ToString()) ? Convert.ToDateTime(updatedAtValue).ToShortDateString() : string.Empty;
            }
            else
            {
                // If no row is selected, you can handle it accordingly
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
            }
        }

        public static string TruncateString(string myString, int maxLength)
        {
            return myString.Length > maxLength ? $"{myString.Substring(0, 20)}..." : $"{myString}";
        }
    }
}