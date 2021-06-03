using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits.Find
{
    public partial class frmFind : Form
    {
        internal int Id = 0;
        internal string selectedValue = string.Empty;
        internal string table = string.Empty;
        private ucBD frmbd;
        public frmFind(ucBD bd, string find)
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgSelect);
            dgSelect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table = find;
            frmbd = bd;
            this.Text = String.Format("Find > {0}", table.ToUpper());
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("banks"))
                    {
                        var bankRepository = Factory.BanksRepository();
                        var dtBank = bankRepository.GetRecords();
                        HelperLoadRecords.BanksDatagridView(dtBank, dgSelect);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 3)
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("banks"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtsearch.Text.Trim());
                            var dtBank = Factory.BanksRepository().GetRecordsBySearch(searchkey);
                            HelperLoadRecords.BanksDatagridView(dtBank, dgSelect);

                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }
                }
            }
        }

        private void dgSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (dgSelect.Rows.Count > 0 && dgSelect.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgSelect.SelectedRows)
                {
                    if (table.Equals("banks"))
                    {
                        Id = Convert.ToInt16(row.Cells[0].Value.ToString());
                        selectedValue = String.Format("{0} - {1}", row.Cells[1].Value, row.Cells[2].Value);
                    }
                }
            }
        }
        private bool Save()
        {
            bool saved = false;
            if (table.Equals("banks"))
            {
                frmbd.loadSelectedBank(Id, selectedValue);
                saved = true;
            }            
            return saved;
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
