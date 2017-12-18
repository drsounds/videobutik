using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videobutik.Models;
using Microsoft.AspNet.Identity;

namespace Videobutik.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
                String userId = User.Identity.GetUserId();
                var allRents = (from r in db.Rents where r.UserId == userId select r).ToList();
                var rents = allRents.Where(r => !r.IsReturned).ToList();
                var returns = allRents.Where(r => r.IsReturned).ToList();
                ViewBag.Returns = new List<Rent>();
                ViewBag.Rents = new List<Rent>();
                ViewBag.Rents = rents;
                ViewBag.Returns = returns;
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}