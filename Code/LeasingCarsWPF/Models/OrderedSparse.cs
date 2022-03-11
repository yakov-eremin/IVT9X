using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class OrderedSparse
    {
        public long Id { get; set; }
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

        public void AddOrderedSpare(OrderedSparse orderedSpare)
        {
            using (var context = new LeasingCarsDbContext())
            {
                orderedSpare.Id = context.OrderedSparses.ToList().Max(o => o.Id) + 1;
                context.OrderedSparses.Add(orderedSpare);
                context.SaveChanges();
            }
        }
    }
}
