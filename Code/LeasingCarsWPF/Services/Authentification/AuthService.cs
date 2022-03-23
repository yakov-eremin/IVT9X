using System;
using System.Threading.Tasks;
using LeasingCarsWPF.Models;
using LeasingCarsWPF.Services.Data;

namespace LeasingCarsWPF.Services.Authentification
{
    public class AuthService : IAuthService
    {
        private IDataService<Employee> _dataService;

        public AuthService(IDataService<Employee> dataService)
        {
            _dataService = dataService;
        }

        public async Task<Employee> Auth(string username, string password)
        {
            var emp = await _dataService.FirsOrDefault(e => e.Username.Equals(username) && e.Password.Equals(password));
            if (emp == null) throw new Exception("Пользователь не найдет. Проверьте логин или пароль");
            return emp;
        }
        
        
    }
}