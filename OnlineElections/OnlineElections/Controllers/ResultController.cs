using OnlineElections.Data;
using OnlineElections.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElections.Controllers
{
    public class ResultController : Controller
    {
        private ElectionDbContext db = new ElectionDbContext();
        // GET: Result
        public ActionResult Parties()
        {
            return View();
        }



        // GET: Result
        public ActionResult DisplayResult()
        {
            var results = db.Results
            .GroupBy(r => r.PartyName)
            .Select(g => new ElectionResultViewModel
            {
                PartyName = g.Key,
                VoteCount = g.Count()
            })
            .ToList();
            var winningParty = results.OrderByDescending(r => r.VoteCount).First();

            ViewBag.WinningParty = winningParty.PartyName;
            ViewBag.WinningVotes = winningParty.VoteCount;

            return View(results);
        }
    }
}