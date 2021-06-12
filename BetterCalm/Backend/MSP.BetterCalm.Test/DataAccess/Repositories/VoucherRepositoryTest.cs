using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    public class VoucherRepositoryTest
    {
        [TestMethod]
        public void VoucherRepositoryTestCreationVouchersTypeTest()
        {
            VoucherRepository psychologistRepository = new VoucherRepository( new VoucherMapper(),new ContextDb());
            Assert.IsInstanceOfType(psychologistRepository.Vouchers, typeof(DataBaseRepository<Voucher, VoucherDto>));
        }
    }
}