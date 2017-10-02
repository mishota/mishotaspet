using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishPets.Models.Repository;

namespace MishPets.Models
{
    public interface IUnitOfWork
    {
        IBlogPostRepository BlogPostRepository { get; }
        IPetRepository PetRepository { get; }
        IKindOfPetPepository KindOfPetPepository { get; }
        IOverexposureContractRepository OverexposureContractRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IExpense_InvoiceRepository Expense_InvoiceRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        INewHomeContractRepository NewHomeContractRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
        void RollBack();
    }
}
