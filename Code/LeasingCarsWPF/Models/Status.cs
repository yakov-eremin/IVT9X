using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LeasingCarsWPF.Models
{
    public partial class Status
    {
        public Status()
        {
            Cars = new HashSet<Car>();
        }

        public long Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public List<Status> GetStatuses()
        {
            List<Status> statuses;
            using (var context = new LeasingCarsDbContext())
            {
                statuses = context.Statuses.ToList();
            }
            return statuses;
        }
    }
}