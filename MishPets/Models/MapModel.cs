using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MishPets.Models
{
    public class MapModel
    {
        public int PetId { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public byte[] ImagePet { get; set; }
        public string ImageMimeType { get; set; }
        public double GeoLong { get; set; } // долгота - для карт google
        public double GeoLat { get; set; } //широта

    }
}