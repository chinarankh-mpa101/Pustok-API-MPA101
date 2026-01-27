using Pustok.Core.Entities.Common;

namespace Pustok.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = [];

    }
}
