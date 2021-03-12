using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class BudgetAppropriationsRepository : IBudgetAppropriationsRepository
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "budget_appropriations";

        public BudgetAppropriationsRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BudgetAppropriationsModel> entityList)
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

        public bool Insert(BudgetAppropriationsModel entity)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                    new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                    new object[] { "@amount", DbType.Decimal, entity.amount}
               };

                string query = $"INSERT INTO {tableName} (function_program_project_id , others_fpp_id, allotment_classes_id, general_ledger_accounts_id, amount) VALUES (@function_program_project_id , @others_fpp_id, @allotment_classes_id, @general_ledger_accounts_id, @amount)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
 
        }

        public bool Update(BudgetAppropriationsModel entity)
        {
            throw new NotImplementedException();
        }

        #region Validations

        public bool BudgetAllotmentExist(int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                };

                string query = $"SELECT id FROM {tableName} WHERE function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool BudgetAllotmentExist(int id, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "id", DbType.Int32, id},
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id, function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        #endregion Validations
    }
}
