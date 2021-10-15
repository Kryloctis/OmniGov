using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class AmortizationScheduleRepository : IAmortizationScheduleRepository
    {
        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AmortizationScheduleModel> entityList)
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

        public bool Insert(AmortizationScheduleModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AmortizationScheduleModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
