using System.Numerics;
using Vendors.Entities;

namespace Vendors.Tests
{
    public class UnitTestVendorInvoicing
    {
        [Fact]
        public void TestTotalAmounts()
        {
            //Arrange:
            Invoice i1 = new Invoice() {
                InvoiceDate = new DateTime(2022, 8, 5),
                InvoiceLineItems = new List<InvoiceLineItem>()
            };

            i1.InvoiceLineItems.Add(new InvoiceLineItem() { Amount = 100.00, Description = "AAA" });
            i1.InvoiceLineItems.Add(new InvoiceLineItem() { Amount = 200.00, Description = "BBB" });

            // Act:
            double paymentTotal = i1.InvoiceLineItems.Sum(ili => ili.Amount).GetValueOrDefault();

            // Assert:
            Assert.Equal(300.00, paymentTotal);
        }

        [Fact]
        public void TestDueDate()
        {
            //Arrage data
            Invoice i1 = new Invoice()
            {
                InvoiceId = 1,
                InvoiceDate = new DateTime(2022, 10, 10),
                PaymentTerms = new PaymentTerms()
            };

            i1.PaymentTerms.Description = "Net due 10 days";
            i1.PaymentTerms.DueDays = 10;

            //Act
            DateTime duedate = ((DateTime)i1.InvoiceDate).AddDays(Convert.ToDouble(i1.PaymentTerms.DueDays));
            //Assert
            Assert.Equal(new DateTime(2022, 10, 20), duedate);
        }

        [Fact]
        public void TestVendorGroup()
        {
            //arrage
            Vendor v = new Vendor()
            {
                Name = "DOG"
            };

            string beginOfgroupAE = "A";
            string endOfgroupAE = "E";

            //act
            bool ingroupAE = v.Name.ToLower().Substring(0, 1).CompareTo(beginOfgroupAE) >= 0
                && v.Name.ToLower().Substring(0, 1).CompareTo(endOfgroupAE) <= 0;
            //assert

            Assert.Equal(true, ingroupAE);
        }
    }
}