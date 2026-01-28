using Pustok.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Core.Entities
{
    public class Employee:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
