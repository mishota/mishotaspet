using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace MishPets.Models.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> AllInvoices { get; }
        IEnumerable<Invoice> OverexposuresInvoices(int OverexposureContractId);
        Invoice GetInvoice(int InvoiceId);
        void Create(Invoice Invoice);
        Task<Invoice> DeleteInvoice(int InvoiceId);
    }
}
