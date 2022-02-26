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


namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerEdit : Form
    {
        private frmCollectingOfficer _frmCollectingOfficer;
        public frmCollectingOfficerEdit(frmCollectingOfficer frmCollectingOfficer, int OfficerId)
        {
            InitializeComponent();
            _frmCollectingOfficer = frmCollectingOfficer;
            ucCollectingOfficer1.OfficerId = OfficerId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucCollectingOfficer1;
                var repository = Factory.CollectingOfficerRepository();
                var data = repository.GetRecordByID(uc.OfficerId);

                uc.txtPrefix.Text = data["prefix"];
                uc.txtFirstName.Text = data["first_name"];
                uc.txtMiddleInitial.Text = data["mid_initial"];
                uc.txtLastName.Text = data["last_name"];
                uc.txtSuffix.Text = data["suffix"];
                uc.txtJobtitle.Text = data["job_title"];
                uc.UserId = data["users_id"] == string.Empty ? 0 : Convert.ToInt16(data["users_id"]);                
                uc.LoadLink(uc.UserId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }



        private bool SaveData()
        {
            try
            {
                var uc = ucCollectingOfficer1;

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var collectingmodel = new CollectingOfficerModel()
                {
                    Id = uc.OfficerId,
                    Prefix = uc.txtPrefix.Text.Trim(),
                    FirstName = uc.txtFirstName.Text.Trim(),
                    MiddleInitial = uc.txtMiddleInitial.Text.Trim(),
                    LastName = uc.txtLastName.Text.Trim(),
                    Suffix = uc.txtSuffix.Text.Trim(),
                    JobTitle = uc.txtJobtitle.Text.Trim(),
                    UserId = uc.UserId
                };

                var collectingrepository = Factory.CollectingOfficerRepository();
                return collectingrepository.Update(collectingmodel);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                _frmCollectingOfficer.LoadRecords();
            }
        }

        private void frmCollectingOfficerEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }
    }
}
