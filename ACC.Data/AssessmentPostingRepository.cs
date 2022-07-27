using ACC.Data;
using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Data
{
    public class AssessmentPostingRepository : IAssessmentPostingRepository
    {
        private readonly string tableName = "assessment_posts";

        private MySqlGenericCommands _mySqlGenericCommands;

        public AssessmentPostingRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AssessmentPostingModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByArpNo(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo}
            };

            string query = $"SELECT * FROM {tableName} WHERE complete_arp_no = @complete_arp_no ORDER BY complete_arp_no";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled)
        {
            var parameters = new object[][]
            {
                new object[] { "@owner_name", DbType.String, ownerName},
            };

            string isCancelledQuery = $"AND is_cancelled = 0";
            string query;

            if (isCancelled)
                query = $"SELECT * FROM {tableName} WHERE owner_name = @owner_name GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";
            else
               query = $"SELECT * FROM {tableName} WHERE owner_name = @owner_name {isCancelledQuery} GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object [] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR owner_name LIKE @search_text OR owner_tin LIKE @search_text OR owner_address LIKE @search_text OR owner_contact LIKE @search_text OR barangay_name LIKE @search_text OR municipality_name LIKE @search_text OR province_name LIKE @search_text GROUP BY owner_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AssessmentPostingModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@arp_no", DbType.String, entity.ArpNo },
                new object[] { "@posted_at", DbType.DateTime2, entity.PostedAt.ToString("yyyy-MM-dd hh:mm:ss") }
            };

            string query = $"INSERT INTO {tableName} (complete_arp_no, posted_at) VALUES (@arp_no, @posted_at)";

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool IsPropertyPosted(string arpNo)
        {
            {
                var parameters = new object[][]
                {
                new object[] { "@complete_arp_no", DbType.String, arpNo },
                };

                string query = $"SELECT complete_arp_no FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult))
                    return true;

                return false;
            }
        }

        public bool Update(AssessmentPostingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
