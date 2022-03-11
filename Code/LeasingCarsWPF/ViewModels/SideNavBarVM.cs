using LeasingCarsWPF.Commands;
using LeasingCarsWPF.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace LeasingCarsWPF.ViewModels
{
    public class SideNavBarVM : BaseVM
    {
        private static List<SideNavBarVM> _items;
        private string _name;

        public SideNavBarVM() { }

        public SideNavBarVM(List<SideNavBarVM> items)
        {
            Items = items;
            items[0].IsChecked = true;
        }

        public SideNavBarVM(string name,
            NavigationService<string> navigationService)
        {
            Name = name;

            NavigateCommand = new NavigateCommand<string>(navigationService);
            IsChecked = false;
        }

        public List<SideNavBarVM> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string EmployeeFullName { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ICommand NavigateCommand { get; }
    }
}