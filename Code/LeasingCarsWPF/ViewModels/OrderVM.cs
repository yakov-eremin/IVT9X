using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System;
using System.Collections.Generic;

namespace LeasingCarsWPF.ViewModels
{
    public class OrderVM : BaseVM
    {
        private Order _model;
        private Car _selectedCar;
        private IEnumerable<Car> _cars;
        private Employee _employee;

        public OrderVM()
        {
            Initialize();
        }

        public OrderVM(Employee employee)
        {
            _employee = employee;
            Initialize();
        }

        public void Initialize()
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
            _cars = _selectedCar.GetCars();
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
        private void AddOrder()
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
            _model.AddOrder(newOrder);
        }
    }
}
