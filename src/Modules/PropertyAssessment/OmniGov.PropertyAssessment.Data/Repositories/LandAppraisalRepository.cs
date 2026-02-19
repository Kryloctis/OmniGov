using OmniGov.Core.Interfaces.Services;
using PropertyAssessment.Domain.Entities;
using PropertyAssessment.Domain.Interfaces;
using System.Data;

namespace PropertyAssessment.Data.Repositories
{
    public class LandAppraisalRepository : ILandAppraisalRepository
    {
        private IGenericCommands _genericCommands;
        private readonly string tableName = "land_appraisal";
        private readonly string viewTableName = "view_land_appraisal";

        public LandAppraisalRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<LandAppraisalModel> entityList)
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

        public bool Insert(LandAppraisalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(LandAppraisalModel entity)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAreaByLandPropertiesId(int landPropertiesId)
        {
            var parameters = new object[][]
            {
                new object[] { "@land_properties_id", DbType.Int32, landPropertiesId }
            };

            string query = $"SELECT COALESCE(SUM(area), 0) AS total_area FROM {viewTableName} WHERE land_properties_id = @land_properties_id";
            decimal totalArea = Convert.ToDecimal(_genericCommands.ExecuteScalar(query, parameters));
            return totalArea;
        }
    }
}