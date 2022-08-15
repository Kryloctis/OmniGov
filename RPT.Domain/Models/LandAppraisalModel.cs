using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Domain.Models
{
    public class LandAppraisalModel
    {
        public int Id { get; set; }
        public int LandPropertiesId { get; set; }
        public int ActualUseCodesId { get; set; }
        public int ClassificationCodesId { get; set; }
        public int PropertyClassId { get; set; }
        public int TypesOfLandId { get; set; }
        public bool IsPoblacion { get; set; }
        public decimal Area { get; set; }
        public decimal UnitValue { get; set; }
        public decimal MarketValue { get; set; }
    }
}
