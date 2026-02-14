using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface ISignatories : IRepository<SignatoriesModel>
    {
        bool Insert(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);

        bool Update(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);
    }
}