using ACC.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class ucCashTickets : UserControl
    {
        int cashTicketId;
        int accountableFormId;
        public ucCashTickets()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbAccountableForms),
                errorProvider1.GetError(nudQuantity),
                errorProvider1.GetError(dtpReceivedDate)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();

        }
        private void ucCashTickets_Load(object sender, EventArgs e)
        {
            //LoadAccountableForms(); those cash tickets only.
            LoadAccountableForms();
        }

        internal void LoadAccountableForms()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("accountable_form", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var dtAccoutnableForm = AccFactory.AccountableFormsRepository().GetCashTicketsAccountableForm();
            foreach (DataRow row in dtAccoutnableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["accountable_form"] = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.AccountableFormsCombobox(cmbAccountableForms, dataTable, "id", "accountable_form");
        }

        internal void ResetForm()
        {
            cashTicketId = 0;
            accountableFormId = 0;

            dtpReceivedDate.Value = DateTime.Today;
            nudQuantity.Value = 0;
            txtRemark.Clear();
        }

    }
}
