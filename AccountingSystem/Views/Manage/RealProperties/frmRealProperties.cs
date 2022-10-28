using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        internal void LoadProperties()
        {
            try
            {
                string searchValue = txtSearch.Text.Trim();
                var dtRealProperties = new DataTable();

                if (searchValue.Length < 2)
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetRecords();
                else
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetRecordsBySearch(searchValue);

                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, dtRealProperties);
                dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void dgRealProperties_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRealProperties, btnEdit, btnDelete);
        }
    }
}
