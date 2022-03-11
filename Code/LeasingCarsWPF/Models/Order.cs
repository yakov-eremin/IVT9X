using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Order
    {
        public Order()
        {
            Stats = new HashSet<Stat>();
        }

        public Order(
            string firstName, 
            string secondName, 
            string middleName, 
            DateTime bday, 
            string passport, 
            string licenseNumber, 
            string phoneNumber, 
            string address, 
            bool isDeliveryNeeded, 
            long? employeeId, 
            long? carId)
        {
            FirstName = firstName;
            SecondName = secondName;
            MiddleName = middleName;
            Bday = bday;
            Passport = passport;
            LicenseNumber = licenseNumber;
            PhoneNumber = phoneNumber;
            Address = address;
            IsDeliveryNeeded = isDeliveryNeeded;
            EmployeeId = employeeId;
            CarId = carId;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Bday { get; set; }
        public string Passport { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsDeliveryNeeded { get; set; }
        public long? EmployeeId { get; set; }
        public long? CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Stat> Stats { get; set; }

        public void AddOrder(Order order)
        {
            using (var context = new LeasingCarsDbContext())
            {
                order.Id = context.Orders.ToList().Max(o => o.Id) + 1;
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}