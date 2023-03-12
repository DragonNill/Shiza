using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class Show
    {
        public Show()
        {
            Contracts = new HashSet<Contract>();
        }

        public int ShowId { get; set; }
        public string? ShowName { get; set; }
        public int? ShowBudget { get; set; }
        public string? ShowDescription { get; set; }
        public DateTime? ShowData { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
