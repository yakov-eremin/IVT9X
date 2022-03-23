using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Car : BaseModel
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

        public string Name { get; set; }
        public double Mileage { get; set; }
        public string Number { get; set; }
        public long TypeId { get; set; }
        public long StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}