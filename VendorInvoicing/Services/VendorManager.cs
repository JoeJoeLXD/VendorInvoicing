//VendorManager.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using Vendors.Entities;
using Vendors.Services;
using VendorInvoicing.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace VendorInvoicing.Services
{
    public class VendorManager : IVendorManager
    {
        public VendorManager(VendorDbContext vendorDbContext)
        {
            _vendorDbContext = vendorDbContext;
        }

        // The original synchronous version:
        public ICollection<Vendor> GetVendorsByGroup()
        {
            var vendors = GetBaseQuery()
                .Where(v => v.IsDeleted == false)
                .OrderBy(v => v.Name)
                .ToList();

            return vendors;
        }

        // This is asynchronous version of the above method
        public async Task<ICollection<Vendor>> GetVendorsByGroupAsync()
        {
            // Here we call the async version of ToList (which is what
            // executes the query) so we have to include an await;
            // i.e. go off and do this query but if this code blocks
            // awaiting results the server can go on process other requests
            var vendors = await GetBaseQuery()
               .Where(v => v.IsDeleted == false)
               .OrderBy(v => v.Name)
               .ToListAsync();

            return vendors;
        }

        // add a new vendor anf returns its int ID:
        public int AddNewVendor(Vendor vendor)
        {
            _vendorDbContext.Vendors.Add(vendor);
            _vendorDbContext.SaveChanges(); 
            return vendor.VendorId;
        }

        public Vendor? GetVendorById(int id)
        {
            return GetBaseQuery()
                .Where(v => v.VendorId == id)
                .FirstOrDefault();
        }

        public void UpdateVendor(Vendor vendor)
        {
            _vendorDbContext.Vendors.Update(vendor);
            _vendorDbContext.SaveChanges();
        }

        public void DeleteVendorById(int id)
        {
            var vendor = _vendorDbContext.Vendors.Find(id);
            _vendorDbContext.Vendors.Remove(vendor);
            _vendorDbContext.SaveChanges();
        }

        public Invoice? GetInvoiceById(int invoiceId)
        {
            return _vendorDbContext.Invoices
                           .Include(i => i.InvoiceLineItems)
                           .Where(i => i.InvoiceId == invoiceId)
                           .FirstOrDefault();
        }

        private IQueryable<Vendor> GetBaseQuery()
        {
            return _vendorDbContext.Vendors
                 .Include(v => v.Invoices)
                 .ThenInclude(i => i.PaymentTerms);
        }

        private VendorDbContext _vendorDbContext;
    }
}
