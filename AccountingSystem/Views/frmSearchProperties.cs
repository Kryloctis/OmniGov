using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views
{
    public partial class frmSearchProperties : Form
    {

        public frmSearchProperties()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgSearchProperties, true);
            Helper.LoadFormIcon(this);
        }

        internal void LoadPropertiesRecords()
        {
            DataTable dtProperty;
            string searchText = txtSearch.Text.Trim();

            if (txtSearch.TextLength < 2)
            {
                var datagridViewDataSource = (DataTable)dgSearchProperties.DataSource;
                if (datagridViewDataSource != null) datagridViewDataSource.Rows.Clear();
                return;
            }

            if (radBtnLand.Checked)
                dtProperty = Factory.RealPropertiesRepository().GetViewPropertiesByPropertyKindAndSearch("L", searchText);
            else if (radBtnBuilding.Checked)
                dtProperty = Factory.RealPropertiesRepository().GetViewPropertiesByPropertyKindAndSearch("B", searchText);
            else
                dtProperty = Factory.RealPropertiesRepository().GetViewPropertiesByPropertyKindAndSearch("M", searchText);

            HelperLoadRecords.PropertiesDatagridView(dtProperty, dgSearchProperties);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPropertiesRecords();
        }

        private void radBtnLand_CheckedChanged(object sender, EventArgs e)
        {
            LoadPropertiesRecords();
        }

        private void radBtnBuilding_CheckedChanged(object sender, EventArgs e)
        {
            LoadPropertiesRecords();
        }

        private void radBtnMachinery_CheckedChanged(object sender, EventArgs e)
        {
            LoadPropertiesRecords();
        }
    }
}
