using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;


namespace ACC.Data
{
    public class RCIRepository:IRCIRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "rci";
        private readonly string tableName2 = "banks";
        private readonly string tableName3 = "funds";
        private readonly string tableName4 = "function_program_project";
        private readonly string tableName5 = "functional_classification_services";
        private readonly string tableName6 = "functional_classifications";
        public RCIRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT * FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.banks_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.funds_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.function_program_project_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.functional_classification_services_id LEFT JOIN {tableName6} ON {tableName6}.id={tableName5}.functional_classifications_id WHERE {tableName}.id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("check_date", reader.Rows[0]["check_date"].ToString());
                    record.Add("check_no", reader.Rows[0]["check_no"].ToString());
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("banks_id", reader.Rows[0]["banks_id"].ToString());
                    record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
                    record.Add("payee", reader.Rows[0]["payee"].ToString());
                    record.Add("nature_of_payment", reader.Rows[0]["nature_of_payment"].ToString());
                    record.Add("obligation_no", reader.Rows[0]["obligation_no"].ToString());
                    record.Add("function_program_project_id", reader.Rows[0]["function_program_project_id"].ToString());
                    record.Add("trust_liabilities", reader.Rows[0]["trust_liabilities"].ToString());
                    record.Add("bir_vat_nonvat", reader.Rows[0]["bir_vat_nonvat"].ToString());
                    record.Add("amount", reader.Rows[0]["amount"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName2}.account_no,{tableName2}.bank_name,{tableName}.check_date,{tableName}.check_no,{tableName}.dv_no,{tableName}.payee,{tableName}.nature_of_payment,{tableName}.obligation_no,{tableName4}.fpp_code,{tableName}.trust_liabilities,{tableName}.bir_vat_nonvat,{tableName}.amount,{tableName}.amount-{tableName}.bir_vat_nonvat AS netamount,{tableName}.created_at,{tableName}.updated_at FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.banks_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.funds_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.function_program_project_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.functional_classification_services_id LEFT JOIN {tableName6} ON {tableName6}.id={tableName5}.functional_classifications_id";

                var dtRCI = new DataTable();
                return _dbGenericCommands.Fill(query, dtRCI);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetRecordsbyaccountid(int Id,string month)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                    new object[] { "@month", DbType.String, month},
                };
                string query = $"SELECT * FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.banks_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.funds_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.function_program_project_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.functional_classification_services_id LEFT JOIN {tableName6} ON {tableName6}.id={tableName5}.functional_classifications_id WHERE {tableName2}.id = @id AND DATE_FORMAT({tableName}.check_date,'%M-%Y')=@month";
                return _dbGenericCommands.ExecuteReader(query,parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Insert(RCIModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@banks_id", DbType.Int16, entity.BankId},
                    new object[] { "@funds_id", DbType.Int16, entity.FundsId},
                    new object[] { "@function_program_project_id", DbType.Int16, entity.FunctionProgramProjectId},
                    new object[] { "@check_date", DbType.Date, entity.CheckDate},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@dv_no", DbType.String, entity.DvNo},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
                    new object[] { "@obligation_no", DbType.String, entity.ObNo},
                    new object[] { "@trust_liabilities", DbType.Decimal, entity.TrustLiabilities},
                    new object[] { "@bir_vat_nonvat", DbType.Decimal, entity.BirVatNonVat},
                    new object[] { "@amount", DbType.Decimal, entity.Amount}
                };

                string query = $"INSERT INTO {tableName} (banks_id,funds_id,function_program_project_id,check_date,check_no,dv_no,payee,nature_of_payment,obligation_no,trust_liabilities,bir_vat_nonvat,amount) VALUES (@banks_id,@funds_id,@function_program_project_id,@check_date,@check_no,@dv_no,@payee,@nature_of_payment,@obligation_no,@trust_liabilities,@bir_vat_nonvat,@amount)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Update(RCIModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@banks_id", DbType.Int16, entity.BankId},
                    new object[] { "@funds_id", DbType.Int16, entity.FundsId},
                    new object[] { "@function_program_project_id", DbType.Int16, entity.FunctionProgramProjectId},
                    new object[] { "@check_date", DbType.Date, entity.CheckDate},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@dv_no", DbType.String, entity.DvNo},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
                    new object[] { "@obligation_no", DbType.String, entity.ObNo},
                    new object[] { "@trust_liabilities", DbType.Decimal, entity.TrustLiabilities},
                    new object[] { "@bir_vat_nonvat", DbType.Decimal, entity.BirVatNonVat},
                    new object[] { "@amount", DbType.Decimal, entity.Amount}
                };

                string query = $"UPDATE {tableName} SET banks_id=@banks_id,funds_id=@funds_id,function_program_project_id=@function_program_project_id,check_date=@check_date,check_no=@check_no,dv_no=@dv_no,payee=@payee,nature_of_payment=@nature_of_payment,obligation_no=@obligation_no,trust_liabilities=@trust_liabilities,bir_vat_nonvat=@bir_vat_nonvat,amount=@amount WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Delete(List<RCIModel> entityList)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;

                string query = $"SELECT {tableName}.id,{tableName2}.account_no,{tableName2}.bank_name,{tableName}.check_date,{tableName}.check_no,{tableName}.dv_no,{tableName}.payee,{tableName}.nature_of_payment,{tableName4}.fpp_code,{tableName}.obligation_no,{tableName}.trust_liabilities,{tableName}.bir_vat_nonvat,{tableName}.amount,{tableName}.created_at,{tableName}.updated_at FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.banks_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.funds_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.function_program_project_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.functional_classification_services_id LEFT JOIN {tableName6} ON {tableName6}.id={tableName5}.functional_classifications_id WHERE {tableName2}.account_no  LIKE'%{srchtxt}%' OR {tableName2}.bank_name  LIKE'%{srchtxt}%' OR {tableName3}.fund_code  LIKE'%{srchtxt}%' OR {tableName4}.fpp_code  LIKE'%{srchtxt}%' OR {tableName4}.fpp_name  LIKE'%{srchtxt}%' OR {tableName}.payee  LIKE'%{srchtxt}%' OR {tableName}.nature_of_payment  LIKE'%{srchtxt}%'";

                var dtRCI = new DataTable();
                return _dbGenericCommands.Fill(query, dtRCI);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
