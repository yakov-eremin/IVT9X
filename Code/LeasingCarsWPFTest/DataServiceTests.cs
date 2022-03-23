using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services.Data;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace LeasingCarsWPFTest
{

    public class DataServiceTests
    {

        [Fact]
        public async void FirstOrDefault_Success()
        {
            //Arrange
            string expectedUsername = "aadmin";
            string expectedPassword = "123456";
            var context = new Mock<LeasingCarsDbContext>();
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
            }.AsQueryable().BuildMockDbSet();
            context.Setup(c => c.Set<Employee>()).Returns(employees.Object);
            var factory = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            factory.Setup(f => f.CreateDbContext()).Returns(context.Object);
            IDataService<Employee> empService = new DataService<Employee>(factory.Object);

            //Act
            var emp = await empService.FirsOrDefault(e => e.Username == expectedUsername && e.Password == expectedPassword);
            var actualUsername = emp.Username;
            var actualPassword = emp.Password;
            
            //Assert
            Assert.NotNull(emp);
            Assert.Equal(expectedUsername, actualUsername);
            Assert.Equal(expectedPassword, actualPassword);
        }

        [Fact]
        public async void UpdateCar_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var cars = new List<Car>()
            {
                new()
                {
                    Id = 1,
                    Name = "Lada",
                    Mileage = 100,
                    Number = "e111ee",
                    TypeId = 1,
                    StatusId = 1,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                },
                new()
                {
                    Id = 2,
                    Name = "BMW",
                    Mileage = 200,
                    Number = "e222ee",
                    TypeId = 2,
                    StatusId = 2,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                },
                new()
                {
                    Id = 1,
                    Name = "Renault",
                    Mileage = 300,
                    Number = "e333ee",
                    TypeId = 3,
                    StatusId = 3,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                }
            };

            var carsMock = cars.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Car>()).Returns(carsMock.Object);
            contextMock.Setup(c => c.Set<Car>().Update(It.IsAny<Car>()));
            factoryMock.Setup(f => f.CreateDbContext()).Returns(contextMock.Object);
            IDataService<Car> carService = new DataService<Car>(factoryMock.Object);

            //Act
            var carToUpdate = new Car()
            {
                Name = "New name",
                Mileage = cars[1].Mileage,
                Number = "New number",
                TypeId = 1,
                StatusId = 3,
                Type = cars[1].Type,
                Status = cars[1].Status
            };
            carToUpdate.Name = "New name";
            var actualResult = await carService.Update(2, carToUpdate);
            
            //Assert
            contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void GetAll_Success()
        {
            //Arrange
            var context = new Mock<LeasingCarsDbContext>();
            var factory = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var cars = new List<Car>()
            {
                new()
                {
                    Id = 1,
                    Name = "Lada",
                    Mileage = 100,
                    Number = "e111ee",
                    TypeId = 1,
                    StatusId = 1,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                },
                new()
                {
                    Id = 2,
                    Name = "BMW",
                    Mileage = 200,
                    Number = "e222ee",
                    TypeId = 2,
                    StatusId = 2,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                },
                new()
                {
                    Id = 1,
                    Name = "Renault",
                    Mileage = 300,
                    Number = "e333ee",
                    TypeId = 3,
                    StatusId = 3,
                    Type = new LeasingCarsWPF.Models.Type(),
                    Status = new Status()
                }
            };

            var carsMock = cars.AsQueryable().BuildMockDbSet();
            context.Setup(c => c.Set<Car>()).Returns(carsMock.Object);
            factory.Setup(f => f.CreateDbContext()).Returns(context.Object);

            IDataService<Car> carService = new DataService<Car>(factory.Object);
            
            //Act
            var result = await carService.GetAll();
            
            //Assert
            Assert.All(result, Assert.NotNull);
        }

        [Fact]
        public async void Get_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var positions = new List<Position>()
            {
                new Position() {Id = 1, PositionName = "Admin"},
                new Position() {Id = 2, PositionName = "Mecha"},
                new Position() {Id = 3, PositionName = "Hr"}
            };
            var positionsMock = positions.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Position>())
                .Returns(positionsMock.Object);
            factoryMock.Setup(f => f.CreateDbContext())
                .Returns(contextMock.Object);
            IDataService<Position> service = new DataService<Position>(factoryMock.Object);
            
            //Act
            var actualResult = await service.Get(2);
            
            //Assert
            Assert.Equal(positions[1], actualResult);
        }

        [Fact]
        public async void Add_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var positions = new List<Position>()
            {
                new Position() {Id = 1, PositionName = "Admin"},
                new Position() {Id = 2, PositionName = "Mecha"},
                new Position() {Id = 3, PositionName = "Hr"}
            };
            var positionsMock = positions.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Position>())
                .Returns(positionsMock.Object);
            factoryMock.Setup(f => f.CreateDbContext())
                .Returns(contextMock.Object);
            IDataService<Position> service = new DataService<Position>(factoryMock.Object);
            var newPosition = new Position() {Id = 4, PositionName = "New Position"};
            
            //Act
            await service.Add(newPosition);
            
            //Assert
            contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async void Delete_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var positions = new List<Position>()
            {
                new Position() {Id = 1, PositionName = "Admin"},
                new Position() {Id = 2, PositionName = "Mecha"},
                new Position() {Id = 3, PositionName = "Hr"}
            };
            var positionsMock = positions.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Position>())
                .Returns(positionsMock.Object);
            factoryMock.Setup(f => f.CreateDbContext())
                .Returns(contextMock.Object);
            IDataService<Position> service = new DataService<Position>(factoryMock.Object);
            
            //Act
            await service.Delete(1);
            
            //Assert
            contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async void GetWithInclude_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var cars = new List<Car>()
            {
                new()
                {
                    Id = 1,
                    Name = "Lada",
                    Mileage = 100,
                    Number = "e111ee",
                    TypeId = 1,
                    StatusId = 1,
                    Type = new LeasingCarsWPF.Models.Type() {Id = 1, TypeName = "Type1"},
                    Status = new Status() {Id = 1, StatusName = "Status1"}
                },
                new()
                {
                    Id = 2,
                    Name = "BMW",
                    Mileage = 200,
                    Number = "e222ee",
                    TypeId = 2,
                    StatusId = 2,
                    Type = new LeasingCarsWPF.Models.Type() {Id = 2, TypeName = "Type2"},
                    Status = new Status() {Id = 2, StatusName = "Status2"}
                },
                new()
                {
                    Id = 1,
                    Name = "Renault",
                    Mileage = 300,
                    Number = "e333ee",
                    TypeId = 3,
                    StatusId = 3,
                    Type = new LeasingCarsWPF.Models.Type() {Id = 3, TypeName = "Type3"},
                    Status = new Status() {Id = 3, StatusName = "Status3"}
                }
            };
            var carsMock = cars.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Car>())
                .Returns(carsMock.Object);
            factoryMock.Setup(f => f.CreateDbContext())
                .Returns(contextMock.Object);
            IDataService<Car> service = new DataService<Car>(factoryMock.Object);
            
            //Act
            var actualResult = await service.GetWithInclude(c => c.Type, c => c.Status);
            
            //Assert
            Assert.Collection(actualResult,  
                c1 => Assert.Equal(cars[0].Type.Id, c1.Type.Id),
                c2 => Assert.Equal(cars[1].Type.Id, c2.Type.Id),
                c3 => Assert.Equal(cars[2].Type.Id, c3.Type.Id));
            
        }

        [Fact]
        public void Get_WithPredicate_Success()
        {
            //Arrange
            var contextMock = new Mock<LeasingCarsDbContext>();
            var factoryMock = new Mock<IDbContextFactory<LeasingCarsDbContext>>();
            var cars = new List<Car>()
            {
                new()
                {
                    Id = 1,
                    Name = "Lada",
                    Mileage = 100,
                    Number = "e111ee",
                    TypeId = 1,
                    StatusId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Lada",
                    Mileage = 200,
                    Number = "e222ee",
                    TypeId = 1,
                    StatusId = 1
                },
                new()
                {
                    Id = 1,
                    Name = "Renault",
                    Mileage = 300,
                    Number = "e333ee",
                    TypeId = 3,
                    StatusId = 3
                }
            };
            var carsMock = cars.AsQueryable().BuildMockDbSet();

            contextMock.Setup(c => c.Set<Car>())
                .Returns(carsMock.Object);
            factoryMock.Setup(f => f.CreateDbContext())
                .Returns(contextMock.Object);
            IDataService<Car> service = new DataService<Car>(factoryMock.Object);
            
            //Act
            var actualResult = service.Get(c => c.Name.Equals("Lada"));
            
            //Assert
            Assert.Equal(2, actualResult.Count);
        }
    }
}