using AutoMapper;
using EmployeeTest.Api.Data;
using EmployeeTest.Api.Models;
using EmployeeTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = _repository.GetAll();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _repository.Create(employee);
            var createdEmployeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployeeDto.Id }, createdEmployeeDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }
            var employee = _mapper.Map<Employee>(employeeDto);
            _repository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            return NoContent();
        }
    }
}