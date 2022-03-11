using System.Collections.Generic;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
