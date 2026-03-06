using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

using System.Transactions;

namespace OmniGov.App.Views.Manage.JobOrders

{
    public partial class frmJobOrderAdd : Form

    {
        private readonly frmJobOrder _frmJobOrder;
        private readonly ucJobOrder _uc;

        public frmJobOrderAdd(frmJobOrder frmJobOrder)

        {
            InitializeComponent();

            _frmJobOrder = frmJobOrder;

            _uc = ucJobOrder1;
        }

        private bool AssignJOTORegularCollector()

        {
            var regularCollectingOfficerId = _frmJobOrder.collectingOfficerId;

            var JOCollectingOfficerId = TreasuryFactory.JobOrderRepository().GetJobOrderIdByUserId(_uc.users_id);

            var collectingOfficerHasJOModel = new CollectingOfficerHasJobOrdersModel()

            {
                CollectingOfficerId = regularCollectingOfficerId,

                JobOrdersId = JOCollectingOfficerId
            };

            return TreasuryFactory.CollectingOfficerHasJobOrdersRepository().Insert(collectingOfficerHasJOModel);
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

        private bool InsertJobOrder()

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

            return TreasuryFactory.JobOrderRepository().Insert(jobOrderModel);
        }

        private bool SaveData()

        {
            using (var scope = new TransactionScope())

            {
                if (InsertJobOrder() == true && AssignJOTORegularCollector() == true)

                {
                    scope.Complete();

                    return true;
                }

                return false;
            }
        }
    }
}