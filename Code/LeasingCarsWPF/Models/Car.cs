using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        public Car(
            long id,
            string name, 
            double mileage, 
            string number, 
            long typeId, 
            long statusId, 
            Status status, 
            Type type)
        {
            Id = id;
            Name = name;
            Mileage = mileage;
            Number = number;
            TypeId = typeId;
            StatusId = statusId;
            Status = status;
            Type = type;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public double Mileage { get; set; }
        public string Number { get; set; }
        public long TypeId { get; set; }
        public long StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public IEnumerable<Car> GetCars()
        {
            IEnumerable<Car> cars;
            using (var context = new LeasingCarsDbContext())
            {
                cars = context.Cars.Include(c => c.Status)
                    .Include(c => c.Type).ToList();
            }

            return cars;
        }

        public void UpdateCar(Car car)
        {
            using (var context = new LeasingCarsDbContext())
            {
                Car carToUpdate = context.Cars.FirstOrDefault(c => c.Id == car.Id);
                if (carToUpdate == null) return;
                carToUpdate.Name = car.Name;
                carToUpdate.Mileage = car.Mileage;
                carToUpdate.Number = car.Number;
                carToUpdate.TypeId = car.TypeId;
                carToUpdate.StatusId = car.StatusId;
                context.Cars.Update(carToUpdate);
                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}