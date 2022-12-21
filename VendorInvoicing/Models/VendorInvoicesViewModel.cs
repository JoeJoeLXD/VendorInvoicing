//VendorInvoiceViewModel.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added


using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;

namespace Vendors.Entities
{
    public class VendorInvoicesViewModel
    {
        public Vendor? ActiveVendor { get; set; }

        public Invoice? NewInvoice { get; set; }

        public List<Invoice>? Invoices { get; set; }

        public Invoice? ActiveInvoice { get; set; }

        public InvoiceLineItem? ActiveInvoiceLineItem { get; set; }

        public InvoiceLineItem? InvoiceLineItems { get; set; }

        public PaymentTerms? ActivePaymentTerms { get; set; }


        public InvoiceLineItem? NewInvoiceLineItems { get; set; }

        public List<PaymentTerms>? AllPaymentTerms { get; set; }

        public double? TotalAmount { get; set; }

    }
}
