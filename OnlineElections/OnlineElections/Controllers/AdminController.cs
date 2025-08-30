using OnlineElections.Data;
using OnlineElections.Models;
using OnlineElections.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineElections.Controllers
{
    public class AdminController : Controller
    {
        private  readonly ElectionDbContext db =new ElectionDbContext();
         // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            using (var context = new ElectionDbContext())
            {
                bool isValid = context.Admins.Any(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(admin.AdminName, false);
                    return RedirectToAction("ConfirmLogin");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }
        public ActionResult ConfirmLogin()
        {
            return View();
        }


        public ActionResult VoterList()
        {
            return View(db.Voters.ToList());
        }
        public ActionResult EditVoterList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVoterList([Bind(Include = "VoterId,Name,FatherName,Age,Gender,AadhaarNo,PanNo,City,Religion,EmailId,MobileNo,Password")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VoterList");
            }
            return View(voter);
        }

        public ActionResult VoterDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        public ActionResult DeleteVoter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Employees/Delete/5
        [HttpPost,ActionName("DeleteVoter")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVoterConfirmed(int id)
        {
            Voter voter = db.Voters.Find(id);
            db.Voters.Remove(voter);
            db.SaveChanges();
            return RedirectToAction("VoterList");
        }
        public ActionResult CandidateList()
        {
            return View(db.Candidates.ToList());
        }


        public ActionResult EditCandidateList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCandidateList([Bind(Include = "CandidateID,VoterId,PartyName")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CandidateList");
            }
            return View(candidate);
        }


        public ActionResult CandidateDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }
        public ActionResult DeleteCandidate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("DeleteCandidate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCandidateConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("CandidateList");
        }


        public ActionResult ConductElection()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ConductElection(Election election) 
        {
            using (var context = new ElectionDbContext())
            {
                context.Elections.Add(election);
                context.SaveChanges();
            }
            return RedirectToAction("ConfirmLogin", election);
        }


        public ActionResult VotingStatus()
        {
            var model = from voter in db.Voters
                        join result in db.Results on voter.VoterId equals result.VoterId into gj
                        from subresult in gj.DefaultIfEmpty()
                        select new VotingStatusViewModel
                        {
                            VoterId = voter.VoterId,
                            Name = voter.Name,
                            HasVoted = subresult != null
                        };
            return View(model.ToList());
        }
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



    }

}