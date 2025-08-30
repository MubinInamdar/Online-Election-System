using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineElections.Models
{
    public class Election
    {
        [Key]
        [Required(ErrorMessage = "Select Party Name")]
        public int EelectionId { get; set; }
        [Required]
        public string EelectionName { get; set; }
        [Required]
        public string PartyName { get; set; }
    }
}