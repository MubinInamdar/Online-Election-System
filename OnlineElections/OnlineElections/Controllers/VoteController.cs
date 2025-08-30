using OnlineElections.Data;
using OnlineElections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineElections.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult VoteLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VoteLogin(Voter voter)
        {
            using (var context = new ElectionDbContext())
            {
                bool isValid = context.Voters.Any(x => x.Name == voter.Name && x.Password == voter.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(voter.Name, false);
                    return RedirectToAction("Voting");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }
        public ActionResult Voting()
        {
            
            using (var context = new ElectionDbContext())
            {
                ViewBag.PartyName = new SelectList(context.Elections.Select(p => new { p.PartyName, p.EelectionId  }).ToList(), "EelectionId", "PartyName");
                var voterId = context.Voters.Where(v => v.Name == User.Identity.Name).Select(v => v.VoterId).FirstOrDefault();
                ViewBag.VoterId = voterId;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Voting(Result result)
        {
            




            using (var context = new ElectionDbContext())
            {
                var existingVote = context.Results.FirstOrDefault(r => r.VoterId == result.VoterId);
                if (existingVote != null)
                {
                    // If a vote from this user already exists, inform the user
                    ViewBag.Message = "You have already voted.";
                    return RedirectToAction("AlreadyVoted");
                }
                var partyName = context.Elections.Where(e => e.EelectionId == result.EelectionId).Select(e => e.PartyName).FirstOrDefault();
                result.PartyName = partyName;
                context.Results.Add(result);
                context.SaveChanges();
            }
            // using (var context = new ElectionDbContext())
            //{

            //context.Results.Add(result);
            //context.SaveChanges();


            // }
            return RedirectToAction("ConfirmVoting", result);
        }

        [HttpGet]
        public ActionResult AlreadyVoted()
        {
            return View();
        }
        public ActionResult ConfirmVoting()
        {
            return View();
        }
    }
}