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
    public class AssessmentPostsRepository : IAssessmentPostsRepository
    {

        private readonly string tableName = "assessment_posts";

        private MySqlGenericCommands _mySqlGenericCommandsRPT;

        public AssessmentPostsRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AssessmentPostsModel> entityList)
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

        public bool Insert(AssessmentPostsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool IsPropertyPosted(string arpNo)
        {
            {
                var parameters = new object[][]
                {
                new object[] { "@arp_no", DbType.String, arpNo },
                };

                string query = $"SELECT arp_no FROM {tableName} WHERE arp_no = @arp_no";
                string queryResult = _mySqlGenericCommandsRPT.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult))
                    return true;

                return false;
            }
        }

        public bool Update(AssessmentPostsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
