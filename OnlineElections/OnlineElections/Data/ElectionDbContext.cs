using OnlineElections.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineElections.Data
{
    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext() : base("name=ElectionConnection") { }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Election> Elections { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}