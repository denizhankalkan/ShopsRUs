using ShopsRUs.Models;

namespace ShopsRUs.Services.Discounts
{
    public interface IDiscountService
    {
        bool IsAvaliable(Bill bill);

        BillDiscount GetDiscount(Bill bill);
    }

    public interface IPercentsDiscountService : IDiscountService { }

    public interface IAmountDiscountService : IDiscountService { }
}