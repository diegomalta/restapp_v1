using System;

namespace RestApp.Domain.Model.Queries
{
    public class DailyReport
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalOrders { get; set; }
        public bool IsActive { get; set; }
    }
}
