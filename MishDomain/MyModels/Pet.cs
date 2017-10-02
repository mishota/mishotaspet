using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishPets.Models;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MishDomain.MyModels
{
    //Добавляем модель Pet
    public class Pet1
    {
        //public Pet1()
        //{
        //    this.NewHomeContracts = new List<NewHomeContract>();
        //    this.OverexposureContracts = new List<OverexposureContract>();
        //}

        public int PetId { get; set; }
        public int KindOfPetId { get; set; }
        [Display(Name = "Кличка")]
        public string NickName { get; set; }
        [Display(Name = "Возраст (мес)")]
        public int Age { get; set; }
        [Display(Name = "Описание")]
        public string DescriptionOfPet { get; set; }
        [Display(Name = "Пол")]
        public int FlagMale { get; set; }
        [Display(Name = "Статус")]
        public string StatusOfPet { get; set; }
        [Display(Name = "Фото")]
        public byte[] ImagePet { get; set; }
        public string ImageMimeType { get; set; }

        //public virtual KindOfPet KindOfPet { get; set; }
        //public virtual ICollection<NewHomeContract> NewHomeContracts { get; set; }
        //public virtual ICollection<OverexposureContract> OverexposureContracts { get; set; }
    }
}
