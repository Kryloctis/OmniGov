using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection.Find
{
    public partial class frmFind : Form
    {
        internal int Id = 0;
        internal string selectedValue = string.Empty;
        internal string table = string.Empty;
        private ucPaymentCollection frmpc;
        public frmFind(ucPaymentCollection pc,string find)
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgSelect);
            dgSelect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table = find;
            frmpc = pc;
            this.Text = String.Format("Find > {0}", table.ToUpper());
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(table))
                if (table.Equals("subsidiary"))
                    LoadList();
        }

        private void LoadList()
        {
            try
            {
                if (!string.IsNullOrEmpty(table))
                {
                    if (table.Equals("ledger"))
                    {
                        var ledgerRepository = Factory.GeneralLedgerAccountsRepository();
                        var dtLedger = ledgerRepository.GetRecordsBySearch();
                        HelperLoadRecords.GeneralLedgerSearchDatagridView(dtLedger, dgSelect);
                    }
                    if (table.Equals("subsidiary"))
                    {
                        var subRepository = Factory.SubsidiaryLedgerAccountsRepository();
                        var dtsub = subRepository.GetRecordsByReference(frmpc.glaId);
                        HelperLoadRecords.SubsidiaryLedgerAccountsDatagridView(dtsub, dgSelect);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                if (!string.IsNullOrEmpty(table))
                {                  
                    if (table.Equals("subsidiary"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtsearch.Text.Trim());
                            var dtSub = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsBySearchByReference(searchkey,frmpc.glaId);
                            HelperLoadRecords.SubsidiaryLedgerAccountsDatagridView(dtSub, dgSelect);

                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }
                    if (table.Equals("ledger"))
                    {
                        try
                        {
                            string searchkey = Convert.ToString(txtsearch.Text.Trim());
                            var dtLedger = Factory.GeneralLedgerAccountsRepository().GetRecordsBySearch(searchkey);
                            HelperLoadRecords.GeneralLedgerSearchDatagridView(dtLedger, dgSelect);

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
                    if (table.Equals("ledger"))
                    {
                        Id = Convert.ToInt16(row.Cells[0].Value.ToString());
                        selectedValue = String.Format("{0} - {1}", row.Cells[1].Value, row.Cells[2].Value);
                    }
                    if (table.Equals("subsidiary"))
                    {
                        Id = Convert.ToInt16(row.Cells[0].Value.ToString());
                        selectedValue = String.Format("{0} - {1}", row.Cells[3].Value, row.Cells[4].Value);
                    }
                }
            }
        }
        private bool Save()
        {
            bool saved = false;
            if (table.Equals("ledger"))
            {
                frmpc.loadSelectedLedger(Id, selectedValue);
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
