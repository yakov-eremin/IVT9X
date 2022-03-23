using System;
using System.Windows;
using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services;
using LeasingCarsWPF.Services.Authentification;
using LeasingCarsWPF.ViewModels;


namespace LeasingCarsWPF.Commands
{
    public class LoginCommand<TParameter> : BaseCommand
        where TParameter : Employee
    {
        private LoginVM _vm;
        private NavigationService<TParameter> _navigationService;
        private IAuthService _authService;

        public LoginCommand(LoginVM vm, NavigationService<TParameter> navigationService, IAuthService authService)
        {
            _vm = vm;
            _navigationService = navigationService;
            _authService = authService;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                var emp = await _authService.Auth(_vm.Username, _vm.Password);
                _navigationService.Navigate((TParameter)emp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}