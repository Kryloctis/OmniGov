using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class frmJournals : Form
    {
        public frmJournals()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            try
            {
                var journalsRepository = Factory.JournalsRepository();
                var dtJournals = journalsRepository.GetRecords();
                HelperLoadRecords.JournalsDatagridView(dtJournals, dgJournals);

                lblRecordCount.Text = journalsRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmJournals_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgJournals);
            LoadRecords();
        }

        private void dgJournals_SelectionChanged(object sender, EventArgs e)
        {
            int[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgJournals, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgJournals, btnEdit, btnDelete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmJournalsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int journalId = int.Parse(dgJournals.SelectedCells[0].Value.ToString());
            _ = new frmJournalsEdit(this, journalId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgJournals.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var journalsModelList = new List<JournalsModel>();
                        foreach (DataGridViewRow row in dgJournals.SelectedRows)
                        {
                            int journalId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            journalsModelList.Add(new JournalsModel() { Id = journalId });
                        }

                        var journalsRepository = Factory.JournalsRepository();
                        _ = journalsRepository.Delete(journalsModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
