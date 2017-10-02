using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public class Expense_InvoiceRepository: IExpense_InvoiceRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Expense_Invoice> _Expense_Invoices;

        public Expense_InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
            _Expense_Invoices = _context.Expense_Invoices;
        }


        public IEnumerable<Expense_Invoice> Expense_Invoices(int InvoiceId)
        {
            return _Expense_Invoices.Include(e => e.Expense).Where(e => e.InvoiceId == InvoiceId);
        }


        public async Task<Expense_Invoice> GetExpense_Invoice(int Expense_InvoiceId)
        {
            return await _Expense_Invoices.FindAsync(Expense_InvoiceId);
        }


        public void SaveExpense_Invoice(Expense_Invoice Expense_Invoice)
        {
            if (Expense_Invoice.Expense_InvoiceId == 0)
            {
                Invoice invoice = _context.Invoices.Find(Expense_Invoice.InvoiceId);
                if (invoice == null)
                {
                    invoice = new Invoice();
                    invoice.DateOfInvoice = DateTime.Now;
                    invoice.OverexposureContractId = Expense_Invoice.OverexposureContractId;
                    _context.Invoices.Add(invoice);
                }
                var exp_inv = _context.Expense_Invoices.Where(e => e.InvoiceId == Expense_Invoice.InvoiceId);
                double cost = _context.Expenses.Find(Expense_Invoice.ExpenseId).CostOfExpense;
                bool flag = false;
                foreach (Expense_Invoice ei in exp_inv)
                {
                    if (ei.ExpenseId == Expense_Invoice.ExpenseId)
                    {
                        ei.Quantity = ei.Quantity + Expense_Invoice.Quantity;
                        ei.SumExpense = ei.SumExpense + Expense_Invoice.Quantity * cost;
                        invoice.SumOfInvoice = invoice.SumOfInvoice + Expense_Invoice.Quantity * cost;
                        flag = true;
                    }
                }
                if (flag == false)
                {

                    Expense_Invoice.InvoiceId = invoice.InvoiceId;
                    Expense_Invoice.SumExpense = Expense_Invoice.Quantity * _context.Expenses.Find(Expense_Invoice.ExpenseId).CostOfExpense;
                    _Expense_Invoices.Add(Expense_Invoice);
                    invoice.SumOfInvoice += Expense_Invoice.SumExpense;
                }
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(Expense_Invoice).State = EntityState.Modified;
                double cost = _context.Expenses.Find(Expense_Invoice.ExpenseId).CostOfExpense;
                Invoice invoice = _context.Invoices.Find(Expense_Invoice.InvoiceId);
                Expense_Invoice.SumExpense = Expense_Invoice.Quantity * cost;

                var ExpInvs = _Expense_Invoices.Where(e => e.InvoiceId == Expense_Invoice.InvoiceId);
                invoice.SumOfInvoice = 0;
                foreach (Expense_Invoice ei in ExpInvs)
                {
                    if (ei.SumExpense != 0)
                    { invoice.SumOfInvoice += ei.SumExpense; }
                }
                _context.SaveChanges();
            }
        }

        public async Task<Expense_Invoice> DeleteExpense_Invoice(int Expense_InvoiceId)
        {
            Expense_Invoice expense_Invoice = await _Expense_Invoices.FindAsync(Expense_InvoiceId);
            if (expense_Invoice != null)
            {
                int InvoiceId = expense_Invoice.InvoiceId;
                Invoice invoice = _context.Invoices.Find(expense_Invoice.InvoiceId);
                invoice.SumOfInvoice = invoice.SumOfInvoice - expense_Invoice.SumExpense;
                _Expense_Invoices.Remove(expense_Invoice);

                
                await _context.SaveChangesAsync();
            }
            return expense_Invoice;
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