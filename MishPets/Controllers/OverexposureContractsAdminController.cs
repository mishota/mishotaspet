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
    public class OverexposureContractsAdminController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: OverexposureContractsAdmin
        public ActionResult Index()
        {
            var overexposureContracts = UOW.OverexposureContractRepository.AllOverexposureContracts;
            return View(overexposureContracts.ToList());
        }

        // GET: OverexposureContractsAdmin/Details/5
        public async Task<ActionResult> Details(int id)
        {
            OverexposureContract overexposureContract = await UOW.OverexposureContractRepository.GetOverexposureContract(id);
            if (overexposureContract == null)
            {
                return HttpNotFound();
            }
            return View(overexposureContract);
        }

        // GET: OverexposureContractsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(UOW.PetRepository.ForOverexposurePets, "PetId", "NickName");
            ViewBag.IdUserForOverexp = new SelectList(UOW.UserRepository.OverexposureUsers, "Id", "Email");
            return View();
        }

        // POST: OverexposureContractsAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OverexposureContractId,PetId,DateOverexpStart,DateOverexpEnd,IdUserForOverexp")] OverexposureContract overexposureContract)
        {
            if (ModelState.IsValid)
            {
                UOW.OverexposureContractRepository.SaveOverexposureContract(overexposureContract, overexposureContract.IdUserForOverexp);
                return RedirectToAction("Index");
            }

            ViewBag.PetId = new SelectList(UOW.PetRepository.ForOverexposurePets, "PetId", "NickName");
            ViewBag.IdUserForOverexp = new SelectList(UOW.UserRepository.OverexposureUsers, "Id", "Email", overexposureContract.IdUserForOverexp);
            return View(overexposureContract);
        }

        // GET: OverexposureContractsAdmin/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            OverexposureContract overexposureContract = await UOW.OverexposureContractRepository.GetOverexposureContract(id);
            if (overexposureContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.ForOverexposurePets, "PetId", "NickName");
            ViewBag.IdUserForOverexp = new SelectList(UOW.UserRepository.OverexposureUsers, "Id", "Email", overexposureContract.IdUserForOverexp);
            return View(overexposureContract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OverexposureContractId,PetId,DateOverexpStart,DateOverexpEnd,IdUserForOverexp")] OverexposureContract overexposureContract)
        {
            if (overexposureContract != null)
            {
                UOW.OverexposureContractRepository.SaveOverexposureContract(overexposureContract, overexposureContract.IdUserForOverexp);
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.ForOverexposurePets, "PetId", "NickName");
            ViewBag.IdUserForOverexp = new SelectList(UOW.UserRepository.OverexposureUsers, "Id", "Email", overexposureContract.IdUserForOverexp);
            return View(overexposureContract);
        }

        // GET: OverexposureContractsAdmin/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            OverexposureContract overexposureContract = await UOW.OverexposureContractRepository.GetOverexposureContract(id);
            if (overexposureContract == null)
            {
                return HttpNotFound();
            }
            return View(overexposureContract);
        }

        // POST: OverexposureContractsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OverexposureContract overexposureContract = await UOW.OverexposureContractRepository.GetOverexposureContract(id);
            overexposureContract = await UOW.OverexposureContractRepository.DeleteOverexposureContract(id);
            return RedirectToAction("Index");
        }
    }
}
