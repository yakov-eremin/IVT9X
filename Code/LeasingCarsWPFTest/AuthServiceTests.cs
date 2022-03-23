using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services.Authentification;
using LeasingCarsWPF.Services.Data;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace LeasingCarsWPFTest
{
    public class AuthServiceTests
    {
        [Fact]
        public async void Auth_Success()
        {
            //Arrange
            string expectedUsername = "aadmin";
            string expectedPassword = "123456";
            Mock<LeasingCarsDbContext> context = new Mock<LeasingCarsDbContext>();
            var employees = new List<Employee>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "First Name",
                    SecondName = "Second Name",
                    MiddleName = " Middle name",
                    Username = "Username",
                    Password = "Password",
                    PositionId = 1
                },
                new()
                {
                    Id = 2,
                    FirstName = "First Name2",
                    SecondName = "Second Name2",
                    MiddleName = " Middle name2",
                    Username = "aadmin",
                    Password = "123456",
                    PositionId = 2
                },
                new()
                {
                    Id = 3,
                    FirstName = "First Name3",
                    SecondName = "Second Name3",
                    MiddleName = " Middle name3",
                    Username = "aadminn",
                    Password = "123457",
                    PositionId = 2
                }
            };
            var employeesMock = employees.AsQueryable().BuildMockDbSet();
            context.Setup(c => c.Set<Employee>()).Returns(employeesMock.Object);
            Mock<IDbContextFactory<LeasingCarsDbContext>> factory = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            factory.Setup(f => f.CreateDbContext()).Returns(context.Object);
            IDataService<Employee> empService = new DataService<Employee>(factory.Object);
            IAuthService authService = new AuthService(empService);

            //Act
            var actualResult = await authService.Auth(expectedUsername, expectedPassword);
            
            //Assert
            Assert.NotNull(actualResult);
        }
        
        [Fact]
        public async void Auth_ThrowsException_Success()
        {
            //Arrange
            string expectedUsername = "wrong";
            string expectedPassword = "wrong";
            Mock<LeasingCarsDbContext> context = new Mock<LeasingCarsDbContext>();
            var employees = new List<Employee>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "First Name",
                    SecondName = "Second Name",
                    MiddleName = " Middle name",
                    Username = "Username",
                    Password = "Password",
                    PositionId = 1
                },
                new()
                {
                    Id = 2,
                    FirstName = "First Name2",
                    SecondName = "Second Name2",
                    MiddleName = " Middle name2",
                    Username = "aadmin",
                    Password = "123456",
                    PositionId = 2
                },
                new()
                {
                    Id = 3,
                    FirstName = "First Name3",
                    SecondName = "Second Name3",
                    MiddleName = " Middle name3",
                    Username = "aadminn",
                    Password = "123457",
                    PositionId = 2
                }
            };
            var employeesMock = employees.AsQueryable().BuildMockDbSet();
            context.Setup(c => c.Set<Employee>()).Returns(employeesMock.Object);
            Mock<IDbContextFactory<LeasingCarsDbContext>> factory = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            factory.Setup(f => f.CreateDbContext()).Returns(context.Object);
            IDataService<Employee> empService = new DataService<Employee>(factory.Object);
            IAuthService authService = new AuthService(empService);

            //Act
            Func<Task> act = () => authService.Auth(expectedUsername, expectedPassword);
            
            //Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Пользователь не найдет. Проверьте логин или пароль", exception.Message);
        }
    }
}