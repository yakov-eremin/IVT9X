using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class OrderedSparse : BaseModel
    {
        public string SparseName { get; set; }
        public int Count { get; set; }
        public long? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public OrderedSparse(string sparseName, int count, long? employeeId)
        {
            SparseName = sparseName;
            Count = count;
            EmployeeId = employeeId;
        }

        public OrderedSparse()
        {

        }
    }
}
