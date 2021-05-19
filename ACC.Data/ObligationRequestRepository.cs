using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {

        private MySqlGenericCommands _mySqlGenericCommands;

        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";

        public ObligationRequestRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationRequestModel> entityList)
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

        public decimal TotalObligationRequestByYear(int fundsId, int fppId, int? otherFPPId, int allotmentClassId, short year)
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
    }
}
