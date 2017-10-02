using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public class NewHomeContractRepository: INewHomeContractRepository
    {
        private ApplicationDbContext _context;
        private DbSet<NewHomeContract> _NewHomeContracts;

        public NewHomeContractRepository(ApplicationDbContext context)
        {
            _context = context;
            _NewHomeContracts = _context.NewHomeContracts;
        }
        public IEnumerable<NewHomeContract> AllNewHomeContracts { get
            { return _NewHomeContracts.Include(n => n.Pet).Include(n => n.ApplicationUser); } }

        public async Task<NewHomeContract> GetNewHomeContract(int NewHomeContractId)
        {
            return await _NewHomeContracts.FindAsync(NewHomeContractId);
        }
        public void SaveNewHomeContract(NewHomeContract NewHomeContract, string UserId)
        {
            if (NewHomeContract.NewHomeContractId == 0)
            {
                NewHomeContract.DateHomeStart = DateTime.Now;
                NewHomeContract.ApplicationUser = _context.Users.Find(NewHomeContract.IdUserForNewHome);
                _NewHomeContracts.Add(NewHomeContract);
                _context.Pets.Find(NewHomeContract.PetId).StatusOfPet = "Нашел дом";
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(NewHomeContract).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public async Task<NewHomeContract> DeleteNewHomeContract(int NewHomeContractId)
        {
            NewHomeContract NewHomeContract = await _NewHomeContracts.FindAsync(NewHomeContractId);
            if (NewHomeContract != null)
            {
                _context.Pets.Find(NewHomeContract.PetId).StatusOfPet = "Бездомный";
                _NewHomeContracts.Remove(NewHomeContract);
                _context.SaveChanges();
            }

            return NewHomeContract;
        }
    }
}