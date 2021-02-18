using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float PriceSell { get; set; }
        public float PriceBayConfidiceal { get; set; }

        public Guid ParentCategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
