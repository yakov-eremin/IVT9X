using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.ViewModels
{
    public class ListingCarsVM : BaseVM
    {
        ObservableCollection<ListingCarsVM>? _items;
        private long _id;
        private string _name;
        private double _mileage;
        private string _number;
        private string _status;
        private string _type;
        private Car _model;
        private IDataService<Car> _dataService;

        public ListingCarsVM(IDataService<Car> dataService)
        {
            _dataService = dataService;
            Initialize();
        }

        private async void Initialize()
        {
            _model = new Car();
            
            Items = new ObservableCollection<ListingCarsVM>((await _dataService
                .GetWithInclude(c => c.Status, c => c.Type))
                .Select(c => new ListingCarsVM(c)));
        }

        public ListingCarsVM(Car car)
        {
            _id = car.Id;
            _name = car.Name;
            _mileage = car.Mileage;
            _number = car.Number;
            _status = car.Status.StatusName;
            _type = car.Type.TypeName;
        }

        public long Id => _id;
        public string Name => _name;
        public double Mileage => _mileage;
        public string Number => _number;
        public string Status => _status;
        public string Type => _type;

        public ObservableCollection<ListingCarsVM> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    }
}
