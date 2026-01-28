using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Dtos.DepartmentDtos;
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
    internal class DepartmentService(IDepartmentRepository _repository,IMapper _mapper) : IDepartmentService
    {
        public async Task<ResultDto> CreateAsync(DepartmentCreateDto dto)
        {
            var isExistDepartment= await _repository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower());
            if (isExistDepartment)
                throw new AlreadyExistException();
            var department = _mapper.Map<Department>(dto);
            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
            return new ResultDto
            {
                IsSucced = true,
                Message = "Department created successfully"
            };
        }

        public async Task<ResultDto> DeleteAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department is null)
                throw new NotFoundException();

            _repository.Delete(department);
            await _repository.SaveChangesAsync();
            return new ResultDto
            {
                IsSucced = true,
                Message = "Department deleted successfully"
            };

        }
            public async Task<ResultDto<List<DepartmentGetDto>>> GetAllAsync()
        {

            var departments = await _repository.GetAll().Include(x=>x.Employees).ToListAsync();
            var dtos = _mapper.Map<List<DepartmentGetDto>>(departments);
            return new() { Data = dtos };
        }

        public async Task<ResultDto<DepartmentGetDto>> GetByIdAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department is null)
                throw new NotFoundException();

            var dto = _mapper.Map<DepartmentGetDto>(department);

            return new() { Data = dto };
        }

        public async Task<ResultDto> UpdateAsync(DepartmentUpdateDto dto)
        {
            var department = await _repository.GetByIdAsync(dto.Id);

            if (department is null)
                throw new NotFoundException();

            var isExistDepartment = await _repository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != dto.Id);

            if (isExistDepartment)
                throw new AlreadyExistException();

            department = _mapper.Map<DepartmentUpdateDto, Department>(dto, department);

            _repository.Update(department);
            await _repository.SaveChangesAsync();
            return new ResultDto
            {
                IsSucced = true,
                Message = "Department updated successfully"
            };
        }
    }
}
