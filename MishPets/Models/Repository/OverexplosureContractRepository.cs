using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MishPets.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public class OverexposureContractRepository: IOverexposureContractRepository
    {
        private ApplicationDbContext _context;
        private DbSet<OverexposureContract> _OverexposureContracts;
    
        public OverexposureContractRepository(ApplicationDbContext context)
        {
            _context = context;
            _OverexposureContracts = _context.OverexposureContracts;
        }

        public IEnumerable<OverexposureContract> AllOverexposureContracts { get
            { return _OverexposureContracts.Include(o => o.Pet).Include(o => o.ApplicationUser); } }
        public  IEnumerable<OverexposureContract> UsersOverexposureContracts(string UserId)
        {
            return  _OverexposureContracts.Where (o => o.IdUserForOverexp == UserId);
        }
        //
        public  async Task<OverexposureContract> GetOverexposureContract(int OverexposureContractId)
        {
            return await _OverexposureContracts.FindAsync(OverexposureContractId);
        }

        //
        public void SaveOverexposureContract(OverexposureContract OverexposureContract, string UserId)
        {
            if (OverexposureContract.OverexposureContractId == 0)
            {
                OverexposureContract.DateOverexpStart = DateTime.Now;
                OverexposureContract.ApplicationUser = _context.Users.Find(OverexposureContract.IdUserForOverexp);
                _OverexposureContracts.Add(OverexposureContract);
                _context.Pets.Find(OverexposureContract.PetId).StatusOfPet = "Передержка";
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(OverexposureContract).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public async Task<OverexposureContract> DeleteOverexposureContract(int OverexposureContractId)
        {
            OverexposureContract OverexposureContract = await _OverexposureContracts.FindAsync(OverexposureContractId);
            if (OverexposureContract != null)
            {
                //IQueryable<Invoice> inv = _context.Invoices.Include(i => i.Expense_Invoices).Where(i => i.OverexposureContractId == OverexposureContractId);
                //if (inv != null)
                //{
                //    foreach (Invoice i in inv)
                //    {
                //        //IQueryable<Expense_Invoice> expinv = _context.Expense_Invoices.Where(e => e.InvoiceId == i.InvoiceId);
                //        //var expinv = _context.Expense_Invoices.Where(e => e.InvoiceId == i.InvoiceId);
                //        var expinv = i.Expense_Invoices;
                //        if (expinv != null)
                //        {
                //            foreach (Expense_Invoice e in expinv)
                //            {
                //                _context.Expense_Invoices.Remove(e);
                //            }
                //        }
                //        _context.Invoices.Remove(i);
                //    }
                //}
                _context.Pets.Find(OverexposureContract.PetId).StatusOfPet ="Бездомный";
                _OverexposureContracts.Remove(OverexposureContract);
                _context.Pets.Find(OverexposureContract.PetId);
                _context.SaveChanges();
            }

            return OverexposureContract;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}