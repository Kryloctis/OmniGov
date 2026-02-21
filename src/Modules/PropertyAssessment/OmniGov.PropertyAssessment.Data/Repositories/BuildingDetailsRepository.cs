using OmniGov.Core.Interfaces.Services;
using OmniGov.PropertyAssessment.Domain.Entities;
using OmniGov.PropertyAssessment.Domain.Interfaces;
using System.Data;

namespace OmniGov.PropertyAssessment.Data.Repositories
{
    public class BuildingDetailsRepository : IBuildingDetailsRepository
    {
        private IGenericCommands _genericCommands;

        public BuildingDetailsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<BuildingDetailsModel> entityList)
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

        public decimal GetTotalAreaByBuildingPropertiesId(int buidlingPropertiesId)
        {
            var parameters = new object[][]
            {
                new object[] { "@building_properties_id", DbType.Int32, buidlingPropertiesId }
            };

            string query = $"SELECT COALESCE(SUM(area), 0) AS total_area FROM {buidlingPropertiesId} WHERE building_properties_id = @building_properties_id";
            decimal totalArea = Convert.ToDecimal(_genericCommands.ExecuteScalar(query, parameters));
            return totalArea;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BuildingDetailsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(BuildingDetailsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
