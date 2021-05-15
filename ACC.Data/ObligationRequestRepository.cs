using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

public class ObligationRequestRepository : IObligationRequestRepository
{
    private MySqlGenericCommands _mySqlGenericCommands;
    private readonly string tableName = "obligation_request";
    private readonly string viewTableName = "view_obligation_request";

    public ObligationRequestRepository(MySqlGenericCommands mySqlGenericCommands)
    {
        this._mySqlGenericCommands = mySqlGenericCommands;
    }

    public int CountRecords()
    {
        throw new NotImplementedException();
    }

    public bool Delete(List<ObligationRequestModel> entityList)
    {
        try
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.ID},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, entity.FundID },
                new object[] { "@function_program_project_id", DbType.Int32, entity.FPPId },
                new object[] { "@others_fpp_id", DbType.String, entity.OtherFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesID },
                new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GenLedgerAccID},
                new object[] { "@date_requested", DbType.Date, entity.DateRequested},
                new object[] { "@obligation_no", DbType.String, entity.ObligationNo},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@explanation", DbType.String, entity.Explanation},
                new object[] { "@reference_no", DbType.String, entity.ReferencesNo},
                new object[] { "@obligation_amount", DbType.Decimal, entity.ObligationAmount},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} " +
            $"(funds_id, " +
            $"function_program_project_id, " +
            $"others_fpp_id, " +
            $"allotment_classes_id, " +
            $"general_ledger_accounts_id, " +
            $"date_requested, " +
            $"obligation_no, " +
            $"payee, " +
            $"explanation, " +
            $"reference_no, " +
            $"obligation_amount, " +
            $"created_by) " +
            $"VALUES " +
            $"(@funds_id, " +
            $"@function_program_project_id, " +
            $"@others_fpp_id, " +
            $"@allotment_classes_id, " +
            $"@general_ledger_accounts_id, " +
            $"@date_requested, " +
            $"@obligation_no, " +
            $"@payee, " +
            $"@explanation, " +
            $"@reference_no, " +
            $"@obligation_amount, " +
            $"@created_by)";

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Update(ObligationRequestModel entity)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.ID },
                new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                new object[] { "@obligation_amount", DbType.Decimal, entity.ObligationAmount },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy }
            };

            string query = $"UPDATE {tableName} " +
                $"SET " +
                $"obligation_no = @obligation_no, " +
                $"obligation_amount = @obligation_amount, " +
                $"updated_by = @updated_by" +
                $" WHERE id = @id";

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool BulkInsert(List<ObligationRequestModel> obligationRequestModelList)
    {
        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in obligationRequestModelList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@funds_id", DbType.Int32, item.FundID},
                        new object[] { "@function_program_project_id", DbType.Int32, item.FPPId},
                        new object[] { "@others_fpp_id", DbType.String, item.OtherFPPId},
                        new object[] { "@allotment_classes_id", DbType.Int32, item.AllotmentClassesID},
                        new object[] { "@general_ledger_accounts_id", DbType.Int32, item.GenLedgerAccID},
                        new object[] { "@date_requested", DbType.Date, item.DateRequested},
                        new object[] { "@obligation_no", DbType.String, item.ObligationNo},
                        new object[] { "@payee", DbType.String, item.Payee},
                        new object[] { "@explanation", DbType.String, item.Explanation},
                        new object[] { "@reference_no", DbType.String, item.ReferencesNo},
                        new object[] { "@obligation_amount", DbType.Decimal, item.ObligationAmount},
                        new object[] { "@created_by", DbType.Int32, item.CreatedBy}
                    };

                    string query = $"INSERT INTO {tableName} " +
                    $"(funds_id, " +
                    $"function_program_project_id, " +
                    $"others_fpp_id, " +
                    $"allotment_classes_id, " +
                    $"general_ledger_accounts_id, " +
                    $"date_requested, " +
                    $"obligation_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"reference_no, " +
                    $"obligation_amount, " +
                    $"created_by) " +
                    $"VALUES " +
                    $"(@funds_id, " +
                    $"@function_program_project_id, " +
                    $"@others_fpp_id, " +
                    $"@allotment_classes_id, " +
                    $"@general_ledger_accounts_id, " +
                    $"@date_requested, " +
                    $"@obligation_no, " +
                    $"@payee, " +
                    $"@explanation, " +
                    $"@reference_no, " +
                    $"@obligation_amount, " +
                    $"@created_by)";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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

    #region Validations

    public bool ObligationNumExist(string obligationNum)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_no", DbType.String, obligationNum }
            };

            string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";
            string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
        }
        catch (Exception)
        {
            throw;
        }
        return false;
    }

    public bool ObligationNumExist(int id, string obligationNum)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
                new object[] { "@obligation_no", DbType.String, obligationNum }
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";
            string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
        }
        catch (Exception)
        {
            throw;
        }
        return false;
    }

    public bool AccountExist(int accountId, DateTime dateRequested)
    {
        try
        {
            var parameters = new object[][]
           {
                new object[] { "@general_ledger_accounts_id", DbType.Int32, accountId},
                new object[] { "@date_requested", DbType.Date,  dateRequested.Date}
           };

            string query = $"SELECT id FROM {tableName} WHERE general_ledger_accounts_id = @general_ledger_accounts_id AND date_requested = @date_requested";
            string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
        }
        catch (Exception)
        {
            throw;
        }
        return false;
    }

    public bool AccountExist(int id, int accountId, DateTime dateRequested)
    {
        try
        {
            var parameters = new object[][]
           {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, accountId},
                new object[] { "@date_requested", DbType.Date,  dateRequested.Date}
           };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id general_ledger_accounts_id = @general_ledger_accounts_id AND date_requested = @date_requested";
            string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
        }
        catch (Exception)
        {
            throw;
        }
        return false;
    }

    public Dictionary<string, string> GetRecordByObligation (string obligationNo)
    {
        var record = new Dictionary<string, string>();

        try
        {
            var parameters = new object[][] 
            {
                new object[]  { "@obligation_no", DbType.String, obligationNo }
            };

            string query = $"SELECT " +
                $"id, " +
                $"funds_id, " +
                $"function_program_project_id, " +
                $"others_fpp_id, " +
                $"allotment_classes_id, " +
                $"general_ledger_accounts_id, " +
                $"date_requested, " +
                $"obligation_no, " +
                $"payee, " +
                $"explanation, " +
                $"reference_no, " +
                $"obligation_amount, " +
                $"created_at, " +
                $"created_by, " +
                $"updated_at, " +
                $"updated_by " +
                $"FROM " +
                $"{tableName} " +
                $"WHERE " +
                $"obligation_no = @obligation_no";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                    record.Add("id", reader.Rows[0][0].ToString());
                    record.Add("funds_id", reader.Rows[0][1].ToString());
                    record.Add("function_program_project_id", reader.Rows[0][2].ToString());
                    record.Add("others_fpp_id", reader.Rows[0][3].ToString());
                    record.Add("allotment_classes_id", reader.Rows[0][4].ToString());
                    record.Add("general_ledger_accounts_id", reader.Rows[0][5].ToString());
                    record.Add("date_requested", reader.Rows[0][6].ToString());
                    record.Add("obligation_no", reader.Rows[0][7].ToString());
                    record.Add("payee", reader.Rows[0][8].ToString());
                    record.Add("explanation", reader.Rows[0][9].ToString());
                    record.Add("reference_no", reader.Rows[0][10].ToString());
                    record.Add("obligation_amount", reader.Rows[0][11].ToString());
                    record.Add("created_at", reader.Rows[0][12].ToString());
                    record.Add("created_by", reader.Rows[0][13].ToString());
                    record.Add("updated_at", reader.Rows[0][14].ToString());
                    record.Add("updated_by", reader.Rows[0][15].ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }

        return record;
    }

    public DataTable GetRecordsByObligation(string obligationNo)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_no", DbType.String, obligationNo }
            };

            string query = $"SELECT " +
                $"obligation_request_id, " +
                $"fund_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"fpp_id, " +
                $"fpp_code, " +
                $"fpp_name, " +
                $"others_fpp_id, " +
                $"others_fpp_name, " +
                $"allotment_class_id, " +
                $"allotment_class_code, " +
                $"allotment_class_name, " +
                $"gen_ledger_acc_id, " +
                $"gen_ledger_acc_code, " +
                $"account_code, " +
                $"gen_ledger_acc_name, " +
                $"date_requested, " +
                $"obligation_no, " +
                $"obligation_amount, " +
                $"created_at, " +
                $"created_by, " +
                $"updated_at, " +
                $"updated_by " +
                $"FROM {viewTableName} " +
                $"WHERE obligation_no = @obligation_no ";

            var dtObligationRequest = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dtObligationRequest, parameters);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public decimal GetTotalObligationAmountByYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateRequested)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundID },
                new object[] { "@function_program_project_id", DbType.Int32, fppID },
                new object[] { "@others_fpp_id", DbType.String, othersFPPID },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID },
                new object[] { "@general_ledger_accounts_id", DbType.Int32, accountID },
                new object[] { "@date_requested", DbType.Int16, dateRequested.Date.Year }
            };

            string query = $"SELECT " +
                $"COALESCE(SUM(obligation_amount),0.00) AS total_obligation_amount " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND function_program_project_id = @function_program_project_id " +
                $"AND others_fpp_id <=> @others_fpp_id " +
                $"AND allotment_classes_id = @allotment_classes_id " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"AND YEAR(date_requested) = @date_requested";

            return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));

        }
        catch (Exception)
        {
            throw;
        }

    }

    #endregion Validations
}