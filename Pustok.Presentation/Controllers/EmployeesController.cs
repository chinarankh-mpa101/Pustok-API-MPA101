using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos;
using Pustok.Business.Services.Abstractions;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService _employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employees = await _employeeService.GetByIdAsync(id);
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok(); 
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeUpdateDto dto)
        {
            await _employeeService.UpdateAsync(dto);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }
    }
}
