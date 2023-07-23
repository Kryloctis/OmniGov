using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IServer
    {
        bool TestConnection(string connectionName);

        bool ApplyConnection(string connectionName);
    }
}