using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class frmRptDelinquencyNotices : Form
    {
        private bool isEdit;
        private ucDelinquenyNotice ucDelinquenyNotice;

        public frmRptDelinquencyNotices()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);

            //Removes tabs to tabcontrol
            tabControl1.Padding = new Point(0, 0);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            ucDelinquenyNotice = ucDelinquenyNotice1;
        }

        private void frnRptAssessment_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageForm":
                    ucDelinquenyNotice.OnLoad();
                    break;

                default:
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = false;
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Save (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = true;
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Update (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageMain;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControl1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal bool SaveData()
        {
            if (!ucDelinquenyNotice.ValidateChildren())
            {
                Helper.MessageBoxError(ucDelinquenyNotice.GetFormErrors());
                return false;
            }

            return true;
        }

        internal bool UpdateData()
        {
            if (!ucDelinquenyNotice.ValidateChildren())
            {
                Helper.MessageBoxError(ucDelinquenyNotice.GetFormErrors());
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Delinquency notice has been updated.");
                        ucDelinquenyNotice.ResetForm();
                        tabControl1.SelectedTab = tabPageMain;
                    }
                }
                else
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Delinquency notice has been saved.");
                        ucDelinquenyNotice.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}