using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System.Windows.Input;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.ViewModels
{
    public class OrderSpareVM : BaseVM
    {
        private Employee _employee;
        private OrderedSparse _model;
        private IDataService<OrderedSparse> _dataService;

        public OrderSpareVM(Employee employee, IDataService<OrderedSparse> dataService)
        {
            _employee = employee;
            _dataService = dataService;
            Initialize();
        }

        private void Initialize()
        {
            _model = new OrderedSparse();
            SpareName = string.Empty;
            SpareCount = 1;
        }

        public string SpareName { get; set; }
        public int SpareCount { get; set; }

        public ICommand AddOrderedSpareCommand => new RelayCommand(addOrderedSpare);

        private void addOrderedSpare()
        {
            OrderedSparse orderedSparse = new OrderedSparse(SpareName, SpareCount, _employee.Id);
            _dataService.Add(orderedSparse);
        }
    }
}
