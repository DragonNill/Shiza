using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class User
    {
        public User()
        {
            ContractContractActors = new HashSet<Contract>();
            ContractContractDirectors = new HashSet<Contract>();
            Rewards = new HashSet<Reward>();
        }

        public int UserId { get; set; }
        public int? UserRoleId { get; set; }
        public string? UserLogin { get; set; }
        public string? UserPassword { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? UserPatronimyc { get; set; }

        public virtual Roleuser? UserRole { get; set; }
        public virtual ICollection<Contract> ContractContractActors { get; set; }
        public virtual ICollection<Contract> ContractContractDirectors { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
