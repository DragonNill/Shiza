using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class Contractstatus
    {
        public Contractstatus()
        {
            Contracts = new HashSet<Contract>();
        }

        public int ContractStatusId { get; set; }
        public string? ContractStatusName { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
