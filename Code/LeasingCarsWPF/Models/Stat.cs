using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Stat
    {
        public long Id { get; set; }
        public int Mark { get; set; }
        public long? EmployeeId { get; set; }
        public long? OrderId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Order Order { get; set; }

        public List<Stat> GetStats()
        {
            List<Stat> stats;
            using (var context = new LeasingCarsDbContext())
            {
                stats = context.Stats.ToList();
            }
            return stats;
        }
    }
}