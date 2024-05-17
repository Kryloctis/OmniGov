using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystem.Views.Transactions.Assessment;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class frmDelinquencyNotice : Form
    {
        public frmDelinquencyNotice()
        {
            InitializeComponent();

            //Removes tabs to tabcontrol
            tabControlMain.Padding = new Point(0, 0);
            tabControlMain.ItemSize = new Size(0, 1);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void ToggleIndicator(TabControl tabControl)
        {
            //switch (tabControl.SelectedTab.Name)
            //{
            //    case "tabPageDelinquencyNoticeList":
            //        lblIndicator.Text = "⌂ > Delinquent Notice";
            //        break;

            //    case "tabPageDelinquentNoticeForm":
            //        lblIndicator.Text = "⌂ > Delinquent Notice";
            //        break;

            //    case "tabPageWarrantLevy":
            //        lblIndicator.Text = "⌂ > Warrant of Levy";
            //        break;

            //    case "tabPageWarrantLevyForm":
            //        lblIndicator.Text = "⌂ > Warrant of Levy";
            //        break;

            //    default:
            //        lblIndicator.Text = "⌂";
            //        break;
            //}
        }

        private void frmDelinquencyCenter_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
