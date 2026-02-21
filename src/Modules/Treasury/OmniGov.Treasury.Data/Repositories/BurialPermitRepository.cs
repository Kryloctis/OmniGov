using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    internal class BurialPermitRepository : IBurialPermitRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly string tableName = "burial_permit";

        public BurialPermitRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
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
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId},
                new object[] { "@remains_registry_id", DbType.Int32, entity.RemainsRegistryId},
                new object[] { "@remains_age", DbType.Int32, entity.RemainsAge},
                new object[] { "@death_date", DbType.DateTime, entity.DeathDate},
                new object[] { "@cause_of_death", DbType.String, entity.CauseOfDeath},
                new object[] { "@cemetery", DbType.String, entity.Cemetery},
                new object[] { "@disinterment", DbType.String, entity.Disinterment},
                new object[] { "@is_infectious", DbType.Boolean, entity.IsInfectious},
                new object[] { "@is_embalmed", DbType.Boolean, entity.IsEmbalmed},
                new object[] { "@disposition", DbType.String, entity.Disposition},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy }
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, remains_registry_id, remains_age, death_date, cause_of_death, cemetery, disinterment, is_infectious, is_embalmed, disposition, created_by) VALUES (@payment_collections_id, @remains_registry_id, @remains_age, @death_date, @cause_of_death, @cemetery, @disinterment, @is_infectious, @is_embalmed, @disposition, @created_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BurialPermitModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId},
                new object[] { "@remains_registry_id", DbType.Int32, entity.RemainsRegistryId},
                new object[] { "@remains_age", DbType.Int32, entity.RemainsAge},
                new object[] { "@death_date", DbType.DateTime, entity.DeathDate},
                new object[] { "@cause_of_death", DbType.String, entity.CauseOfDeath},
                new object[] { "@cemetery", DbType.String, entity.Cemetery},
                new object[] { "@disinterment", DbType.Boolean, entity.Disinterment},
                new object[] { "@is_infectious", DbType.Boolean, entity.IsInfectious},
                new object[] { "@is_embalmed", DbType.Boolean, entity.IsEmbalmed},
                new object[] { "@disposition", DbType.String, entity.Disposition},
                new object[] { "@updated_by", DbType.Int32, entity.CreatedBy }
            };

            string query = $"UPDATE {tableName} SET payment_collections_id = @payment_collections_id, remains_registry_id = @remains_registry_id, permission = @permission, remains_age = @remains_age, death_date = @death_date, cause_of_death = @cause_of_death, cemetery = @cemetery, disinterment = @disinterment, is_infectious = @is_infectious, is_embalmed = @is_embalmed, disposition = @disposition, updated_by = @updated_by WHERE id = @id;";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<BurialPermitModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var burialPermitModel in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, burialPermitModel.Id }
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }
    }
}
