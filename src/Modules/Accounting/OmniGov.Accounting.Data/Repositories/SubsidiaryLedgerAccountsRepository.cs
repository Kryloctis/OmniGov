using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace Accounting.Data.Repositories
{
    public class SubsidiaryLedgerAccountsRepository : ISubsidiaryLedgerAccountsRepository
    {
        private readonly string tableName = "subsidiary_ledger_accounts";
        private readonly string viewTableName = "view_subsidiary_ledger_accounts";
        private readonly IGenericCommands _genericCommands;

        public SubsidiaryLedgerAccountsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<SubsidiaryLedgerAccountsModel> entityList)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    object[][] parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            Dictionary<string, string> record = new Dictionary<string, string>();

            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.UInt16, Id},
            };

            string query = $"SELECT funds_id, general_ledger_accounts_id, sub_code, sub_name, address, contact_person, contact, created_at, updated_at FROM {tableName} WHERE id = @id";

            using (DataTable reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("general_ledger_accounts_id", reader.Rows[0]["general_ledger_accounts_id"].ToString());
                record.Add("sub_code", reader.Rows[0]["sub_code"].ToString());
                record.Add("sub_name", reader.Rows[0]["sub_name"].ToString());
                record.Add("address", reader.Rows[0]["address"].ToString());
                record.Add("contact_person", reader.Rows[0]["contact_person"].ToString());
                record.Add("contact", reader.Rows[0]["contact"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }
            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            DataTable dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByReference(int Id)
        {
            string query = $"SELECT * FROM {tableName} WHERE general_ledger_accounts_id='{Id}'";

            DataTable dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {tableName} WHERE sub_code LIKE @search_text OR sub_code LIKE @search_text";

            DataTable dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearchByReference(string searchText, int Id)
        {
            object[][] parameters = new object[][]
            {
                new object[]{"@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE general_ledger_accounts_id='{Id}' AND sub_code LIKE @search_text OR sub_code LIKE @search_text";

            DataTable dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByFundAndGeneralLedger(int fundId, int generalLedgerId)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@generalLedgerId", DbType.Int32, generalLedgerId},
            };

            string query = $"SELECT * FROM {tableName} WHERE funds_id = @funds_id AND general_ledger_accounts_id = @generalLedgerId";

            DataTable dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SubsidiaryLedgerAccountsModel entity)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, entity.FundId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerAccountsId},
                new object[] { "@sub_code", DbType.String, entity.Code},
                new object[] { "@sub_name", DbType.String, entity.Name},
                new object[] { "@address", DbType.String, entity.Address},
                new object[] { "@contact_person", DbType.String, entity.ContactPerson},
                new object[] { "@contact", DbType.String, entity.Contact}
            };

            string query = $"INSERT INTO {tableName} (funds_id, general_ledger_accounts_id, sub_code, sub_name, address, contact_person, contact) VALUES (@funds_id, @general_ledger_accounts_id, @sub_code, @sub_name, @address, @contact_person, @contact)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(SubsidiaryLedgerAccountsModel entity)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.UInt16, entity.Id},
                new object[] { "@funds_id", DbType.Byte, entity.FundId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerAccountsId},
                new object[] { "@sub_code", DbType.String, entity.Code},
                new object[] { "@sub_name", DbType.String, entity.Name},
                new object[] { "@address", DbType.String, entity.Address},
                new object[] { "@contact_person", DbType.String, entity.ContactPerson},
                new object[] { "@contact", DbType.String, entity.Contact}
            };

            string query = $"UPDATE {tableName} SET funds_id = @funds_id, general_ledger_accounts_id = @general_ledger_accounts_id, sub_code = @sub_code, sub_name = @sub_name, address = @address, contact_person = @contact_person, contact = @contact WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool HasSubsidiary(ushort generalLedgerId, byte fundId)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId },
                new object[] { "@funds_id", DbType.Byte, fundId }
            };

            string query = $"SELECT id FROM {tableName} WHERE general_ledger_accounts_id = @general_ledger_accounts_id AND funds_id = @funds_id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public DataTable GetViewRecordsByFundId_GenAccId(int fundId, int generalLedgerAccId)
        {
            object[][] parameters = new object[][]
            {
                new object[] {"@funds_id", DbType.Int32, fundId },
                new object[] {"@general_ledger_accounts_id", DbType.Int32, generalLedgerAccId}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE funds_id = @funds_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
            DataTable dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}