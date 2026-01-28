using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.DepartmentDtos
{
    public class DepartmentGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<EmployeeGetDto> Employees { get; set; } = [];
    }
}
