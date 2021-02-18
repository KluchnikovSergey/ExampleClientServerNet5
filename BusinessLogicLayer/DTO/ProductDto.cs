using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float PriceSell { get; set; }

        public string ParentContainerId { get; set; }
     
        public string ParentContainerName { get; set; }

        public Guid Version { get; set; }
    }
}
