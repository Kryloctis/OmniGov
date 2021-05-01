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

    Dictionary<string, string> IObligationRequestRepository.GetRecordByObligationNum(string obligationNum)
    {
        var record = new Dictionary<string, string>();

        try
        {
            var parameters = new object[][]
            {
                    new object[] { "@obligation_no", DbType.String, obligationNum}
            };

            string query = $"SELECT " +
            $"id, " +
            $"funds_id, " +
            $"function_program_project_id, " +
            $"others_fpp_id, " +
            $"allotment_classes_id, " +
            $"general_ledger_accounts_id, " +
            $"date_issued, " +
            $"obligation_no, " +
            $"obligation_amount, " +
            $"created_at, " +
            $"created_by, " +
            $"updated_at, " +
            $"updated_by " +
            $"FROM {tableName} " +
            $"WHERE obligation_no = @obligation_no";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow item in reader.Rows)
                {
                    record.Add("id", item[0].ToString());
                    record.Add("funds_id", item[1].ToString());
                    record.Add("function_program_project_id", item[2].ToString());
                    record.Add("others_fpp_id", item[3].ToString());
                    record.Add("allotment_classes_id", item[4].ToString());
                    record.Add("general_ledger_accounts_id", item[5].ToString());
                    record.Add("date_issued", item[6].ToString());
                    record.Add("obligation_no", item[7].ToString());
                    record.Add("obligation_amount", item[8].ToString());
                    record.Add("created_at", item[9].ToString());
                    record.Add("updated_at", item[10].ToString());
                    record.Add("updated_by", item[11].ToString());
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return record;
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

    public Dictionary<string, string> GetTotalObligationAmountByYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, short year)
    {
        var record = new Dictionary<string, string>();

        try
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundID },
                new object[] { "@function_program_project_id", DbType.Int32, fppID },
                new object[] { "@others_fpp_id", DbType.String, othersFPPID },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID },
                new object[] { "@general_ledger_accounts_id", DbType.Int32, accountID },
                new object[] { "@year", DbType.Int16, year },
            };

            string query = $"SELECT " +
                $"COALESCE(SUM(obligation_amount),0.00) AS total_obligation_amount " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND function_program_project_id = @function_program_project_id " +
                $"AND others_fpp_id <=> @others_fpp_id " +
                $"AND allotment_classes_id = @allotment_classes_id " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"AND YEAR(date_requested) = @year";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow item in reader.Rows)
                {
                    record.Add("total_obligation_amount", item[0].ToString());
                }
            }

        }
        catch (Exception)
        {
            throw;
        }

        return record;
    }

    public bool ObligationRequestExist(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateIssued, string obligationNo)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundID },
                new object[] { "@function_program_project_id",DbType.Int32, fppID },
                new object[] { "@others_fpp_id",DbType.String, othersFPPID },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID },
                new object[] { "@general_ledger_accounts_id", DbType.Int32, accountID },
                new object[] { "@date_issued", DbType.Date, dateIssued },
                new object[] { "@obligation_no", DbType.String, obligationNo },
            };

            string query = $"SELECT * FROM {tableName} " +
            $"WHERE funds_id = @funds_id " +
            $"AND function_program_project_id = @function_program_project_id " +
            $"AND others_fpp_id <=> @others_fpp_id " +
            $"AND allotment_classes_id = @allotment_classes_id " +
            $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
            $"AND date_issued = @date_issued " +
            $"AND obligation_no = @obligation_no";
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

#endregion Validations
}