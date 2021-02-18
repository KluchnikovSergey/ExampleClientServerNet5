using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entity
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }


        public virtual Category parentCategory { get; set; }
        public virtual List<Category> Categories { get; set; } = new List<Category>();        
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
