using System;
using System.Collections.Generic;

#nullable disable

namespace OrderMicroservice.Models
{
    public partial class Location
    {
        public Location()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string LocationName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
