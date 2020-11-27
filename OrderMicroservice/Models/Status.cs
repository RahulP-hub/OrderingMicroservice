using System;
using System.Collections.Generic;

#nullable disable

namespace OrderMicroservice.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Status1 { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
