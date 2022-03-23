using LeasingCarsWPF.Models;
using System.Collections.Generic;
using System.Linq;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.ViewModels
{
    public class StatisticsVM : BaseVM
    {
        private Stat _model;
        private readonly IDataService<Stat> _dataService;

        public StatisticsVM(IDataService<Stat> dataService)
        {
            _dataService = dataService;
            Initialize();
        }

        public StatisticsVM(Stat stat)
        {
            Id = stat.Id;
            Mark = stat.Mark;
            EmployeeId = stat.EmployeeId;
            OrderId = stat.OrderId;
        }

        public async void Initialize()
        {
            _model = new Stat();
            Items = new List<StatisticsVM>((await _dataService.GetAll()).Select(s => new StatisticsVM(s)));
        }


        public List<StatisticsVM> Items { get; set; }

        public long Id { get; set; }
        public int Mark { get; set; }
        public long? EmployeeId { get; set; }
        public long? OrderId { get; set; }
    }
}