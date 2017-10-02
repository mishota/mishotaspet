using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MishPets.Models
{
    public class PetsListViewModel
    {
        public IEnumerable<Pet> Pets { get; set; }
        public SelectList Kinds { get; set; }
        public SelectList Males { get; set; }
        public SelectList Ages { get; set; }
    }
}