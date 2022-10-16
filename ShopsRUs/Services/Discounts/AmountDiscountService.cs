using ShopsRUs.Models;

namespace ShopsRUs.Services.Discounts
{
    public class AmountDiscountService : IAmountDiscountService
    {
        private static readonly decimal MinPriceDiscount = new(100);
        private static readonly decimal DiscountAmount = new(5);

        public bool IsAvaliable(Bill bill)
        {
            return bill.PriceTotal >= MinPriceDiscount;
        }

        public BillDiscount GetDiscount(Bill bill)
        {
            var discount = decimal.Floor(bill.PriceTotal / MinPriceDiscount) * DiscountAmount;
            return new BillDiscount(bill.Customer, bill.PriceTotal, discount, bill.PriceTotal - discount);
        }
    }
}