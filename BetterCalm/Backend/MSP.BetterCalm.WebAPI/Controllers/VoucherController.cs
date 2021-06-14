using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    // [ServiceFilter(typeof(FilterAuthentication))]
    [Route("api/Voucher")]
    public class VoucherController : ControllerBase
    {
        private IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            this._voucherService = voucherService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Voucher> vouchers = this._voucherService.GetVouchers();
            return Ok(vouchers);
        }

        [HttpGet("{id}")]
        public IActionResult GetVoucherById([FromRoute] int id)
        {
            Voucher voucherById = _voucherService.GetVouchersById(id);
            return Ok(voucherById);
        }

        [HttpPut("{VoucherId}")]
        public OkObjectResult UpdateVoucher(
            [FromBody] Voucher voucher,
            [FromRoute] int VoucherId
        )
        {
            Voucher updatedVoucher = _voucherService.UpdateVoucher(voucher, VoucherId);
            return Ok(updatedVoucher);
        }
    }
}