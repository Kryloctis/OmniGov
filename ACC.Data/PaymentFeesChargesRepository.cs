using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Data
{
    internal class PaymentFeesChargesRepository : IPaymentFeesCharges
    {
        private AccGenericCommands mySqlGenericCommandsLFS;

        public PaymentFeesChargesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<PaymentFeesChargesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PaymentFeesChargesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaymentFeesChargesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}