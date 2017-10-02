using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MishPets.Models;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MishPets.Controllers
{
    public class CatalogPetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: CatalogPets
        public ActionResult Index()
        {
            //var models = db.Pets.Where(a => a.StatusOfPet.Contains("Бездомн"))
            //               .Distinct();

            //return Json(models, JsonRequestBehavior.AllowGet);
           // var pets = db.Pets.Include(p => p.KindOfPet);
            return View();

        }



        public string GetData()
        {
            List<Pet> pets = db.Pets.ToList();
            
            return JsonConvert.SerializeObject(pets);
        }
    }
}