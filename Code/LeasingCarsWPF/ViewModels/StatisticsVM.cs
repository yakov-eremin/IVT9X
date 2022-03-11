using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeasingCarsWPF.ViewModels
{
    public class StatisticsVM : BaseVM
    {
        private Stat _model;

        public StatisticsVM()
        {
            Initialize();
        }

        public StatisticsVM(Stat stat)
        {
            Id = stat.Id;
            Mark = stat.Mark;
            EmployeeId = stat.EmployeeId;
            OrderId = stat.OrderId;
        }

        public void Initialize()
        {
            _model = new Stat();
            Items = new List<StatisticsVM>(_model.GetStats().Select(s => new StatisticsVM(s)));
        }


        public List<StatisticsVM> Items { get; set; }

        public long Id { get; set; }
        public int Mark { get; set; }
        public long? EmployeeId { get; set; }
        public long? OrderId { get; set; }
    }
}