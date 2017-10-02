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

namespace MishPets.Controllers
{
    public class Expense_InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expense_Invoices
        public async Task<ActionResult> Index()
        {
            var expense_Invoices = db.Expense_Invoices.Include(e => e.Expense).Include(e => e.Invoice);
            return View(await expense_Invoices.ToListAsync());
        }

        // GET: Expense_Invoices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense_Invoice expense_Invoice = await db.Expense_Invoices.FindAsync(id);
            if (expense_Invoice == null)
            {
                return HttpNotFound();
            }
            return View(expense_Invoice);
        }

        // GET: Expense_Invoices/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseId = new SelectList(db.Expenses, "ExpenseId", "TypeOfExpense");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId");
            return View();
        }
        //********************************************************
        // GET: Expense_Invoices/Create
        public ActionResult CreateExpInv(int? OverexposureContractId)
        {
            ViewBag.ExpenseId = new SelectList(db.Expenses, "ExpenseId", "TypeOfExpense");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId");
            ViewBag.OverexposureContractId = OverexposureContractId;
            return View();
        }

        // POST: Expense_Invoices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Expense_InvoiceId,InvoiceId,OverexposureContractId,ExpenseId,Quantity,SumExpense")] Expense_Invoice expense_Invoice)
        {
            if (ModelState.IsValid)
            {
                db.Expense_Invoices.Add(expense_Invoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseId = new SelectList(db.Expenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", expense_Invoice.InvoiceId);
            return View(expense_Invoice);
        }

        // GET: Expense_Invoices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense_Invoice expense_Invoice = await db.Expense_Invoices.FindAsync(id);
            if (expense_Invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseId = new SelectList(db.Expenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", expense_Invoice.InvoiceId);
            return View(expense_Invoice);
        }

        // POST: Expense_Invoices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Expense_InvoiceId,InvoiceId,OverexposureContractId,ExpenseId,Quantity,SumExpense")] Expense_Invoice expense_Invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense_Invoice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseId = new SelectList(db.Expenses, "ExpenseId", "TypeOfExpense", expense_Invoice.ExpenseId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", expense_Invoice.InvoiceId);
            return View(expense_Invoice);
        }

        // GET: Expense_Invoices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense_Invoice expense_Invoice = await db.Expense_Invoices.FindAsync(id);
            if (expense_Invoice == null)
            {
                return HttpNotFound();
            }
            return View(expense_Invoice);
        }

        // POST: Expense_Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Expense_Invoice expense_Invoice = await db.Expense_Invoices.FindAsync(id);
            db.Expense_Invoices.Remove(expense_Invoice);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
