using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IPreferences : IAccRepository<PreferencesModel>
    {
        Dictionary<string, dynamic> GetRecordById(int id);
    }
}