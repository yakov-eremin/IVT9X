using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Status : BaseModel
    {
        public Status()
        {
            Cars = new HashSet<Car>();
        }

        public string StatusName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}