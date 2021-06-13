using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class VoucherServiceTest
    {
        private VoucherService service;
        private Mock<IRepository<Voucher>> voucherMock;
        private Mock<ManagerVoucherRepository> repoMock;

        private Patient patient;
        private Voucher voucher;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerVoucherRepository>();
            voucherMock = new Mock<IRepository<Voucher>>();
            repoMock.Object.Vouchers = voucherMock.Object;
            service = new VoucherService(repoMock.Object);
            
            patient = new Patient()
            {
                Name = "Patient1"
            };
            voucher = new Voucher()
            {
                VoucherId = 1,
                Patient = patient,
                Discount = Discounts.Medium,
                MeetingsAmount = 2,
                Status = Status.Pending
            };
        }

        [TestMethod]
        public void TestGetAll()
        {
            List<Voucher> vouchers = new List<Voucher>
            {
                voucher
            };
            voucherMock.Setup(
                x => x.Get()
            ).Returns(vouchers);
            List<Voucher> actualVouchers = service.GetVouchers();
            CollectionAssert.AreEqual(vouchers, actualVouchers);
            voucherMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestGetVoucherById()
        {
            voucherMock.Setup(
                x => x.Find(It.IsAny<Predicate<Voucher>>())
            ).Returns(voucher);
            service.GetVouchersById(voucher.VoucherId);
            voucherMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVoucher))]
        public void TestGetVoucherByIdNotFound()
        {

            voucherMock.Setup(
                x => x.Find(It.IsAny<Predicate<Voucher>>())
            ).Throws(new KeyNotFoundException());
            service.GetVouchersById(1);
        }
        
        [TestMethod]
        public void TestAddVoucher()
        {
            voucherMock.Setup(
                x => x.Add(voucher)
            ).Returns(voucher);
            Voucher createdVoucher = service.SetVoucher(voucher);
            Assert.AreEqual(voucher, createdVoucher);
            voucherMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestUpdateVoucher()
        {
            Voucher newVoucher = new Voucher()
            {
                VoucherId = 1,
                MeetingsAmount = 3
            };
            voucherMock.Setup(
                x => x.Find(It.IsAny<Predicate<Voucher>>())
            ).Returns(voucher);
            voucherMock.Setup(
                x => x.Update(voucher, newVoucher)
            ).Returns(newVoucher);
            Voucher realUpdated = service.UpdateVoucher(newVoucher, voucher.VoucherId);
            Assert.AreEqual(newVoucher, realUpdated);
            voucherMock.VerifyAll();
        }

        [TestMethod]
        public void TestDeleteVoucher()
        {

            voucherMock.Setup(
                x => x.Delete(voucher)
            );
            voucherMock.Setup(
                x => x.Find(It.IsAny<Predicate<Voucher>>())
            ).Returns(voucher);
            service.DeleteVoucherById(voucher.VoucherId);
            voucherMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVoucher))]
        public void TestDeleteVoucherNotFound()
        {

            voucherMock.Setup(
                x => x.Find(It.IsAny<Predicate<Voucher>>())
            ).Throws(new KeyNotFoundException());
            service.DeleteVoucherById(1);
        }
    }
}