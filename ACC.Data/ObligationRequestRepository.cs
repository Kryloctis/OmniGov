using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {
        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";

        private readonly IObligationAccountRepository _obligationAccountRepository;

        private MySqlGenericCommands _mySqlGenericCommands;

        public ObligationRequestRepository(
            MySqlGenericCommands mySqlGenericCommands,
            IObligationAccountRepository obligationAccountRepository)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
            _obligationAccountRepository = obligationAccountRepository;
        }

        public int CountRecords()
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

        public bool Insert(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationRequestModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool Update(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        //Validations

        public bool ObligationRequestNoExist(string obligationNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_no", DbType.String, obligationNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool ObligationRequestNoExist(int Id, string obligationNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id",DbType.Int32, Id },
                    new object[] { "@obligation_no", DbType.String, obligationNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id obligation_no = @obligation_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public decimal TotalObligationRequestByYear(int fundsId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, short year)
        {
            try
            {
                try
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@funds_id", DbType.Int32, fundsId },
                        new object[] { "@fpp_id", DbType.Int32, fppId },
                        new object[] { "@others_fpp_id", DbType.String, otherFPPId },
                        new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                        new object[] { "@general_ledger_accounts_id", DbType.Int32, accountId},
                        new object[] { "@year",DbType.Int16, year}
                    };

                    string query = $"SELECT " +
                        $"COALESCE(SUM(obligation_requested_amount), 0) AS total_allotment_amount " +
                        $"FROM {viewTableName} " +
                        $"WHERE " +
                        $"funds_id = @funds_id " +
                        $"AND fpp_id = @fpp_id " +
                        $"AND others_fpp_id <=> others_fpp_id " +
                        $"AND allotment_classes_id = @allotment_classes_id " +
                        $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                        $"AND YEAR(date_requested) = @year";


                    return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    object[][] parameters = new object[][]
                    {
                        new object[] { "@function_program_project_id", DbType.Int32, entity.FPPId },
                        new object[] { "@others_fpp_id", DbType.String, entity.OtherFPPId },
                        new object[] { "@funds_id", DbType.Int32, entity.FundId },
                        new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassId },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} " +
                        $"(funds_id, " +
                        $"function_program_project_id, " +
                        $"others_fpp_id, " +
                        $"allotment_classes_id, " +
                        $"date_requested, " +
                        $"obligation_no, " +
                        $"payee, " +
                        $"explanation, " +
                        $"reference_no, " +
                        $"created_by) " +
                        $"VALUES(" +
                        $"@funds_id, " +
                        $"@function_program_project_id, " +
                        $"@others_fpp_id, " +
                        $"@allotment_classes_id, " +
                        $"@date_requested, " +
                        $"@obligation_no, " +
                        $"@payee, " +
                        $"@explanation, " +
                        $"@reference_no, " +
                        $"@created_by)";

                    // save and get the last inserted id
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    // loop jev accounts list then insert each using the latest Jev Id
                    foreach (var obligationAccounts in obligationAccountModels)
                    {
                        obligationAccounts.ObligationRequestId = GetLastInsertedID();
                        _ = _obligationAccountRepository.Insert(obligationAccounts);
                    }

                    scope.Complete();

                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

 
    }
}
