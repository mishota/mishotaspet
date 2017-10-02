using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> AllExpenses { get; }
        Task<Expense> GetExpense(int ExpenseId);
    }
}
