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
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult CandidateLogin()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult CandidateLogin(Voter voter)
        {
            using (var context = new ElectionDbContext())
            {
                bool isValid = context.Voters.Any(x => x.Name == voter.Name && x.Password == voter.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(voter.Name, false);
                    return RedirectToAction("CandidateRegistration");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }




        public ActionResult CandidateRegistration()
        {
           
            if (!ModelState.IsValid)
            {
                return View();
            }

                using (var context = new ElectionDbContext())
                {
                    
                    var voterId = context.Voters.Where(v => v.Name == User.Identity.Name).Select(v => v.VoterId).FirstOrDefault();
                    ViewBag.VoterId = voterId;
                }
                return View();
            
        }

        [HttpPost]
        public ActionResult CandidateRegistration(Candidate candidate)
        {
            using (var context = new ElectionDbContext())
            {
                context.Candidates.Add(candidate);
                context.SaveChanges();
            }
            return RedirectToAction("ConfirmCandidateRegistration", candidate);
            
        }
        public ActionResult ConfirmCandidateRegistration(Candidate candidate)
        {
            using (var context = new ElectionDbContext())
            {
                Candidate obj = context.Candidates.FirstOrDefault(u => u.CandidateID == candidate.CandidateID);
                return View(obj);
            }

        }
    }
}