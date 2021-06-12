using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class VoucherMapper: IMapper<Voucher, VoucherDto>
    {
        public VoucherDto DomainToDto(Voucher obj, ContextDb context)
        {
            throw new System.NotImplementedException();
        }

        public Voucher DtoToDomain(VoucherDto obj, ContextDb context)
        {
            throw new System.NotImplementedException();
        }

        public Voucher GetById(ContextDb context, int id)
        {
            throw new System.NotImplementedException();
        }

        public VoucherDto UpdateDtoObject(VoucherDto objToUpdate, Voucher updatedObject, ContextDb context)
        {
            throw new System.NotImplementedException();
        }
    }
}