using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class BusinessCategoriesHasAddOnChargesRepository : IBusinessCategoriesHasAddOnCharges
    {
        private readonly string tableName = "business_categories_has_add_on_charges";
        private readonly string viewTableName = "view_business_categories_has_add_on_charges";
        private GenericCommands _mySqlGenericCommandsLFS;

        public BusinessCategoriesHasAddOnChargesRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool BusinessCategoriesHasAddOnCharges(int businessCategoriesId, int addOnChargesId)
        {
            var parameters = new object[][]
            {
                new object[] { "@business_categories_id", DbType.Int32, businessCategoriesId },
                new object[] { "@business_add_on_charges_id", DbType.Int32, addOnChargesId }
            };

            string query = $"SELECT business_categories_id FROM {tableName} WHERE business_categories_id = @business_categories_id AND business_add_on_charges_id = @business_add_on_charges_id";

            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (string.IsNullOrEmpty(result))
                return false;
            return true;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BusinessCategoriesHasAddOnChargesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int businessCategoriesId)
        {
            var parameters = new object[][] { new object[] { "@business_categories_id", DbType.Int32, businessCategoriesId }, };

            string query = $"DELETE FROM {tableName} WHERE business_categories_id = @business_categories_id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public DataTable GetViewRecordsByBusinessCategoriesId(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@business_categories_id", DbType.Int32, id}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE business_categories_id = @business_categories_id";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BusinessCategoriesHasAddOnChargesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@business_categories_id", DbType.Int32, entity.businessCategoriesId},
                new object[] { "@business_add_on_charges_id", DbType.Int32, entity.businessAddOnChargesId}
            };

            string query = $"INSERT INTO {tableName} (business_categories_id, business_add_on_charges_id) VALUES (@business_categories_id, @business_add_on_charges_id)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Insert(int businessCategoriesId, List<BusinessCategoriesHasAddOnChargesModel> businessCategoriesHasAddOnChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Delete(businessCategoriesId);
                foreach (BusinessCategoriesHasAddOnChargesModel model in businessCategoriesHasAddOnChargesModels)
                    _ = Insert(model);

                scope.Complete();
                return true;
            }
        }

        public bool Update(BusinessCategoriesHasAddOnChargesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}