//VendorController.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using Microsoft.AspNetCore.Mvc;
using VendorInvoicing.DataAccess;
using Vendors.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Vendors.Services;
using VendorInvoicing.Services;
using System.Drawing;

namespace VendorInvoicing.Controllers
{
    public class VendorController : Controller
    {
        public VendorController(IVendorManager vendorManager, VendorDbContext vendorDbContext)
        {
            _vendorManager = vendorManager;
            _vendorDbContext = vendorDbContext;
        }

        [HttpGet("/vendors/groups")]
        public async Task<IActionResult> GetVendorsByGroup(string lowerBound = "A", string upperBound = "E")
        {
            // here is the call to the async version on the service:
            var vendors = await _vendorManager.GetVendorsByGroupAsync();

            // Get all my vendorss by alphabetical groups and order by Name
            List<Vendor> vendors1 = vendors
               .Where(v => v.Name.ToLower().Substring(0, 1).CompareTo(lowerBound) >= 0 
               && v.Name.ToLower().Substring(0, 1).CompareTo(upperBound) <= 0)
                .ToList();

            ViewBag.activeColumn = lowerBound;

            TempData["lowerBound"] = lowerBound;
            TempData["upperBound"] = upperBound;

            // and then return that list to the named view:
            return View("Items", vendors1);
        }

        [HttpGet("/vendors/add-request")]
        public IActionResult GetAddVendorRequest()
        {
            // and then return that list to the named view:
            return View("Add", new Vendor());
        }

        [HttpPost("/vendors")]
        public IActionResult AddNewVendor(Vendor vendor)
        {
            //check to see if what is added is valid
            if (ModelState.IsValid)
            {
                //Since valid let's add it to the DB
                _vendorManager.AddNewVendor(vendor);

                TempData["LastActionMessage"] = $"The new vendor \"{vendor.Name}\" was successully added";

                // and then redirct back to the all vendors view:
                return RedirectToAction("GetVendorsByGroup", "Vendor");
            }
            else
            {
                //returning the view with the invalid boject + validn err msgs:
                //validn err msgs
                //Adding a generic msg at the top of form
                ModelState.AddModelError("", "There were errors in the form - please fix them and try again.");
                return View("Add", vendor);
            }
        }

        [HttpGet("/vendors/{id}/edit-request")]
        public IActionResult GetEditVendorRequestById(int id)
        {
            // we use the ID passed in the URL to lookup the vendor by ID:
            Vendor vendor = _vendorManager.GetVendorById(id);

            // and then return that party to the named view:
            return View("Edit", vendor);
        }


        [HttpPost("/vendors/{id}/edit-requests")]
        public IActionResult ProcessEditVendorRequest(int id, Vendor vendor)
        {
            // double-check that the ID on the URL matches the ID in the hidden field in the POST body:
            if (id != vendor.VendorId)
                return NotFound();

            // check to see if what is added is valid:
            if (ModelState.IsValid)
            {
                // Since valid let's update it in the DB:

                _vendorManager.UpdateVendor(vendor);

                TempData["LastActionMessage"] = $"The vendor \"{vendor.Name}\" was successully updated";

                string lowerBound = TempData.Peek("lowerBound").ToString();
                string upperBound = TempData.Peek("upperBound").ToString();

                // and then redirect back to the all parties view:
                return RedirectToAction("GetVendorsByGroup", "Vendor", new { lowerBound = lowerBound, upperBound = upperBound });
            }
            else
            {
                // returning the view with the invalid object + validn err msgs:
                //validn err msgs
                //Adding a generic msg at the top of form
                ModelState.AddModelError("", "There were errors in the form - please fix them and try again.");
                return View("Edit", vendor);
            }
        }

        // Here we also improve the way delete works using attr routing:
        [HttpGet("/vendors/{id}/delete-request")]
        public IActionResult GetDeleteRequestById(int id)
        {
            var vendor = _vendorManager.GetVendorById(id);

            vendor.IsDeleted = true;

            _vendorManager.UpdateVendor(vendor);

            TempData["DeleteMessage"] = $"The vendor \"{vendor.Name}\"  was deleted.";
            TempData["VendorId"] = vendor.VendorId;

            string lowerBound = TempData.Peek("lowerBound").ToString();
            string upperBound = TempData.Peek("upperBound").ToString();

            return RedirectToAction("GetVendorsByGroup", "Vendor", new { lowerBound = lowerBound, upperBound = upperBound });
        }

        [HttpGet("/vendors/{id}/undo")]
        public IActionResult Undo(int id)
        {
            //var vendor = _vendorDbContext.Vendors.Find(id);

            var vendor = _vendorManager.GetVendorById(id);

            vendor.IsDeleted = false;

            _vendorManager.UpdateVendor(vendor);

            string lowerBound = TempData.Peek("lowerBound").ToString();
            string upperBound = TempData.Peek("upperBound").ToString();

            return RedirectToAction("GetVendorsByGroup", "Vendor", new { lowerBound = lowerBound, upperBound = upperBound });
        }
      
        [HttpGet()]
        public IActionResult GetLineItemByVendorAndInvoiceId(int id, int invoiceId)
        {
            // we use the ID passed in the URL to lookup the Vendor v by ID:
            // and then return that v to the named view:

            var invoices = _vendorDbContext.Invoices.Include(i => i.InvoiceLineItems)
                         .Where(v => v.VendorId == id).ToList();

            for (int i = 0; i < invoices.Count; i++)
            {
                var invoice = invoices[i];
                invoice.PaymentTotal = _vendorDbContext.InvoiceLineItems.Where(i => i.InvoiceId == invoice.InvoiceId)
                    .Sum(ili => ili.Amount).GetValueOrDefault();
            }

            var paymenTerms = _vendorDbContext.PaymentTerms.OrderBy(p => p.PaymentTermsId).ToList();

            var acitveInvoice = _vendorManager.GetInvoiceById(invoiceId);

            if (acitveInvoice == null && invoices.Count != 0)
            {
                acitveInvoice = invoices[0];
            }

            VendorInvoicesViewModel vendorInvoicesViewModel = new VendorInvoicesViewModel()
            {
                ActiveVendor = _vendorManager.GetVendorById(id),
                ActiveInvoice = acitveInvoice,
                AllPaymentTerms = paymenTerms,
                NewInvoiceLineItems = new InvoiceLineItem(),
                Invoices = invoices 
            };

            return View("Item", vendorInvoicesViewModel);
        }

        [HttpPost("/vendors/{id}/invoices")]
        public IActionResult AddInvoiceToVendorById(int id, VendorInvoicesViewModel vendorInvoicesViewModel)
        {
            // retrieve the whole vendor:
            var vendor = _vendorManager.GetVendorById(id);

            // get the invoice out of the POSTed view model & add it to the 's vendor's coll'n
            vendor.Invoices.Add(vendorInvoicesViewModel.NewInvoice);

            //_vendorDbContext.SaveChanges();
            _vendorManager.UpdateVendor(vendor);

            // redirect back to the same item view passing the Id to the URL
            return RedirectToAction("GetLineItemByVendorAndInvoiceId", "Vendor", new { id = id });
        }


        [HttpPost("/vendors/{id}/invoice/{invoiceId}/lineitems")]
        public IActionResult AddInvocelineitemToInvoiceById(int id, int invoiceId, VendorInvoicesViewModel vendorInvoicesViewModel)
        {
            // retrieve the whole invoice:
            var vendor = _vendorManager.GetVendorById(id);

            var invoice = _vendorManager.GetInvoiceById(invoiceId);



            // get the invoice line items out of the POSTed view model & add it to the 's invoice's coll'n
            invoice.InvoiceLineItems.Add(vendorInvoicesViewModel.NewInvoiceLineItems);

            //_vendorDbContext.SaveChanges();
            _vendorManager.UpdateVendor(vendor);

            // redirect back to the same item view passing the Id to the URL
            return RedirectToAction("GetLineItemByVendorAndInvoiceId", "Vendor", new { id = id, invoiceId = invoiceId });
        }

        private IVendorManager _vendorManager;

        private VendorDbContext _vendorDbContext;
    }
}
