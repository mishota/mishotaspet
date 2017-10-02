using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MishPets.Models;
//using System.Data;
//using System.Data.Entity;


namespace MishPets.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public List<MenuItem> items;

        public MenuController()
        {
            items = new List<MenuItem>
            {
                new MenuItem { Name = "Главная", Controller = "Home", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Каталог питомцев", Controller = "PetsCatalog", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Питомцы на карте", Controller = "Map", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Доска объявлений", Controller = "BlogPosts", Action = "List", Active = string.Empty },
                new MenuItem { Name = "Для передержи", Controller = "OverexposureContracts", Action = "ListOverex", Active = string.Empty },
                new MenuItem { Name = "Администрирование", Controller = "Admin", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Личный кабинет", Controller = "Account", Action = "Edit", Active = string.Empty },
            };
        }


        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            var i = items.FirstOrDefault(m => m.Controller == c);
            if (i != null)
            {
                i.Active = "active";
            }
            return PartialView(items);
        }
    }
}