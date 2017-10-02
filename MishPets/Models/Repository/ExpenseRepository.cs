using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;


namespace MishPets.Models.Repository
{
    public class ExpenseRepository: IExpenseRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Expense> _Expenses;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
            _Expenses = _context.Expenses;
        }
        public IEnumerable<Expense> AllExpenses { get { return _Expenses; } }
        public async Task<Expense> GetExpense(int ExpenseId)
        {
            return await _Expenses.FindAsync(ExpenseId);
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