using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using System.Data;

namespace Accounting.Data.Repositories
{
    public class GeneralLedgerAccountsRepository : IGeneralLedgerAccountsRepository
    {
        private GenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "general_ledger_accounts";
        private readonly string tblAccGroup = "account_group";
        private readonly string tblMajAccGroup = "major_account_group";
        private readonly string tblSubMajAccGroup = "sub_major_account_group";
        private readonly string viewGenLedgrAccs = "view_general_ledger_accounts";

        public GeneralLedgerAccountsRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public Dictionary<string, string> GetViewRecordByID(int generalLedgerId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
            };

            string query = $"SELECT sub_major_account_group_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewGenLedgrAccs} WHERE general_ledger_accounts_id = @general_ledger_accounts_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, Id},
            };

            string query = $"SELECT sub_major_account_group_id, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {tableName} WHERE id = @general_ledger_accounts_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewGenLedgrAccs}";

            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%" },
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, sub_maj_acc_group_name, created_at, updated_at FROM {viewGenLedgrAccs} WHERE account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool Insert(GeneralLedgerAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GeneralLedgerAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralLedgerAccountsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_txt", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT {tableName}.id,CONCAT({tblAccGroup}.account_group_code,'-',{tblMajAccGroup}.maj_acc_group_code,'-',{tblSubMajAccGroup}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) AS account_code,{tableName}.ledger_name FROM {tableName} LEFT JOIN {tblSubMajAccGroup} ON {tableName}.sub_major_account_group_id={tblSubMajAccGroup}.id LEFT JOIN {tblMajAccGroup} ON {tblSubMajAccGroup}.major_account_group_id={tblMajAccGroup}.id LEFT JOIN {tblAccGroup} ON ({tblMajAccGroup}.account_group_id={tblAccGroup}.id AND {tblAccGroup}.id='4') WHERE CONCAT({tblAccGroup}.account_group_code,'-',{tblMajAccGroup}.maj_acc_group_code,'-',{tblSubMajAccGroup}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) IS NOT NULL AND (CONCAT({tblAccGroup}.account_group_code,'-',{tblMajAccGroup}.maj_acc_group_code,'-',{tblSubMajAccGroup}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) LIKE @search_txt OR ledger_name LIKE @search_txt)";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable());
        }

        public DataTable GetViewRecordsByMajorAccGroupName(string majAccGroupName)
        {
            var parameters = new object[][]
            {
                new object[] { "@maj_acc_group_name", DbType.String, majAccGroupName},
            };

            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE maj_acc_group_name = @maj_acc_group_name";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByMajorAccGroupNameSearch(string majAccGroupName, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@maj_acc_group_name", DbType.String, majAccGroupName},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE maj_acc_group_name = @maj_acc_group_name AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByAccountGroupName(string accountGroupName)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_name", DbType.String, accountGroupName},
            };

            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE account_group_name = @account_group_name ";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByAccountGroupNameSearch(string accountGroupName, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_name", DbType.String, accountGroupName},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE account_group_name = @account_group_name AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        //CHART OF ACCOUNTS
        public DataTable GetViewRecordsBy_AccountGroupId(int accountGroupId)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId}
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewGenLedgrAccs} WHERE account_group_id = @account_group_id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsBy_AccountGroupId_Search(int accountGroupId, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewGenLedgrAccs} WHERE account_group_id = @account_group_id AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsBy_AccountGroupId_Search_Limited(int accountGroupId, string searchText, int limit)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" },
                new object[] { "@limit", DbType.Int32, limit}
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewGenLedgrAccs} WHERE account_group_id = @account_group_id AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText) LIMIT @limit";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetGeneralLedgerAccountsIncomeRecords(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE account_group_code LIKE @searchText OR ledger_name LIKE @searchText AND account_group_code=4";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetGeneralLedgerAccountsIncomeRecords()
        {
            string query = $"SELECT * FROM {viewGenLedgrAccs} WHERE account_group_code=4";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }
    }
}