using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public interface IExpense_InvoiceRepository
    {
        IEnumerable<Expense_Invoice> Expense_Invoices(int InvoiceId);
        Task<Expense_Invoice> GetExpense_Invoice(int Expense_InvoiceId);
        void SaveExpense_Invoice(Expense_Invoice Expense_Invoice);
        Task<Expense_Invoice> DeleteExpense_Invoice(int Expense_InvoiceId);
    }
}
