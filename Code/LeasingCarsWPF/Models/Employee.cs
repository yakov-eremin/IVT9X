using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Employee : BaseModel
    {
        public Employee()
        {
            OrderedSparses = new HashSet<OrderedSparse>();
            Orders = new HashSet<Order>();
            Stats = new HashSet<Stat>();
        }

        public string FirstName { get; set; }
        public long PositionId { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<OrderedSparse> OrderedSparses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Stat> Stats { get; set; }
    }
}