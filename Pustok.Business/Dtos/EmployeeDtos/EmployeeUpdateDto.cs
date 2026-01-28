using Microsoft.AspNetCore.Http;

namespace Pustok.Business.Dtos;

public class EmployeeUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile? Image { get; set; }
    public Guid DepartmentId { get; set; }
}
