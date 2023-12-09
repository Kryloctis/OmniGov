using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Domain.Interfaces
{
    public interface IRegistry : IAccRepository<RegistryModel>
    {
    }
}