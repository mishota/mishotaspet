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
    public class NewHomeContractsController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: NewHomeContracts
        public ActionResult Index()
        {
            var newHomeContracts = UOW.NewHomeContractRepository.AllNewHomeContracts;
            return View(newHomeContracts.ToList());
        }

        // GET: NewHomeContracts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            NewHomeContract newHomeContract = await UOW.NewHomeContractRepository.GetNewHomeContract(id);
            if (newHomeContract == null)
            {
                return HttpNotFound();
            }
            return View(newHomeContract);
        }

        // GET: NewHomeContracts/Create
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(UOW.PetRepository.AllPets, "PetId", "NickName");
            ViewBag.IdUserForNewHome = new SelectList(UOW.UserRepository.AllUsers, "Id", "Email");
            return View();
        }

        // POST: NewHomeContracts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NewHomeContractId,PetId,DateHomeStart,IdUserForNewHome")] NewHomeContract newHomeContract)
        {
            if (newHomeContract!=null)
            {
                newHomeContract.ApplicationUser = UOW.UserRepository.GetUser(newHomeContract.IdUserForNewHome);
                UOW.NewHomeContractRepository.SaveNewHomeContract(newHomeContract, newHomeContract.IdUserForNewHome);
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.HomelessPets, "PetId", "NickName", newHomeContract.PetId);
            ViewBag.IdUserForNewHome = new SelectList(UOW.UserRepository.AllUsers, "Id", "Email", newHomeContract.IdUserForNewHome);
            return View(newHomeContract);
        }

        // GET: NewHomeContracts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            NewHomeContract newHomeContract = await UOW.NewHomeContractRepository.GetNewHomeContract(id);
            if (newHomeContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.HomelessPets, "PetId", "NickName", newHomeContract.PetId);
            ViewBag.IdUserForNewHome = new SelectList(UOW.UserRepository.AllUsers, "Id", "Email", newHomeContract.IdUserForNewHome);
            return View(newHomeContract);
        }

        // POST: NewHomeContracts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NewHomeContractId,PetId,DateHomeStart,IdUserForNewHome")] NewHomeContract newHomeContract)
        {
            if( newHomeContract != null)
            {
                UOW.NewHomeContractRepository.SaveNewHomeContract(newHomeContract, newHomeContract.IdUserForNewHome);
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.HomelessPets, "PetId", "NickName", newHomeContract.PetId);
            ViewBag.IdUserForNewHome = new SelectList(UOW.UserRepository.AllUsers, "Id", "Email", newHomeContract.IdUserForNewHome);
            return View(newHomeContract);
        }

        // GET: NewHomeContracts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            NewHomeContract newHomeContract = await UOW.NewHomeContractRepository.GetNewHomeContract(id);
            if (newHomeContract == null)
            {
                return HttpNotFound();
            }
            return View(newHomeContract);
        }

        // POST: NewHomeContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NewHomeContract newHomeContract = await UOW.NewHomeContractRepository.DeleteNewHomeContract(id);
            return RedirectToAction("Index");
        }
    }
}
