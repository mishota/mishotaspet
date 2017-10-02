using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MishPets.Models;
using System.Data.Entity;
using MishPets.Helpers;

namespace MishPets
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //+++++++++++
            Database.SetInitializer<ApplicationDbContext>(new IdentityDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
