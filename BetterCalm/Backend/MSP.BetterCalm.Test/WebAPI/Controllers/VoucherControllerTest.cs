using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI.Controllers
{
    [TestClass]
    public class VoucherControllerTest
    {
        private Mock<IVoucherService> mockVoucherService;
        private VoucherController voucherController ;
        private List<Voucher> vouchers;
        private Voucher voucher;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockVoucherService=new Mock<IVoucherService>(MockBehavior.Strict);
            voucherController = new VoucherController(mockVoucherService.Object);
            vouchers = new List<Voucher>();
            voucher = new Voucher();
        }
        
        [TestMethod]
        public void TestGetAllCategories()
        {
            mockVoucherService.Setup(m => m.GetVouchers()).Returns(this.vouchers);
            var result = voucherController.GetAll();
            var okResult = result as OkObjectResult;
            var vouchersValue = okResult.Value;
            Assert.AreEqual(this.vouchers,vouchersValue);
        }

        [TestMethod]
        public void TestGetVoucherById()
        {
            mockVoucherService.Setup(m => m.GetVouchersById(1)).Returns(this.voucher);
            var result = voucherController.GetVoucherById(1);
            var okResult = result as OkObjectResult;
            var voucherValue = okResult.Value;
            Assert.AreEqual(this.voucher,voucherValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId))]
        public void TestNoGetVoucherById()
        {
            mockVoucherService.Setup(m => m.GetVouchersById(1)).Throws(new NotFoundId());
            voucherController.GetVoucherById(1);
        }
        
        [TestMethod]
        public void TestUpdateVoucherById()
        {
            mockVoucherService.Setup(
                x => x.UpdateVoucher(voucher, voucher.VoucherId)
            ).Returns(voucher);
            var result = voucherController.UpdateVoucher(voucher, voucher.VoucherId);
            var createdResult = result as OkObjectResult;
            var realPsycho = createdResult.Value;
            Assert.AreEqual(realPsycho, voucher);
        }
    }
}