using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.ViewModels
{
    public class ChangeCarStatusVM : BaseVM
    {
        private Car _model;
        private ObservableCollection<ChangeCarStatusVM> _items;
        private long _id;
        private string _name;
        private double _mileage;
        private string _number;
        private Status _status;
        private Type _type;
        private ObservableCollection<Status> _statuses;
        private long _statusId;
        private long _typeId;
        private ChangeCarStatusVM _currentItem;
        private IDataService<Car> _carDataService;
        private IDataService<Status> _statusDataService;

        public ChangeCarStatusVM(IDataService<Car> carDataService, IDataService<Status> statusDataService)
        {
            _model = new Car();
            _carDataService = carDataService;
            _statusDataService = statusDataService;
            Initialize();

        }

        private async void Initialize()
        {
            Items = new ObservableCollection<ChangeCarStatusVM>((await _carDataService.GetWithInclude(c => c.Status, c => c.Type))
                .Select(c => new ChangeCarStatusVM(c)));
            Statuses = new ObservableCollection<Status>((await _statusDataService
                .GetAll())
                .Select(s => new Status()
                {
                    Id = s.Id,
                    StatusName = s.StatusName
                }));
        }

        public ChangeCarStatusVM(Car car)
        {
            _model = car;
            _id = car.Id;
            Name = car.Name;
            Mileage = car.Mileage;
            Number = car.Number;
            Status = car.Status;
            Type = car.Type;
            TypeId = car.TypeId;
            StatusId = car.StatusId;
        }

        public long TypeId { get; set; }

        public Type Type { get; set; }

        public double Mileage { get; set; }

        public long Id => _id;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public long StatusId
        {
            get => _statusId;
            set
            {
                _statusId = value;
                OnPropertyChanged();
            }
        }
        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Status> Statuses
        {
            get => _statuses;
            set
            {
                _statuses = value;
                OnPropertyChanged();
            }
        }
        
        public ChangeCarStatusVM CurrentItem { get; set; }

        public ObservableCollection<ChangeCarStatusVM> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand UpdateCarCommand => new RelayCommand(UpdateCar);

        private async void UpdateCar()
        {
            Car car = new Car(
                CurrentItem.Id,
                CurrentItem.Name, 
                CurrentItem._mileage, 
                CurrentItem.Number, 
                CurrentItem._typeId,
                CurrentItem.StatusId,
                CurrentItem.Status, 
                CurrentItem._type);
            var carToUpdate = Items.FirstOrDefault(c => c.Id == CurrentItem.Id)._model;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ChangeCarStatusVM, Car>().ForMember(c => c.Id, o => o.Ignore()));
            var mapper = new Mapper(config);
            carToUpdate = mapper.Map<Car>(CurrentItem);
            await _carDataService.Update(car.Id, carToUpdate);
        }
    }
}