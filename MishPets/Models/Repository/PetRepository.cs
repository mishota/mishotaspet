using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MishPets.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public class PetRepository: IPetRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Pet> _Pets;
        
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
            _Pets = _context.Pets;
        }
        public IEnumerable<Pet> AllPets { get { return _Pets.Include(p => p.KindOfPet); } }
        public IEnumerable<Pet> HomelessPets { get { return _Pets.Include(p => p.KindOfPet).Where(p => p.StatusOfPet != "Нашел дом"); } }
        public IEnumerable<Pet> ForOverexposurePets { get { return _Pets.Include(p => p.KindOfPet).Where(p => p.StatusOfPet == "Бездомный"); } }

        public IEnumerable<Pet> FilterPets(string kind, string male, string age)
        {
            IEnumerable<Pet> pets = _Pets.Where(p => p.StatusOfPet != "Нашел дом");
            if (!String.IsNullOrEmpty(kind) && !kind.Equals("10"))
            {
                pets = pets.Where(p => p.KindOfPetId == int.Parse(kind));
            }
            if (male != null && !male.Equals("Все"))
            {
                int kid = 1;
                if (male == "Девочка")
                    kid = 0;
                pets = pets.Where(p => p.FlagMale == kid);
            }
            if (age != null && !age.Equals("Все"))
            {
                if (age == "Младше года")
                {
                    pets = pets.Where(p => p.Age > 0 && p.Age <= 12);
                }
                else
                {
                    pets = pets.Where(p => p.Age >= 12);
                }
            }

            
            return pets;

        }

        public IEnumerable<Pet> SearchPets(string term)
        {
            IEnumerable<Pet> pets = _Pets;
            if (!String.IsNullOrEmpty(term))
            {
                pets = pets.Where(a => a.NickName.Contains(term));
            }
            return pets;
        }
        //
        public async Task<Pet> GetPet(int PetId)
        {
            return  await _Pets.FindAsync(PetId);
        }

        //
        public void SavePet(Pet Pet, int PetId)
        {

            if(Pet.PetId == 0)
            {
                _Pets.Add(Pet);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(Pet).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public async Task<Pet> DeletePet(int PetId)
        {
            Pet Pet = await _Pets.FindAsync(PetId);
            if (Pet != null)
            {
                var OverexposureContracts = _context.OverexposureContracts.Where(o => o.PetId == PetId);
                //foreach (OverexposureContract item in OverexposureContracts)
                //{
                //    IQueryable<Invoice> inv = _context.Invoices.Where(i => i.OverexposureContractId == item.OverexposureContractId);
                //    foreach (Invoice i in inv)
                //    {
                //        var expinv = _context.Expense_Invoices.Where(e => e.InvoiceId == i.InvoiceId);
                //        foreach (Expense_Invoice e in expinv)
                //        {
                //            _context.Expense_Invoices.Remove(e);
                //        }
                //        _context.Invoices.Remove(i);
                //    }
                //    _context.OverexposureContracts.Remove(item);
                //}
                //var NewHomeContracts = _context.NewHomeContracts.Where(o => o.PetId == PetId);
                //foreach (NewHomeContract item in NewHomeContracts)
                //{
                //    _context.NewHomeContracts.Remove(item);
                //}
                _Pets.Remove(Pet);
                _context.SaveChanges();
            }

            return Pet;

        }
    }
}