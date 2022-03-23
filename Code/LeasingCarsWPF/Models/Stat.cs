using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Stat : BaseModel
    {
        public int Mark { get; set; }
        public long? EmployeeId { get; set; }
        public long? OrderId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Order Order { get; set; }
    }
}