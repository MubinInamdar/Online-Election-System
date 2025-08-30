using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineElections.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Required]
        public int VoterId { get; set; }

        [Required(ErrorMessage = "Party's Name is required")]
        public string PartyName { get; set; }

        [ForeignKey("VoterId")]
        public virtual Voter Voter { get; set; }

        
    }
}