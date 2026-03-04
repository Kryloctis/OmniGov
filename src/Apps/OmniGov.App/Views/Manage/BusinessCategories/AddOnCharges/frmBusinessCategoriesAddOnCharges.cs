using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.App.Views.Manage.BusinessCategories.AddOnCharges
{
    public partial class frmBusinessCategoriesAddOnCharges : Form
    {
        private readonly frmBusinessCategories _frmBusinessCategories;
        private readonly int _businessCategoriesId;

        public frmBusinessCategoriesAddOnCharges(int businessCategoriesId, frmBusinessCategories frmBusinessCategories)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBusinessCategories = frmBusinessCategories;
            _businessCategoriesId = businessCategoriesId;
            Helper.DatagridFullRowSelectStyle(dataGridView1, true, false);
        }

        private DataColumn[] DataColumnsAddOnCharges()
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("id", typeof(int)),
                new DataColumn("code", typeof(string)),
                new DataColumn("description", typeof(string))
            };
        }

        private DataTable DataTableAddOnCharges()
        {
            var dtAddOnCharges = TreasuryFactory.BusinessAddOnChargesRepository().GetRecords();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(DataColumnsAddOnCharges());

            foreach (DataRow item in dtAddOnCharges.Rows)
            {
                var newRow = dt.NewRow();
                int businessAddOnChargesId = Convert.ToInt32(item["id"]);
                newRow["is_selected"] = TreasuryFactory.BusinessCategoriesHasAddOnCharges().BusinessCategoriesHasAddOnCharges(_businessCategoriesId, businessAddOnChargesId);
                newRow["id"] = businessAddOnChargesId;
                newRow["code"] = item["code"];
                newRow["description"] = item["description"];
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        internal void LoadRecords()
        {
            HelperLoadRecords.BusinessCategorissAddOnsDatagridView(dataGridView1, DataTableAddOnCharges());
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
        }

        private void OnLoad()
        {
            LoadRecords();
        }

        private void frmBusinessCategoriesAddOnCharges_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_selected")
                e.Column.ReadOnly = true;
        }

        private bool Save()
        {
            var modeList = new List<BusinessCategoriesHasAddOnChargesModel>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["is_selected"].Value))
                    continue;

                var model = new BusinessCategoriesHasAddOnChargesModel()
                {
                    businessCategoriesId = _businessCategoriesId,
                    businessAddOnChargesId = Convert.ToInt32(row.Cells["id"].Value)
                };

                modeList.Add(model);
            }
            return TreasuryFactory.BusinessCategoriesHasAddOnCharges().Insert(_businessCategoriesId, modeList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Business Categories Add-on Charges has been saved.");
                _frmBusinessCategories.LoadBusinessCategories();
                Helper.DatagridViewRecordFinder(_frmBusinessCategories.dgBusinessCategories, "id", _businessCategoriesId.ToString());
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_selected", checkBox1);
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Helper.CheckUncheckCheckBoxRows(dataGridView1, "is_selected", checkBox1.Checked);
        }
    }
}