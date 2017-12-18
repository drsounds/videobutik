using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Videobutik.Models;

namespace Videobutik.Controllers
{
    public class RentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public delegate IOrderedQueryable<TSource> OrderByFunc<TSource, TKey>( Expression<Func<TSource, TKey>> keySelector);
        // GET: Rents
        public ActionResult Index()
        {
            var rents = db.Rents.Include(r => r.Movie);
            if (Request.QueryString["userId"] != null)
            {
                String userId = Request.QueryString["userId"];
                rents = rents.Where(r => r.UserId == userId);
            }
            if (Request.QueryString["movieId"] != null)
            {
                try
                {
                    int movieId = int.Parse(Request.QueryString["movieId"]);
                    rents = rents.Where(r => r.MovieId == movieId);
                } catch (Exception e)
                {

                }
            }
            string sort = "asc";
            if (Request.QueryString["sort"] != null)
            {
                sort = Request.QueryString["sort"];
            }
            ViewBag.Sort = String.IsNullOrEmpty(sort) ? "" : sort;
            bool ascending = true;
            if (Request.QueryString["ascending"] != null)
            {
                try
                {
                    ascending = bool.Parse(Request.QueryString["ascending"]);
                } catch (ArgumentNullException e) {
                } catch (FormatException e)
                {
                    ascending = false;
                }
            }
            ViewBag.Ascending = ascending;

            // Earlier in the course, the teacher demonstrated the use of delegates, so I use it
            // To simplicate the implemention of ascending / descending function in order by using delegate

            OrderByFunc<Rent, object> t = rents.OrderBy;
            if (!ascending)
            {
                t = rents.OrderByDescending;
            }
            switch (sort)
            {
                case "movie":
                    
                    rents = t(r => r.Movie.Name);
                    break;
                case "user":
                    rents = t(r => r.User.UserName);
                    break;
                case "start":
                    rents = t(r => r.Start);
                    break;
                case "end":
                    rents = t(s => s.End);
                    break;
            }
            return View(rents.ToList());
        }

        // GET: Rents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,MovieId,Start,End,Returned")] Rent rent)
        {
            if (ModelState.IsValid)
            {
          
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            int movieId = rent.MovieId;
            if (Request.QueryString["movieId"] != null)
            {
                movieId = int.Parse(Request.QueryString["movieId"]);
            }
            String userId = rent.UserId;
            if (Request.QueryString["userId"] != null)
            {
                userId = Request.QueryString["userId"];
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", movieId);
            ViewBag.UserId = new SelectList(db.Movies, "Id", "Name", userId);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentId,UserId,MovieId,Start,End,Returned")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                if (rent.Returned == DateTime.MinValue)
                    rent.Returned = null;
                db.Entry(rent).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", rent.MovieId);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }
        
        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = db.Rents.Find(id);
            db.Rents.Remove(rent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
