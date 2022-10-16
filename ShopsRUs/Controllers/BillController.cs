using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Dto;
using ShopsRUs.Services;

namespace ShopsRUs.Controllers
{
    [ApiController]
    [Route("api/bill")]
    public class BillController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IDiscountBillService _discountBillService;

        public BillController(ICustomerService customerService, IDiscountBillService discountBillService)
        {
            _customerService = customerService;
            _discountBillService = discountBillService;
        }
        
        [HttpPost("/api/bill/calculate-discounts")]
        public async Task<ActionResult<BillDiscountDto>> CalculateDiscounts(BillDto billDto)
        {
            var customer = _customerService.GetCustomerById(billDto.CustomerId);
            
            var bill = billDto.ToModel(await customer);

            var discount = _discountBillService.CalculateDiscounts(bill);

            return Ok(discount.ToDto());
        }
        
    }
}