using OmniGov.Core.Interfaces.Services;
using OmniGov.PropertyAssessment.Data.Repositories;
using OmniGov.PropertyAssessment.Domain.Interfaces;
using OmniGov.PropertyAssessment.Domain.Interfaces.Factories;

namespace OmniGov.PropertyAssessment.Data.Factories
{
    public class PropertyAssessmentFactoryRepository : IPropertyAssessmentFactory
    {
        private IGenericCommands _genericCommands;

        public PropertyAssessmentFactoryRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public IBuildingDetailsRepository BuildingDetailsRepository() => new BuildingDetailsRepository(_genericCommands);

        public ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(_genericCommands);

        public ILandPropertiesRepository LandPropertiesRepository() => new LandPropertiesRepository(_genericCommands);

        public IPreviousAssessment PreviousAssessment() => new PreviousAssessmentRepository(_genericCommands);

        public IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(_genericCommands);
    }
}
