using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Exceptions;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Implementations
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

      

        public async Task CreateAsync(EmployeeCreateDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee is null)
                throw new NotFoundException("Employee is not found");
            _repository.Delete(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var employees = await _repository.GetAll().Include(x => x.Department).ToListAsync();
            var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);
            return dtos;
        }

        public async Task<EmployeeGetDto?> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee is null)
                throw new NotFoundException("Employee is not found");
            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return dto;
        }

        public async Task UpdateAsync(EmployeeUpdateDto dto)
        {
            var existEmployee = await _repository.GetByIdAsync(dto.Id);
            if (existEmployee is null)
                throw new NotFoundException("Employee is not found");
            existEmployee = _mapper.Map(dto, existEmployee);
            _repository.Update(existEmployee);
            await _repository.SaveChangesAsync();
        }
    }
}
