using RPT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Data
{
    public class ServerRepository : IServer
    {
        private RptGenericCommands mySqlGenericCommandsRPT;

        public ServerRepository(RptGenericCommands mySqlGenericCommandsRPT)
        {
            this.mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public bool TestConnection(string connectionName)
        {
            return mySqlGenericCommandsRPT.TestConnection(connectionName);
        }
    }
}