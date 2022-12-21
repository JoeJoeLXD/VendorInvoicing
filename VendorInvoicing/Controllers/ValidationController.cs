//ValidationController.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Numerics;
using VendorInvoicing.DataAccess;
using Vendors.Entities;

namespace VendorInvoicing.Controllers
{
    public class ValidationController : Controller
    {

        public ValidationController(VendorDbContext vendorDbContext)
        {
            _vendorDbContext = vendorDbContext;
        }

        public IActionResult CheckPhone(string VendorPhone)
        {
            Console.WriteLine($"In check phone action for phone: {VendorPhone}");

            string msg = CheckIfPhoneExistsInDb(VendorPhone);
            //here we return a simple true (as JSON) if the phone addr is good, i.e. not in use
            //otherwise we return a msg indicating it is in use
            if (string.IsNullOrEmpty(msg))
            {
                //this allows tht clinet-side data validn libraries to see this filed as valid
                TempData["okPhone"] = true;
                return Json(true);
            }
            else
            {
                return Json(msg);
            }

            //return View();
        }

        private string CheckIfPhoneExistsInDb(string phone)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(phone))
            {
                var vendor = _vendorDbContext.Vendors.Where(v => v.VendorPhone.ToLower() == phone.ToLower()).FirstOrDefault();
                if (vendor != null)
                    msg = $"The phone number \"{phone}\" is already in use.";
            }

            return msg;
        }

        private VendorDbContext _vendorDbContext;
    }
}
