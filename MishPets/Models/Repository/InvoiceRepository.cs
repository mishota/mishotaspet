using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Invoice> _Invoices;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
            _Invoices = _context.Invoices;
        }
        public IEnumerable<Invoice> AllInvoices { get { return  _Invoices; } }
        public IEnumerable<Invoice> OverexposuresInvoices(int OverexposureContractId)
        {
            return _Invoices.Include(i => i.OverexposureContracts).Where(i => i.OverexposureContractId == OverexposureContractId);
        }
        public Invoice GetInvoice(int InvoiceId)
        {
            return _Invoices.Find(InvoiceId);
        }
        public void Create(Invoice Invoice)
        {
            if (Invoice.InvoiceId == 0)
            {
                Invoice.DateOfInvoice = DateTime.Now;
                Invoice.SumOfInvoice = 0;
                _Invoices.Add(Invoice);

                _context.SaveChanges();
            }
            else
            {
                _context.Entry(Invoice).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }
        public async Task<Invoice> DeleteInvoice(int InvoiceId)
        {
            Invoice Invoice = await _Invoices.FindAsync(InvoiceId);
            if (Invoice != null)
            {
                //var expinv = _context.Expense_Invoices.Where(e => e.InvoiceId == InvoiceId);
                //foreach (Expense_Invoice e in expinv)
                //{
                //    _context.Expense_Invoices.Remove(e);
                //}
                _Invoices.Remove(Invoice);
                _context.SaveChanges();
            }

            return Invoice;
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