using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBarangayRepository : IRepository<BarangayModel>
    {
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}