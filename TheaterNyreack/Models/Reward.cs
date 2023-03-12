using System;
using System.Collections.Generic;

namespace TheaterNyreack.Models
{
    public partial class Reward
    {
        public int RewardsId { get; set; }
        public int? RewardUserId { get; set; }
        public string? RewardName { get; set; }

        public virtual User? RewardUser { get; set; }
    }
}
