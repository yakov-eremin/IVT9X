using System.Collections.Generic;
using System.Threading.Tasks;
using LeasingCarsWPF.Models;

namespace LeasingCarsWPF.Services.Data
{
    public interface ICarService
    {
        public Task<List<Car>> GetAllCarsWithInfo();
    }
}