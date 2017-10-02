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
using MishPets.Models.Repository;

namespace MishPets.Controllers
{
    public class PetsController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: Pets
        public ActionResult Index()
        {
            return View(UOW.PetRepository.AllPets);
        }
                
        public ActionResult AutocompleteSearch(string term)
        {
            var models = UOW.PetRepository.SearchPets(term);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // GET: Pets/Details/5
        public async Task<ActionResult> Details(int PetId)
        {
            Pet pet = await UOW.PetRepository.GetPet(PetId);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.KindOfPetId = new SelectList(UOW.KindOfPetPepository.AllKinds, "KindOfPetId", "Kind");
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetId,KindOfPetId,NickName,Age,DescriptionOfPet,FlagMale,StatusOfPet,ImagePet,ImageMimeType")] Pet pet, int PetId = 0)
        {
            if (pet.Age < 0)
            {
                ModelState.AddModelError("Age", "Некорректный возраст");
            }
            else if (pet.FlagMale<0 && pet.FlagMale >1)
            {
                ModelState.AddModelError("FlagMale", "Флаг пола должен быть 0 - жен или 1 - муж");
            }
            if (ModelState.IsValid)
            {
                UOW.PetRepository.SavePet(pet, PetId);
                return RedirectToAction("Index");
            }
            ViewBag.KindOfPetId = new SelectList(UOW.KindOfPetPepository.AllKinds, "KindOfPetId", "Kind");
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<ActionResult> Edit(int PetId )
        {
            Pet pet = await UOW.PetRepository.GetPet(PetId);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindOfPetId = new SelectList(UOW.KindOfPetPepository.AllKinds, "KindOfPetId", "Kind");
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetId,KindOfPetId,NickName,Age,DescriptionOfPet,FlagMale,StatusOfPet,ImagePet,ImageMimeType")] Pet pet, HttpPostedFileBase image = null)
        {
            //Для добавления фото*******************************
            if (image != null)
            {
                pet.ImageMimeType = image.ContentType;
                pet.ImagePet = new byte[image.ContentLength];
                image.InputStream.Read(pet.ImagePet, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                UOW.PetRepository.SavePet(pet, pet.PetId);
                return RedirectToAction("Index");
            }
            ViewBag.KindOfPetId = new SelectList(UOW.KindOfPetPepository.AllKinds, "KindOfPetId", "Kind");
            return View(pet);
        }

        public async Task<FileContentResult> GetImage(int PetId)
        {
            Pet pet = await UOW.PetRepository.GetPet(PetId);
            if (pet != null)
                return File(pet.ImagePet, pet.ImageMimeType);
            else return null;
        }

        // GET: Pets/Delete/5
        public async Task<ActionResult> Delete(int PetId)
        {
            Pet pet = await UOW.PetRepository.GetPet(PetId);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int PetId)
        {
            Pet pet = await UOW.PetRepository.DeletePet(PetId);
            return RedirectToAction("Index");
        }
    }
}
