using OnlineElections.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineElections.ViewModel
{
    public class ElectionResultViewModel
    {
        [Required(ErrorMessage = "Select Party Name")]
        public string PartyName { get; set; }
        public int VoteCount { get; set; }

    }
}