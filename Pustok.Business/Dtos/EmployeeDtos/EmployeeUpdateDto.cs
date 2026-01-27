namespace Pustok.Business.Dtos;

public class EmployeeUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public Guid DepartmentId { get; set; }
}
