using AutoMapper;
using Pustok.Business.Dtos.DepartmentDtos;
using Pustok.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Profiles
{
    internal class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
        }
    }
}
