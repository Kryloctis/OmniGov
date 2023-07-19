using ACC.Domain.Interfaces;
using AccountingSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Data
{
    public class ServerRepository : IServer
    {
        private AccGenericCommands mySqlGenericCommandsLFS;

        public ServerRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool TestConnection(string connectionName)
        {
            return mySqlGenericCommandsLFS.TestConnection(connectionName);
        }
    }
}