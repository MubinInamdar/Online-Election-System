using OnlineElections.Data;
using OnlineElections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElections.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter
        public ActionResult VoterRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VoterRegistration(Voter voter)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            using (var context = new ElectionDbContext())
            {
                var existingVoter = context.Voters.FirstOrDefault(r => r.AadhaarNo == voter.AadhaarNo ||r.PanNo==voter.PanNo);
                if (existingVoter != null)
                {
                    // If a vote from this user already exists, inform the user
                    ViewBag.Message = "You have already voted.";
                    return RedirectToAction("AlreadyRegistered");
                }
                context.Voters.Add(voter);
                context.SaveChanges();
            }
            return RedirectToAction("ConfirmVoterRegistration", voter);
        }
        public ActionResult AlreadyRegistered()
        {
            return View();
        }
        public ActionResult ConfirmVoterRegistration(Voter voter)
        {
            using (var context = new ElectionDbContext())
            {
                Voter obj = context.Voters.FirstOrDefault(u => u.VoterId == voter.VoterId);
                return View(obj);
            }

        }
    }
}