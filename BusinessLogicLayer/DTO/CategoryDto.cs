using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ParentContainerId { get; set; }
     
        public string ParentContainerName { get; set; }
    }
}
