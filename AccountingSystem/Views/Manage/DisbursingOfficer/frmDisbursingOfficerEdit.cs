using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficerEdit : Form
    {
        private readonly frmDisbursingOfficer frmDisbursingOfficer;
        private readonly ucDisbursingOfficer uc;

        public frmDisbursingOfficerEdit(frmDisbursingOfficer frmDisbursingOfficer, int disbursingOfficerId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmDisbursingOfficer = frmDisbursingOfficer;

            uc = ucDisbursingOfficer1;
            uc.disbursingOfficerId = disbursingOfficerId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var disbursingOfficerDict = AccFactory.DisbursingOfficerRepository().GetRecordByID(uc.disbursingOfficerId);

                uc.txtPrefix.Text = disbursingOfficerDict["prefix"];
                uc.txtFirstName.Text = disbursingOfficerDict["first_name"];
                uc.txtMidInitial.Text = disbursingOfficerDict["mid_initial"];
                uc.txtLastName.Text = disbursingOfficerDict["last_name"];
                uc.txtSuffix.Text = disbursingOfficerDict["suffix"];
                uc.txtJobTitle.Text = disbursingOfficerDict["job_title"];
                uc.UserId = disbursingOfficerDict["users_id"] == string.Empty ? 0 : Convert.ToInt16(disbursingOfficerDict["users_id"]);
                uc.LoadLink(uc.UserId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmDisbursingOfficerEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var disbursingOfficerModel = new DisbursingOfficerModel()
            {
                Id = uc.disbursingOfficerId,
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = uc.txtMidInitial.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                LastName = uc.txtLastName.Text.Trim(),
                JobTitle = uc.txtJobTitle.Text.Trim(),
                UserId = uc.UserId,
            };

            return AccFactory.DisbursingOfficerRepository().Update(disbursingOfficerModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Disbursing officer has been saved.");
                    frmDisbursingOfficer.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}