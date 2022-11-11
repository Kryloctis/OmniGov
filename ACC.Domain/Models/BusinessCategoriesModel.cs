using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BusinessCategoriesModel
    {
        public int BusinessCategoryID { get; set; }
        public string Code { get; set; }
        public string OrdinanceReferenceNumber { get; set; }
        public string Description { get; set; }
        public bool LineOfBusiness { get; set; }
    }
}
