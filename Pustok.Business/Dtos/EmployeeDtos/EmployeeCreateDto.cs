using Microsoft.AspNetCore.Http;

namespace Pustok.Business.Dtos;

public class EmployeeCreateDto
{
  
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; } = null!;
    public Guid DepartmentId { get; set; }
}
