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
using PagedList;


namespace MishPets.Controllers
{
    public class PetsCatalogController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: Pets
        public ActionResult Index(string kind, string male, string age, int? page)
        {
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            IEnumerable<Pet> pets = UOW.PetRepository.FilterPets(kind, male, age).ToList();
            List<KindOfPet> kinds = UOW.KindOfPetPepository.AllKinds.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            kinds.Insert(0, new KindOfPet { Kind = "Все", KindOfPetId = 10 });
            PetsListViewModel plvm = new PetsListViewModel
            {
                Pets = pets.ToList(),
                //Pets = pets.ToPagedList(pageNumber, pageSize),
                Kinds = new SelectList(kinds, "KindOfPetId", "Kind"),
                Males = new SelectList(new List<string>()
            {
                "Все",
                "Мальчик",
                "Девочка"                
            }),
                Ages = new SelectList(new List<string>()
            {
                "Все",
                "Младше года",
                "Старше года"
            })

            };
            return View(plvm);
        }

        // GET: Pets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Pet pet = await UOW.PetRepository.GetPet(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return PartialView(pet);
        }

        //Метод getimage**********************************
        public async Task<FileContentResult> GetImage(int petId)
        {
            Pet pet = await UOW.PetRepository.GetPet(petId);
            if (pet != null)
                return File(pet.ImagePet, pet.ImageMimeType);
            else return null;
        }
    }
}