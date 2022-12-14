using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface ISignatories : IAccRepository<SignatoriesModel>
    {
        bool Insert(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);

        bool Update(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList);
    }
}