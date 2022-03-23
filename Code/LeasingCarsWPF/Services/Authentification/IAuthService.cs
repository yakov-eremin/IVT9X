using System.Threading.Tasks;
using LeasingCarsWPF.Models;

namespace LeasingCarsWPF.Services.Authentification
{
    public interface IAuthService
    {
        public Task<Employee> Auth(string username, string password);
    }
}