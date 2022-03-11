using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        private List<Status> _statuses;
        private long _statusId;
        private long _typeId;
        private ChangeCarStatusVM _currentItem;

        public ChangeCarStatusVM()
        {
            _model = new Car();
            Items = new ObservableCollection<ChangeCarStatusVM>(_model.GetCars()
                .Select(c => new ChangeCarStatusVM(c)));
            Statuses = new Status().GetStatuses();
        }

        public ChangeCarStatusVM(Car car)
        {
            _id = car.Id;
            _name = car.Name;
            _mileage = car.Mileage;
            _number = car.Number;
            Status = car.Status;
            _type = car.Type;
            _typeId = car.TypeId;
            _statusId = car.StatusId;
        }

        public long Id => _id;
        public string Name => _name;
        public string Number => _number;
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

        public List<Status> Statuses { get; set; }
        public ChangeCarStatusVM CurrentItem { get; set; }
        public ObservableCollection<ChangeCarStatusVM> Items { get; set; }
        public RelayCommand UpdateCarCommand => new RelayCommand(UpdateCar);

        private void UpdateCar()
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
            _model.UpdateCar(car);
        }
    }
}