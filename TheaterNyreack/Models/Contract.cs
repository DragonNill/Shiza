using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int? ContractActorId { get; set; }
        public int? ContractDirectorId { get; set; }
        public int? ContractShowId { get; set; }
        public int? ContractStatusId { get; set; }
        public int? ContractFee { get; set; }

        public virtual User? ContractActor { get; set; }
        public virtual User? ContractDirector { get; set; }
        public virtual Show? ContractShow { get; set; }
        public virtual Contractstatus? ContractStatus { get; set; }
    }
}
