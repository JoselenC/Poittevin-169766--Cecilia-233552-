using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class VoucherMapper : IMapper<Voucher, VoucherDto>
    {
        private PatientMapper _patientMapper = new PatientMapper();

        public VoucherDto DomainToDto(Voucher obj, ContextDb context)
        {
            PatientDto patientDto =
                obj.Patient != null ? _patientMapper.DomainToDto(obj.Patient, context) : null;
            return new VoucherDto()
            {
                VoucherDtoId = obj.VoucherId,
                Patient = patientDto,
                Discount = obj.Discount,
                MeetingsAmount = obj.MeetingsAmount,
                Status = obj.Status,
            };
        }

        public Voucher DtoToDomain(VoucherDto obj, ContextDb context)
        {
            context.Entry(obj).Reference("Patient").Load();
            Patient patientDto = obj.Patient != null ? _patientMapper.DtoToDomain(obj.Patient, context) : null;
            return new Voucher()
            {
                VoucherId = obj.VoucherDtoId,
                Patient = patientDto,
                Discount = obj.Discount,
                MeetingsAmount = obj.MeetingsAmount,
                Status = obj.Status,
            };
        }

        public Voucher GetById(ContextDb context, int id)
        {
            throw new System.NotImplementedException();
        }

        public VoucherDto UpdateDtoObject(VoucherDto objToUpdate, Voucher updatedObject, ContextDb context)
        {
            objToUpdate.Discount = updatedObject.Discount;
            objToUpdate.MeetingsAmount = updatedObject.MeetingsAmount;
            objToUpdate.Status = updatedObject.Status;
            return objToUpdate;
        }
    }
}