using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VoucherDtoTest
    {
        [TestMethod]
        public void GetSetPatient()
        {
            PatientDto patient = new PatientDto()
            {
                Name = "Test1"
            };
            VoucherDto voucher = new VoucherDto()
            {
                Patient = patient
            };
            Assert.AreEqual(voucher.Patient, patient);
        }
        
        [TestMethod]
        public void GetSetVoucherId()
        {
            VoucherDto voucher = new VoucherDto()
            {
                VoucherDtoId = 1
            };
            Assert.AreEqual(voucher.VoucherDtoId, 1);
        }

        [TestMethod]
        public void GetSetMeetingAmount()
        {

            VoucherDto voucher = new VoucherDto()
            {
                MeetingsAmount = 3
            };
            Assert.AreEqual(voucher.MeetingsAmount, 3);
        }
        
        [TestMethod]
        public void GetSetTotalStatusApprove()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Status = Status.Approved
            };
            Assert.AreEqual(voucher.Status, Status.Approved);
        }
        
        [TestMethod]
        public void GetSetTotalStatusRejected()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Status = Status.Rejected
            };
            Assert.AreEqual(voucher.Status, Status.Rejected);
        }
        
        [TestMethod]
        public void GetSetTotalStatusPending()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Status = Status.Pending
            };
            Assert.AreEqual(voucher.Status, Status.Pending);
        }
        
        [TestMethod]
        public void GetSetDiscountLow()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Discount = Discounts.Low
            };
            Assert.AreEqual(voucher.Discount, Discounts.Low);
        }
        [TestMethod]
        public void GetSetDiscountMedium()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Discount = Discounts.Medium
            };
            Assert.AreEqual(voucher.Discount, Discounts.Medium);
        }
        
        [TestMethod]
        public void GetSetDiscountLarge()
        {

            VoucherDto voucher = new VoucherDto()
            {
                Discount = Discounts.Large
            };
            Assert.AreEqual(voucher.Discount, Discounts.Large);
        }
        
    }
}