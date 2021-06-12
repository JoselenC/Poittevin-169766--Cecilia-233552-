using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VoucherMapperTest
    {
        private DbContextOptions<ContextDb> options;
        private ContextDb context;
        public DataBaseRepository<Voucher, VoucherDto> Vouchers;
        public Voucher voucherTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDb>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDb(this.options); 
            Vouchers = new DataBaseRepository<Voucher, VoucherDto>(new VoucherMapper(), context.Vouchers, context);
            voucherTest = new Voucher() {VoucherId=1};
            Vouchers.Add(voucherTest);
            
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Voucher voucherTest = new Voucher() {VoucherId=2};
            Vouchers.Add(voucherTest);
            Voucher realVoucher = Vouchers.Find(x => x.VoucherId == 2);
            Assert.AreEqual(voucherTest, realVoucher);
            
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Voucher realVoucher = Vouchers.Find(x => x.VoucherId == 1);
            Assert.AreEqual(voucherTest, realVoucher);
        }
        
        [TestMethod]
        public void GetById()
        {
            Voucher realVoucher = Vouchers.FindById(1);
            Assert.AreEqual(voucherTest, realVoucher);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void GetByIdNull()
        {
            Vouchers.FindById(3);
        }
    }
}