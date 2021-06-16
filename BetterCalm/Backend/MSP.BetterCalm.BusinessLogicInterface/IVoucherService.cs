using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public interface IVoucherService
    {
        List<Voucher> GetVouchers();
        Voucher GetVouchersById(int voucherId);
        Voucher SetVoucher(Voucher voucher);
        Voucher UpdateVoucher(Voucher newVoucher, int voucherId);
        void DeleteVoucherById(int voucherVoucherId);
    }
}