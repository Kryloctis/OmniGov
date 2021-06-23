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


        public DataTable GetViewRecordsById(int Id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_request_id", DbType.String, Id }
                };

                string query = $"SELECT " +
                    $"obligation_request_id, " +
                    $"obligation_account_id, " +
                    $"obligation_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"reference_no, " +
                    $"date_requested, " +
                    $"obligation_request_created_at, " +
                    $"created_by, " +
                    $"obligation_request_updated_at, " +
                    $"updated_by, " +
                    $"budget_appropriations_id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"function_program_project_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_code, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_name, " +
                    $"is_contra_account, " +
                    $"year, " +
                    $"continuing, " +
                    $"remarks, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"obligation_request_id = @obligation_request_id";

                var dtObligationRequests = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtObligationRequests, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private int GetLastInsertedID()
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

        //INSERT
        public bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    object[][] parameters = new object[][]
                    {

                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} " +
                        $"(obligation_no, " +
                        $"payee, " +
                        $"explanation, " +
                        $"reference_no, " +
                        $"date_requested, " +
                        $"created_by) " +
                        $"VALUES " +
                        $"(@obligation_no, " +
                        $"@payee, " +
                        $"@explanation, " +
                        $"@reference_no, " +
                        $"@date_requested, " +
                        $"@created_by)";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

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

        //UPDATE
        public bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id",DbType.Int32, entity.Id},
                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
                    };

                    string query = $"UPDATE {tableName} SET obligation_no = @obligation_no, payee = @payee, explanation = @explanation, reference_no = @reference_no, date_requested = @date_requested, updated_by = @updated_by WHERE id = @id";


                    // save and get the last inserted id
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    // delete all the obligation accounts first
                    _ = _obligationAccountRepository.DeleteByObligationRequestId(entity.Id);

                    // loop obligation accounts list then insert each using the latest obligation request Id
                    foreach (var obligationAccounts in obligationAccountModels)
                    {
                        obligationAccounts.ObligationRequestId = entity.Id;
                        _ = _obligationAccountRepository.Insert(obligationAccounts);
                    }


                    scope.Complete();

                    return true;
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        //DELETE
        public bool Delete(int obligationRequestId)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _obligationAccountRepository.DeleteByObligationRequestId(obligationRequestId);

                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, obligationRequestId}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);


                    scope.Complete();
                    return true;
                };

            }
            catch (Exception)
            {
                throw;
            }
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

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

    }
}
