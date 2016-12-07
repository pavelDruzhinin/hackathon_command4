using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialWeb.Models;
using SocialWeb.DataAccess;

namespace SocialWeb.Controllers
{
    public class UsersController : Controller
    {
        private SocialWebContext db = new SocialWebContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Login,Password,Email,Birthday")] User user )

        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("login", "AccountController");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Login,Password,Email,Birthday")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
        public ActionResult Checking(int id)
        {
            var defaultUser = db.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            var dialogs = db.Dialogs.ToList();
            foreach (var j in dialogs)
            {
                var users = j.Users.ToList();
                foreach (var i in users)
                {
                    if (i.Id == id)
                    {
                        foreach (var k in users)
                        {
                            if (k.Id == defaultUser.Id)
                            {
                                return RedirectToAction("Details", "Dialogs", new { id = j.Id });
                            }
                        }
                    }
                }
                
            }
            //var dialogsController = new DialogsController()
            var dialog = new Dialog
            {
                UserId = defaultUser.Id,
                Users = new List<User>
                    {
                        new User { Id = defaultUser.Id },
                        new User { Id = id }
                    }

                //OrderPositions = new List<OrderPosition>
                //    {
                //        new OrderPosition { Count = 1, Product = product }
                //    }
            };
            db.Dialogs.Add(dialog);
            db.SaveChanges();

            return RedirectToAction("Index");

            //return dialogsController(Index);
    }
    }
}
