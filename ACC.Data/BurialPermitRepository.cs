using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class BurialPermitRepository : IBurialPermitRepository
    {
        private AccGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "burial_permit";

        public BurialPermitRepository(AccGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BurialPermitModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BurialPermitModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BurialPermitModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithBurialPermitPayment(BurialPermitModel burialPermitModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, burialPermitModel.TaxpayersID},
                new object[] { "@permission", DbType.String, burialPermitModel.Permission},
                new object[] { "@remains_name", DbType.String, burialPermitModel.RemainsName},
                new object[] { "@remains_nationality", DbType.String, burialPermitModel.RemainsNationality},
                new object[] { "@remains_age", DbType.Int32, burialPermitModel.RemainsAge},
                new object[] { "@remains_sex", DbType.String, burialPermitModel.RemainsSex},
                new object[] { "@death_date", DbType.DateTime, burialPermitModel.DeathDate},
                new object[] { "@cause_of_death", DbType.String, burialPermitModel.CauseOfDeath},
                new object[] { "@cemetery", DbType.String, burialPermitModel.Cemetery},
                new object[] { "@disinterment", DbType.String, burialPermitModel.Disinterment},
                new object[] { "@is_infectious", DbType.Boolean, burialPermitModel.IsInfectious},
                new object[] { "@is_embalmed", DbType.Boolean, burialPermitModel.IsEmbalmed},
                new object[] { "@disposition", DbType.String, burialPermitModel.Disposition},
                new object[] { "@created_at", DbType.DateTime, burialPermitModel.CreatedAt},
                new object[] { "@created_by", DbType.Int32, burialPermitModel.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (taxpayers_id, permission, remains_name, remains_nationality, remains_age, remains_sex, death_date, cause_of_death, cemetery, disinterment, is_infectious, is_embalmed, disposition, created_at, created_by) VALUES(@taxpayers_id, @permission, @remains_name, @remains_nationality, @remains_age, @remains_sex, @death_date, @cause_of_death, @cemetery, @disinterment, @is_infectious, @is_embalmed, @disposition, @created_at, @created_by)";

            bool result = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            return result;
        }
    }
}