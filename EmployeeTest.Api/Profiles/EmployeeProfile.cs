using AutoMapper;
using EmployeeTest.Api.Models;
using EmployeeTest.Data.Entities;

namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>(); // Map Employee model to EmployeeDto
            CreateMap<EmployeeDto, Employee>(); // Map EmployeeDto to Employee model
        }
    }
}