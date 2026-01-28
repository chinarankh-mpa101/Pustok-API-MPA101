using Pustok.Business.Dtos.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task CreateAsync(DepartmentCreateDto dto);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(DepartmentUpdateDto dto);
        Task<DepartmentGetDto> GetByIdAsync(Guid id);
        Task<List<DepartmentGetDto>> GetAllAsync();
    }
}
