using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Domain.Interfaces
{
    public interface IServer
    {
        bool TestConnection(string connectionName);
    }
}