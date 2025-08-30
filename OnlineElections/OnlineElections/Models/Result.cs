using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineElections.Models
{
    public class Result
    {
        [Key]
        [Required]
        public int ResultId { get; set; }
        [Required]
        [ForeignKey("Election")]
        public int EelectionId { get; set; }
        [Required]
        [ForeignKey("Voter")]
        public int VoterId { get; set; }

        public string PartyName { get; set; }
        public virtual Election Election { get; set; }

        public virtual Voter Voter { get; set; }
    }
}