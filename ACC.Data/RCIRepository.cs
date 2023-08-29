using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RCIRepository : IRCIRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "rci";
        private readonly string tableRCIObligations = "rci_obligations";
        private readonly string tableRCIDeductions = "rci_deductions";

        private readonly string viewTableName = "view_rci";

        public RCIRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("cheques_id", reader.Rows[0]["cheques_id"].ToString());
                record.Add("cheque_no", reader.Rows[0]["cheque_no"].ToString());
                record.Add("cheque_date", reader.Rows[0]["cheque_date"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("bank_id", reader.Rows[0]["bank_id"].ToString());
                record.Add("fund_id", reader.Rows[0]["fund_id"].ToString());
                record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
                record.Add("payee", reader.Rows[0]["payee"].ToString());
                record.Add("nature_of_payment", reader.Rows[0]["nature_of_payment"].ToString());
                record.Add("obligation_no", reader.Rows[0]["obligation_no"].ToString());
                record.Add("function_program_project_id", reader.Rows[0]["fpp_id"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtRCI = new DataTable();
            return _dbGenericCommands.Fill(query, dtRCI);
        }

        public DataTable GetViewRecordsByBankAccountIdAndMonth(int bankAccountID, string month)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accouns_id", DbType.Int32, bankAccountID},
                new object[] { "@month", DbType.String, month},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accouns_id AND MONTH(cheque_date) = @month";
            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public bool Insert(RCIModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@cheques_id", DbType.Int32, entity.ChequeID},
                new object[] { "@funds_id", DbType.Int32, entity.FundId},
                new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
            };

            string query = $"INSERT INTO {tableName} (cheques_id, funds_id, function_program_project_id, dv_no, payee, nature_of_payment) VALUES(@cheques_id, @funds_id, @function_program_project_id, @dv_no, @payee, @nature_of_payment)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RCIModel entity)
        {
            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@funds_id", DbType.Int32, entity.FundId},
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
            };

            string query = $"UPDATE {tableName} SET funds_id = @funds_id, function_program_project_id = @function_program_project_id, dv_no = @dv_no, payee = @payee, nature_of_payment = @nature_of_payment WHERE id = @id";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<RCIModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                            new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query));
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int16, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] {
                    new object[] { "@searchText", DbType.String, $"%{searchText}%"}
                };

            string query = $"SELECT * FROM {viewTableName} WHERE payee LIKE @searchText OR bank_name LIKE @searchText  OR bank_account_no LIKE @searchText OR obligation_no LIKE @searchText";

            var dtRCI = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtRCI, parameter);
        }

        public DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountsID)
        {
            var parameter = new object[][] {
                new object[] { "@bank_id", DbType.Int32, bankID },
                new object[] { "@bank_accounts_id", DbType.Int32, bankAccountsID }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_id = @bank_id AND bank_accounts_id = @bank_accounts_id";

            var dtRCI = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtRCI, parameter);
        }

        public bool SaveRCIDVObligations(int rciId, string obligationNo, DateTime dateEntry)
        {
            var parameters = new object[][]
            {
                new object[] { "@rciId", DbType.Int32, rciId},
                new object[] { "@obligationNo", DbType.String, obligationNo},
                new object[] { "@date_entry", DbType.DateTime, dateEntry},
            };

            string query = $"INSERT INTO {tableRCIObligations} (rci_id, obligation_no, date_entry) VALUES(@rciId, @obligationNo, @date_entry)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool SaveRCIDeductions(int rciId, string description, decimal amount)
        {
            var parameters = new object[][]
            {
                        new object[] { "@rciId", DbType.Int32, rciId},
                        new object[] { "@obligationNo", DbType.String, description},
                        new object[] { "@amount", DbType.Decimal, amount},
            };

            string query = $"INSERT INTO {tableRCIDeductions} (rci_id, description, amount) VALUES(@rciId, @obligationNo, @amount)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetLastInsertId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query));
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtRCI = new DataTable();
            return _dbGenericCommands.Fill(query, dtRCI);
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE cheque_no LIKE @search_text OR bank_account_no LIKE @search_text OR bank_name LIKE @search_text OR dv_no LIKE @search_text OR obligation_no LIKE @search_text OR payee LIKE @search_text";

            var dtRCI = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtRCI, parameters);
        }
    }
}