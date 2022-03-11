using System.Collections.Generic;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Type
    {
        public Type()
        {
            Cars = new HashSet<Car>();
        }

        public long Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}