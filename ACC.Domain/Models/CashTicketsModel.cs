using System;

namespace ACC.Domain.Models
{
    public class CashTicketsModel
    {

        public int Id { get; set; }
        public int AccountableFormId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Remarks { get; set; }

    }
}
