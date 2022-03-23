using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System;
using System.Collections.Generic;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.ViewModels
{
    public class OrderVM : BaseVM
    {
        private Order _model;
        private Car _selectedCar;
        private IEnumerable<Car> _cars;
        private Employee _employee;
        private readonly IDataService<Order> _dataService;
        private readonly IDataService<Car> _carDataService;

        public OrderVM(IDataService<Order> dataService, IDataService<Car> carDataService)
        {
            _dataService = dataService;
            _carDataService = carDataService;
            Initialize();
        }

        public OrderVM(Employee employee, IDataService<Order> dataService, IDataService<Car> carDataService)
        {
            _employee = employee;
            _dataService = dataService;
            _carDataService = carDataService;
            Initialize();
        }

        public async void Initialize()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            MiddleName = string.Empty;
            Bday = DateTime.Now;
            Passport = string.Empty;
            LicenseNumber = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            IsDeliveryNeeded = false;
            _model = new Order();
            _selectedCar = new Car();
            _cars = await _carDataService.GetWithInclude(c => c.Status, c => c.Type);
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Bday {private get; set; }
        public string Passport { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsDeliveryNeeded { get; set; }

        public Car SelectedCar
        {
            get => _selectedCar;
            set => _selectedCar = value;
        }

        public IEnumerable<Car> Cars => _cars;

        public RelayCommand AddOrderCommand => new RelayCommand(AddOrder);
        private async void AddOrder()
        {
            Order newOrder = new Order(
                FirstName,
                SecondName,
                MiddleName, 
                Bday, 
                Passport, 
                LicenseNumber, 
                PhoneNumber, 
                Address, 
                IsDeliveryNeeded, 
                _employee.Id,
                _selectedCar.Id);
            await _dataService.Add(newOrder);
        }
    }
}
