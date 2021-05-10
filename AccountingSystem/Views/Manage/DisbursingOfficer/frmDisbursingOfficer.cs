using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficer : Form
    {
        public frmDisbursingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            btnAdd.Click += new EventHandler(BtnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);

            Helper.DatagridDefaultStyle(dgDisbursingOfficer);
        }

        internal void LoadRecords()
        {
            try
            {
                var dtDisbursingOfficers = Factory.DisbursingOfficerRepository().GetRecords();
                HelperLoadRecords.DisbursingOfficerDatagridView(dtDisbursingOfficers, dgDisbursingOfficer);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmDisbursingOfficer_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficerAdd().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDisbursingOfficer.Rows.Count > 0)
            {
                int disbursingOfficerId = int.Parse(dgDisbursingOfficer.SelectedCells[0].Value.ToString());
                _ = new frmDisbursingOfficerEdit(this, disbursingOfficerId).ShowDialog();
            }

        }

        private void dgDisbursingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgDisbursingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgDisbursingOfficer, btnEdit, btnDelete);
        }
    }
}
