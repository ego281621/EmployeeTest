using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTest.Api.Controllers;
using EmployeeTest.Api.Data;
using EmployeeTest.Api.Models;
using EmployeeTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EmployeeAPI.Tests
{
    public class EmployeesControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepository;
        private readonly IMapper _mapper;

        public EmployeesControllerTests()
        {
            _mockRepository = new Mock<IEmployeeRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeAPI.Profiles.EmployeeProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetEmployees_ReturnsListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(employees);

            var controller = new EmployeesController(_mockRepository.Object, _mapper);

            // Act
            var result = controller.GetEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetEmployeeById_ExistingId_ReturnsEmployee()
        {
            // Arrange
            int employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.GetById(employeeId)).Returns(employee);

            var controller = new EmployeesController(_mockRepository.Object, _mapper);

            // Act
            var result = controller.GetEmployeeById(employeeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<EmployeeDto>(okResult.Value);
            Assert.Equal(employeeId, model.Id);
        }

        [Fact]
        public async Task CreateEmployee_ValidData_ReturnsCreatedResponse()
        {
            // Arrange
            var employeeDto = new EmployeeDto { FirstName = "John", LastName = "Doe" };
            var controller = new EmployeesController(_mockRepository.Object, _mapper);

            // Act
            var result = controller.CreateEmployee(employeeDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<EmployeeDto>(createdResult.Value);
            Assert.Equal(employeeDto.FirstName, model.FirstName);
            Assert.Equal(employeeDto.LastName, model.LastName);
        }

        [Fact]
        public async Task UpdateEmployee_ExistingId_ReturnsNoContentResponse()
        {
            // Arrange
            int employeeId = 1;
            var employeeDto = new EmployeeDto { Id = employeeId, FirstName = "John", LastName = "Doe" };
            _mockRepository.Setup(repo => repo.GetById(employeeId)).Returns(new Employee());

            var controller = new EmployeesController(_mockRepository.Object, _mapper);

            // Act
            var result = controller.UpdateEmployee(employeeId, employeeDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_ExistingId_ReturnsNoContentResponse()
        {
            // Arrange
            int employeeId = 1;
            _mockRepository.Setup(repo => repo.GetById(employeeId)).Returns(new Employee());

            var controller = new EmployeesController(_mockRepository.Object, _mapper);

            // Act
            var result = controller.DeleteEmployee(employeeId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
