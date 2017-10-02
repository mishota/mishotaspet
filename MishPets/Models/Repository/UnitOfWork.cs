using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MishPets.Models;
using System.Data.Entity;
using MishPets.Models.Repository;

namespace MishPets.Models
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IBlogPostRepository _BlogPostRepository;
        private IPetRepository _PetRepository;
        private IKindOfPetPepository _KindOfPetPepository;
        private IOverexposureContractRepository _OverexposureContractRepository;
        private IInvoiceRepository _InvoiceRepository;
        private IExpense_InvoiceRepository _Expense_InvoiceRepository;
        private IExpenseRepository _ExpenseRepository;
        private INewHomeContractRepository _NewHomeContractRepository;
        private IUserRepository _UserRepository;


        //public UnitOfWork(EDM context)
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBlogPostRepository BlogPostRepository
        {
            get
            {
                _BlogPostRepository = _BlogPostRepository ?? new BlogPostRepository(_context);
                return _BlogPostRepository;
            }
        }

        public IPetRepository PetRepository
        {
            get
            {
                _PetRepository = _PetRepository ?? new PetRepository(_context);
                return _PetRepository;
            }
        }
        public IKindOfPetPepository KindOfPetPepository
        {
            get
            {
                _KindOfPetPepository = _KindOfPetPepository ?? new KindOfPetRepository(_context);
                return _KindOfPetPepository;
            }
        }

        public IOverexposureContractRepository OverexposureContractRepository
        {
            get
            {
                _OverexposureContractRepository = _OverexposureContractRepository ?? new OverexposureContractRepository(_context);
                return _OverexposureContractRepository;
            }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                _InvoiceRepository = _InvoiceRepository ?? new InvoiceRepository(_context);
                return _InvoiceRepository;
            }
        }

        public IExpense_InvoiceRepository Expense_InvoiceRepository
        {
            get
            {
                _Expense_InvoiceRepository = _Expense_InvoiceRepository ?? new Expense_InvoiceRepository(_context);
                return _Expense_InvoiceRepository;
            }
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                _ExpenseRepository = _ExpenseRepository ?? new ExpenseRepository(_context);
                return _ExpenseRepository;
            }
        }

        public INewHomeContractRepository NewHomeContractRepository
        {
            get
            {
                _NewHomeContractRepository = _NewHomeContractRepository ?? new NewHomeContractRepository(_context);
                return _NewHomeContractRepository;
            }
        }
        
        public IUserRepository UserRepository
        {
            get
            {
                _UserRepository = _UserRepository ?? new UserRepository(_context);
                return _UserRepository;
            }
        }



        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            var changedEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }
    }
}