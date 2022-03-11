using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Models;
using System.Windows.Input;

namespace LeasingCarsWPF.ViewModels
{
    public class OrderSpareVM : BaseVM
    {
        private Employee _employee;
        private OrderedSparse _model;

        public OrderSpareVM(Employee employee)
        {
            _employee = employee;
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
            _model.AddOrderedSpare(orderedSparse);
        }
    }
}
