//Invoice.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using System.ComponentModel.DataAnnotations;

namespace Vendors.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Please enter a date of invoice.")]
        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceDueDate
        {
            get
            {
                return InvoiceDate?.AddDays(Convert.ToDouble(PaymentTerms?.DueDays));
            }
        }

        public double? PaymentTotal { get; set; } = 0.0;

        public DateTime? PaymentDate { get; set; }

        // FK:
        public int PaymentTermsId { get; set; }

        // Nav to terms:
        [Required(ErrorMessage = "Please select a Payment Terms.")]
        public PaymentTerms? PaymentTerms { get; set; }

        // FK:
        public int VendorId { get; set; }

        // Nav to vendor
        public Vendor? Vendor { get; set; }

        // Nav to line items:
        public ICollection<InvoiceLineItem>? InvoiceLineItems { get; set; }


    }
}
