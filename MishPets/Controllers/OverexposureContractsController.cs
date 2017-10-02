using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MishPets.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;


namespace MishPets.Controllers
{
    [Authorize(Roles = "over")]
    public class OverexposureContractsController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: OverexposureContracts
        
        public ActionResult ListOverex()
        {
            string usid = User.Identity.GetUserId();
            var overexposureContracts = UOW.OverexposureContractRepository.UsersOverexposureContracts(usid);
            return View( overexposureContracts.ToList());
        }

        //GET: OverexposureContracts/Create
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(UOW.PetRepository.AllPets, "PetId", "NickName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OverexposureContractId,PetId,DateOverexpStart,DateOverexpEnd")] OverexposureContract overexposureContract)
        {
            string usid = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                UOW.OverexposureContractRepository.SaveOverexposureContract(overexposureContract, usid);
                return RedirectToAction("ListOverex");
            }
            ViewBag.PetId = new SelectList(UOW.PetRepository.AllPets, "PetId", "NickName");
            return View(overexposureContract);
        }

        [HttpGet]
        public ActionResult ListInvoice(int OverexposureContractId)
        {
            var invoices = UOW.InvoiceRepository.OverexposuresInvoices(OverexposureContractId);
            ViewBag.OverexposureContractId = OverexposureContractId;
            return View(invoices.ToList());
        }

        [HttpGet]
        public ActionResult ListExpInv(int InvoiceId)
        {
            var expense_Invoices = UOW.Expense_InvoiceRepository.Expense_Invoices(InvoiceId);//ViewBag.OverexposureContractId = db.Invoices.Find(InvoiceId).OverexposureContractId;
            ViewBag.OverexposureContractId = UOW.InvoiceRepository.GetInvoice(InvoiceId).OverexposureContractId;
            ViewBag.InvoiceID = InvoiceId;
            return View(expense_Invoices.ToList());
        }

        [HttpGet]
        public ActionResult CreateExpInv(int InvoiceId)
        {
            ViewBag.ExpenseId = new SelectList(UOW.ExpenseRepository.AllExpenses, "ExpenseId", "TypeOfExpense");
            ViewBag.InvoiceId = InvoiceId;
            ViewBag.OverexposureContractId = UOW.InvoiceRepository.GetInvoice(InvoiceId).OverexposureContractId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExpInv([Bind(Include = "Expense_InvoiceId,InvoiceId,OverexposureContractId,ExpenseId,Quantity,SumExpense")] Expense_Invoice expense_Invoice, int InvoiceId)
        {
            if (expense_Invoice.Quantity < 0)
            {
                ModelState.AddModelError("Quantity", "Некорректное количество");
                
            }
            UOW.Expense_InvoiceRepository.SaveExpense_Invoice(expense_Invoice);
            ViewBag.ExpenseId = new SelectList(UOW.ExpenseRepository.AllExpenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            ViewBag.InvoiceId = InvoiceId;
            return RedirectToAction("ListExpInv", new { InvoiceId = expense_Invoice.InvoiceId });
        }
        
        // GET: Expense_Invoices/Edit/5
        public async Task<ActionResult> EditExpInv(int Expense_InvoiceId)
        {
            Expense_Invoice expense_Invoice = await UOW.Expense_InvoiceRepository.GetExpense_Invoice(Expense_InvoiceId);
            if (expense_Invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseId = new SelectList(UOW.ExpenseRepository.AllExpenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            ViewBag.InvoiceId = expense_Invoice.InvoiceId;
            return View(expense_Invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpInv([Bind(Include = "Expense_InvoiceId,InvoiceId,OverexposureContractId,ExpenseId,Quantity,SumExpense")] Expense_Invoice expense_Invoice)
        {
            if (expense_Invoice.Quantity <0)
            {
                ModelState.AddModelError("Quantity", "Некорректное количество");
            }
            if (ModelState.IsValid)
            {
                UOW.Expense_InvoiceRepository.SaveExpense_Invoice(expense_Invoice);
            }
            ViewBag.ExpenseId = new SelectList(UOW.ExpenseRepository.AllExpenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            return RedirectToAction("ListExpInv", new { InvoiceId = expense_Invoice.InvoiceId }); 
        }

        // GET: Expense_Invoices/Delete/5
        public async Task<ActionResult> DeleteExpInv(int Expense_InvoiceId)
        {
            if (Expense_InvoiceId == 0)
            {
                return HttpNotFound();
            }
            Expense_Invoice expense_Invoice = await UOW.Expense_InvoiceRepository.GetExpense_Invoice(Expense_InvoiceId);
            return View(expense_Invoice);
        }

        [HttpPost, ActionName("DeleteExpInv")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteExpInvConfirmed(int Expense_InvoiceId)
        {
            Expense_Invoice Expense_Invoice = await UOW.Expense_InvoiceRepository.GetExpense_Invoice(Expense_InvoiceId);
            int InvoiceId = Expense_Invoice.InvoiceId;
            Expense_Invoice expense_Invoice = await UOW.Expense_InvoiceRepository.DeleteExpense_Invoice(Expense_InvoiceId);
            return RedirectToAction("ListExpInv", new { InvoiceId = InvoiceId });
        }

        // GET: Invoices/Create
        public ActionResult CreateInvoice(int OverexposureContractId)
        {
            Invoice invoice = new Invoice();
            invoice.OverexposureContractId = OverexposureContractId;
            invoice.DateOfInvoice = DateTime.Now;
            invoice.SumOfInvoice = 0;
            UOW.InvoiceRepository.Create(invoice);
            return RedirectToAction("ListInvoice", new { OverexposureContractId = OverexposureContractId });
        }
    }
}
