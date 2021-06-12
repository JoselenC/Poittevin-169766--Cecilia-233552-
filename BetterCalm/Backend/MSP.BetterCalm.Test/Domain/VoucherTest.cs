using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VoucherTest
    {
        [TestMethod]
        public void GetSetPatient()
        {
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Voucher voucher = new Voucher()
            {
                Patient = patient
            };
            Assert.AreEqual(voucher.Patient, patient);
        }
        
        [TestMethod]
        public void GetSetPsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            Voucher voucher = new Voucher()
            {
                Psychologist = psychologist
            };
            Assert.AreEqual(voucher.Psychologist, psychologist);
        }
        
        [TestMethod]
        public void GetSetMeetingAmount()
        {

            Voucher voucher = new Voucher()
            {
                MeetingsAmount = 3
            };
            Assert.AreEqual(voucher.MeetingsAmount, 3);
        }
        
        [TestMethod]
        public void GetSetTotalStatusApprove()
        {

            Voucher voucher = new Voucher()
            {
                Status = Status.Approved
            };
            Assert.AreEqual(voucher.Status, Status.Approved);
        }
        
        [TestMethod]
        public void GetSetTotalStatusRejected()
        {

            Voucher voucher = new Voucher()
            {
                Status = Status.Rejected
            };
            Assert.AreEqual(voucher.Status, Status.Rejected);
        }
        
        [TestMethod]
        public void GetSetTotalStatusPending()
        {

            Voucher voucher = new Voucher()
            {
                Status = Status.Pending
            };
            Assert.AreEqual(voucher.Status, Status.Pending);
        }
        
        [TestMethod]
        public void GetSetDiscountLow()
        {

            Voucher voucher = new Voucher()
            {
                Discount = Discounts.Low
            };
            Assert.AreEqual(voucher.Discount, Discounts.Low);
        }
        [TestMethod]
        public void GetSetDiscountMedium()
        {

            Voucher voucher = new Voucher()
            {
                Discount = Discounts.Medium
            };
            Assert.AreEqual(voucher.Discount, Discounts.Medium);
        }
        
        [TestMethod]
        public void GetSetDiscountLarge()
        {

            Voucher voucher = new Voucher()
            {
                Discount = Discounts.Large
            };
            Assert.AreEqual(voucher.Discount, Discounts.Large);
        }
        
    }
}