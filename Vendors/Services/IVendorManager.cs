//IVendorManager.cs
// Assignment 3
// Revision History
//       Xiangdong Li, 2022.12.06: Created
//       Xiangdong Li, 2022.12.06: Debugging complete
//       Xiangdong Li, 2020.12.06: Comments added

using Vendors.Entities;

namespace Vendors.Services
{
    public interface IVendorManager
    {
        public ICollection<Vendor> GetVendorsByGroup();

        public Task<ICollection<Vendor>> GetVendorsByGroupAsync();

        // add a new vendor anf returns its int ID:
        public int AddNewVendor(Vendor vendor);

        public Vendor? GetVendorById(int id);


        public void UpdateVendor(Vendor vendor);

        public void DeleteVendorById(int id);

        public Invoice? GetInvoiceById(int invoiceId);

    }
}
