using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineElections.ViewModel
{
    public class VotingStatusViewModel
    {
        public int VoterId { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }

    }
}