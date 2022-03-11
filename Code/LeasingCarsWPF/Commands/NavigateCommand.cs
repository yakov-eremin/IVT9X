using LeasingCarsWPF.Services;

namespace LeasingCarsWPF.Commands
{
    public class NavigateCommand<TParameter> : BaseCommand
    {
        NavigationService<TParameter> _navigationService;

        public NavigateCommand(NavigationService<TParameter> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null)
                _navigationService.Navigate();
            else
                _navigationService.Navigate((TParameter)parameter);
        }
    }
}
