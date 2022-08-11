using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class RptPaymentPostsRepository : IRptPaymentPostsRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private IRptTaxDuesRepository _rptTaxDuesRepository;
        private readonly string tableName = "rpt_payment_posts";

        public RptPaymentPostsRepository(MySqlGenericCommands mySqlGenericCommandsLFS, IRptTaxDuesRepository rptTaxDuesRepository)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _rptTaxDuesRepository = rptTaxDuesRepository;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptPaymentPostsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptPaymentPostsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId }
            };

            string query = $"INSERT INTO  {tableName}  (payment_collections_id ) VALUES (@payment_collections_id)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPaymentPostsModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID()
        {
            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public bool InsertWithRptTaxDues(RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(rptPaymentPostsModel);

                foreach (RptTaxDuesModel rptTaxDuesModel in rptTaxDuesModels)
                {
                    rptTaxDuesModel.RptPaymentPostsId = GetLastInsertedID();
                    _ = _rptTaxDuesRepository.Insert(rptTaxDuesModel);
                }

                scope.Complete();
                return true;
            }
        }
    }
}
