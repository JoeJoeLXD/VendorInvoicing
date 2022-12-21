//Vendor.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Vendors.Entities
{
    public class Vendor
    {
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Address 1.")]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        [Required(ErrorMessage = "Please enter City.")]
        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Provice ot State.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Plase enter 2 letter Province/State code.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Province/State must be 2 letter Province/State code")]
        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Zip or PostalCode.")]
        [RegularExpression(@"^\d{5}-\d{4}|\d{5}|[A-Z]\d[A-Z] ?\d[A-Z]\d$", ErrorMessage = "Invalid US Zip code or Canadian postal code")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Phone Number.")]
        [Remote("CheckPhone", "Validation")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                    ErrorMessage = "Plase enter valid(Us or Canadian phone number format.")]
        public string? VendorPhone { get; set; }

        public string? VendorContactLastName { get; set; }

        public string? VendorContactFirstName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? VendorContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Invoice>? Invoices { get; set; }

    }
}
