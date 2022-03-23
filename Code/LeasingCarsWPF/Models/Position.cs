using System.Collections.Generic;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Position : BaseModel
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public string PositionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
