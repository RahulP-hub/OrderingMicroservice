using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Status { get; set; }
        public string OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public string ShipTo { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
    }
}
