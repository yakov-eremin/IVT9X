using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeasingCarsWPF.ViewModels
{
    public class ListingCarsVM : BaseVM
    {
        IEnumerable<ListingCarsVM>? _items;
        private long _id;
        private string _name;
        private double _mileage;
        private string _number;
        private string _status;
        private string _type;
        private Car _model;

        public ListingCarsVM()
        {
            Initialize();
        }

        private void Initialize()
        {
            _model = new Car();
            _items = new List<ListingCarsVM>(_model.GetCars().Select(c => new ListingCarsVM(c)));
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
        public IEnumerable<ListingCarsVM> Items => _items;
    }
}
