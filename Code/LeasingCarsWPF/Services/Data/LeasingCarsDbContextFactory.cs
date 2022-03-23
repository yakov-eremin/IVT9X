using LeasingCarsWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace LeasingCarsWPF.Services.Data
{
    public class LeasingCarsDbContextFactory : IDbContextFactory<LeasingCarsDbContext>
    {
        public LeasingCarsDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeasingCarsDbContext>();
            optionsBuilder.UseSqlServer("Server=ANTON-PC;Database=leasing_cars_db;Trusted_Connection=True;");
            return new LeasingCarsDbContext(optionsBuilder.Options);
        }
    }
}