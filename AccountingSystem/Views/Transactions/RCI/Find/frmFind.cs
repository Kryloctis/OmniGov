using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI.Find
{
    public partial class frmFind : Form
    {
        internal int Id = 0;
        internal string selectedValue = string.Empty;
        internal string table = string.Empty;
        private ucRCI frmrci;
        public frmFind(ucRCI rci,string find)
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgSelect);
            dgSelect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table = find;
            frmrci = rci;
            this.Text = String.Format("Find > {0}", table.ToUpper());
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            //LoadList();
        }

        private void LoadList()
        {
            try
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("banks"))
                    {
                        var banksRepository = Factory.BanksRepository();
                        var dtBanks = banksRepository.GetRecords();
                        HelperLoadRecords.BanksDatagridView(dtBanks, dgSelect);
                    }
                    if (table.Equals("funds"))
                    {
                        var fundsRepository = Factory.FundsRepository();
                        var dtFunds = fundsRepository.GetRecords();
                        HelperLoadRecords.FundsDatagridView(dtFunds, dgSelect);
                    }
                    if (table.Equals("functions"))
                    {
                        var functionRepository = Factory.FunctionProgramProjectRepository();
                        var dtFunctions = functionRepository.GetRecords();
                        HelperLoadRecords.FunctionProjectProgramDatagridView(dtFunctions, dgSelect);
                    }

                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Save()
        {
            bool saved = false;
       
            if (table.Equals("functions"))
            {
                frmrci.loadSelectedFunction(Id, selectedValue);
                saved = true;
            
            }
            
            return saved;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length >= 3)
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("banks"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtSearch.Text.Trim());
                            var dtBanks = Factory.BanksRepository().GetRecordsBySearch(searchkey);
                            HelperLoadRecords.BanksDatagridView(dtBanks, dgSelect);

                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }
                    if (table.Equals("funds"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtSearch.Text.Trim());
                            var dtFunds = Factory.FundsRepository().GetRecordsBySearch(searchkey);
                            HelperLoadRecords.FundsDatagridView(dtFunds, dgSelect);

                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }
                    if (table.Equals("functions"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtSearch.Text.Trim());
                            var dtFunctions = Factory.FunctionProgramProjectRepository().GetRecordsBySearch(searchkey);
                            HelperLoadRecords.FunctionProjectProgramDatagridView(dtFunctions, dgSelect);

                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }

                }
            }
            else
            {
                LoadList();
            }
        }

        private void dgSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (dgSelect.Rows.Count > 0 && dgSelect.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgSelect.SelectedRows)
                {
                    Id = Convert.ToInt16(row.Cells[0].Value.ToString());
                    selectedValue = String.Format("{0} - {1}", row.Cells[1].Value, row.Cells[2].Value);
                }
            }
        }

        private void dgSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Save())
                {
                    this.Close();
                }
                
            }
        }
    }
}
