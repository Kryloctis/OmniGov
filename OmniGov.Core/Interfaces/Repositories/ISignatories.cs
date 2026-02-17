using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface ISignatories : IRepository<SignatoriesModel>
    {
        bool Insert(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);

        bool Update(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);
    }
}
