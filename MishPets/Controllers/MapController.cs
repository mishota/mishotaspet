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
    public class MapController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            List<OverexposureContract> overexposures = UOW.OverexposureContractRepository.AllOverexposureContracts.ToList();
            List<MapModel> markers = new List<MapModel>();
            foreach (var item in overexposures)
            {
                if (item.ApplicationUser.GeoLong != 0)
                {
                    markers.Add(new MapModel
                    {
                        PetId = item.Pet.PetId,
                        NickName = item.Pet.NickName,
                        Phone = item.ApplicationUser.Phone,
                        ImagePet = item.Pet.ImagePet,
                        ImageMimeType = item.Pet.ImageMimeType,
                        GeoLong = item.ApplicationUser.GeoLong,
                        GeoLat = item.ApplicationUser.GeoLat
                    });
                }
            }
            return Json(markers, JsonRequestBehavior.AllowGet);
        }
    }
}