using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
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
            try
            {
                if (SaveData())
                {
                    _frmJobOrder.LoadRecords();
                    Helper.MessageBoxSuccess("JO Collecting Officer has been saved.");
                    _uc.ResetForm();
                }
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
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

            return AccFactory.JobOrderRepository().Insert(jobOrderModel);
        }

        private bool AssignJOTORegularCollector()
        {
            var regularCollectingOfficerId = _frmJobOrder.collectingOfficerId;
            var JOCollectingOfficerId = AccFactory.JobOrderRepository().GetJobOrderIdByUserId(_uc.users_id);

            var collectingOfficerHasJOModel = new CollectingOfficerHasJobOrdersModel()
            {
                CollectingOfficerId = regularCollectingOfficerId,
                JobOrdersId = JOCollectingOfficerId
            };

            return AccFactory.CollectingOfficerHasJobOrdersRepository().Insert(collectingOfficerHasJOModel);
        }
    }
}