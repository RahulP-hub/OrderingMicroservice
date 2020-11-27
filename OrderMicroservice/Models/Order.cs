using System;
using System.Collections.Generic;

#nullable disable

namespace OrderMicroservice.Models
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? LocationId { get; set; }
        public string OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public string ShipTo { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Status Status { get; set; }
    }
}
