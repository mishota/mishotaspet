using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MishPets.Models;

namespace MishPets.Controllers
{
    public class ApplicationUsersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(UOW.UserRepository.AllUsers.ToList());
        }

        // GET: ApplicationUsers/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.Users.Find(id); 
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        //// GET: ApplicationUsers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        
        // GET: ApplicationUsers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser =  UOW.UserRepository.GetUser(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Address,Phone,FlagОverexposure,GeoLong,GeoLat,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(applicationUser).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                UOW.UserRepository.SaveUser(applicationUser);
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
