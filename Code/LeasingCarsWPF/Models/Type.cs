using System.Collections.Generic;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Type : BaseModel
    {
        public Type()
        {
            Cars = new HashSet<Car>();
        }

        public string TypeName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}