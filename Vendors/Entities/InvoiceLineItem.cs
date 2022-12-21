//InvoicesLineItem.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using System.ComponentModel.DataAnnotations;

namespace Vendors.Entities
{
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }

        [Required(ErrorMessage = "Please enter amount.")]
        public double? Amount { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        public string? Description { get; set; }

        // FK:
        public int? InvoiceId { get; set; }

        // Nav prop to invoice:
        public Invoice? Invoice { get; set; }

    }
}
