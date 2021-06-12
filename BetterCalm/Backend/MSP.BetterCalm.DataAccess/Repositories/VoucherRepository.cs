using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class VoucherRepository: ManagerVoucherRepository
    {
        public VoucherRepository(IMapper<Voucher, VoucherDto> mapper, ContextDb context)
        {
            Vouchers =
                new DataBaseRepository<Voucher, VoucherDto>(mapper, context.Vouchers, context);
        }  
    }
}