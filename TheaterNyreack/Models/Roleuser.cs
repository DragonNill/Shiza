using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class Roleuser
    {
        public Roleuser()
        {
            Users = new HashSet<User>();
        }

        public int RoleUserId { get; set; }
        public string? RoleUserName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
