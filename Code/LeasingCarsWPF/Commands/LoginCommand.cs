using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services;
using LeasingCarsWPF.ViewModels;


namespace LeasingCarsWPF.Commands
{
    public class LoginCommand<TParameter> : BaseCommand
        where TParameter : Employee
    {
        private LoginVM _vm;
        private NavigationService<TParameter> _navigationService;

        public LoginCommand(LoginVM vm, NavigationService<TParameter> navigationService)
        {
            _vm = vm;
            _navigationService = navigationService;
        }

        public override async void Execute(object? parameter)
        {
            Employee? emp = new Employee();
            emp = await emp.GetEmployeeAsync(_vm.Username, _vm.Password, (int)parameter);
            if (emp != null)
                _navigationService.Navigate((TParameter)emp);
        }
    }
}