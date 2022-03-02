using ACC.Domain.Models;
using System;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.JobOrders
{
    public partial class frmJobOrderAdd : Form
    {
        private readonly ucJobOrder _uc;
        private readonly frmJobOrder _frmJobOrder;

        public frmJobOrderAdd(frmJobOrder frmJobOrder)
        {
            InitializeComponent();

            _frmJobOrder = frmJobOrder;
            _uc = ucJobOrder1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                _frmJobOrder.LoadRecords();
                Helper.MessageBoxSuccess("JO Collecting Officer has been saved.");
                _uc.ResetForm();
            }
        }

        private bool SaveData()
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // if error occurs, show messagebox error
                    //if (!_uc.ValidateChildren())
                    //{
                    //    //Helper.MessageBoxError(_uc.GetFormErrors());
                    //    return false;
                    //}

                    if (InsertJobOrder() == true && AssignJOTORegularCollector())
                    {
                        scope.Complete();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }


        private bool InsertJobOrder()
        {
            try
            {
                var jobOrderModel = new JobOrderModel()
                {
                    Prefix = _uc.txtPrefix.Text.Trim(),
                    FirstName = _uc.txtFirstName.Text.Trim(),
                    MiddleInitial = _uc.txtMiddleInitial.Text.Trim(),
                    LastName = _uc.txtLastName.Text.Trim(),
                    Suffix = _uc.txtSuffix.Text.Trim(),
                    JobTitle = _uc.txtJobtitle.Text.Trim(),
                    UserId = _uc.users_id
                };

                var repository = Factory.JobOrderRepository();
                return repository.Insert(jobOrderModel);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        private bool AssignJOTORegularCollector()
        {
            try
            {
                var regularCollectingOfficerId = _frmJobOrder.collectingOfficerId;
                var JOCollectingOfficerId = Factory.JobOrderRepository().GetJobOrderIdByUserId(_uc.users_id);

                var jobOrderRepo = Factory.JobOrderRepository();

                return jobOrderRepo.AssignJOToRegular(regularCollectingOfficerId, JOCollectingOfficerId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
