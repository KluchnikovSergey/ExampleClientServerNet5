using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid Version { get; set; }
    }
}
