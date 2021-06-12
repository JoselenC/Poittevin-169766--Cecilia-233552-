using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class VoucherService : IVoucherService
    {
        private ManagerVoucherRepository repository;
        public VoucherService(ManagerVoucherRepository vRepository)
        {
            repository = vRepository;
        }

        public List<Voucher> GetVouchers()
        {
            return repository.Vouchers.Get();
        }

        public Voucher GetVouchersById(int voucherId)
        {
            try
            {
                return repository.Vouchers.Find(x => x.VoucherId == voucherId);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundVoucher();
            }
        }

        public Voucher SetVoucher(Voucher voucher)
        {
            return repository.Vouchers.Add(voucher);
        }

        public Voucher UpdateVoucher(Voucher newVoucher, int voucherId)
        {
            Voucher oldPsychologist = GetVouchersById(voucherId);
            return repository.Vouchers.Update(oldPsychologist, newVoucher);
        }

        public void DeleteVoucherById(int voucherVoucherId)
        {
            Voucher psychologist = GetVouchersById(voucherVoucherId);
            repository.Vouchers.Delete(psychologist);
        }
    }
}