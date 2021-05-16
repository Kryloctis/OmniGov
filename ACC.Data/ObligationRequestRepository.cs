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

    public DataTable GetViewRecordsByIdsAndMonthAndYear(int fppId, int? otherFPPId, int fundId, int allotmentClassId, int accountId, byte month, short year)
    {
        try
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.Int32, fppId },
                new object[] { "@others_fpp_id", DbType.String, otherFPPId },
                new object[] { "@fund_id", DbType.Int32, fundId },
                new object[] { "@allotment_class_id", DbType.Int32, allotmentClassId },
                new object[] { "@gen_ledger_acc_id", DbType.Int32, accountId },
                new object[] { "@month", DbType.Byte, month},
                new object[] { "@year", DbType.Int16, year}
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
                $"WHERE " +
                $"fpp_id = @fpp_id " +
                $"AND others_fpp_id <=> @others_fpp_id " +
                $"AND fund_id = @fund_id " +
                $"AND allotment_class_id = @allotment_class_id " +
                $"AND gen_ledger_acc_id = @gen_ledger_acc_id " +
                $"AND MONTH(date_requested) = @month " +
                $"AND YEAR(date_requested) = @year ";

            var dtAllotmentClasses = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dtAllotmentClasses, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion Validations
}