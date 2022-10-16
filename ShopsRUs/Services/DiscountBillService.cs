using System.Collections.Generic;
using System.Linq;
using ShopsRUs.Models;
using ShopsRUs.Services.Discounts;

namespace ShopsRUs.Services
{
    public class DiscountBillService : IDiscountBillService
    {
        private readonly IEnumerable<IPercentsDiscountService> _percentsDiscountServices;
        private readonly IEnumerable<IAmountDiscountService> _amountDiscountServices;

        public DiscountBillService(IEnumerable<IPercentsDiscountService> percentsDiscountServices,
            IEnumerable<IAmountDiscountService> amountDiscountServices)
        {
            _percentsDiscountServices = percentsDiscountServices;
            _amountDiscountServices = amountDiscountServices;
        }

        /// <summary>
        /// Calculate discounts for products bill
        /// </summary>
        /// <param name="bill"> products bill </param>
        /// <returns> Calculated discount </returns>
        public BillDiscount CalculateDiscounts(Bill bill)
        {
            var discountPercents = GetDiscount(_percentsDiscountServices, bill);
            bill.ApplyDiscount(discountPercents);

            var discountAmount = GetDiscount(_amountDiscountServices, bill);
            bill.ApplyDiscount(discountAmount);

            return discountPercents + discountAmount;
        }

        private static BillDiscount GetDiscount(IEnumerable<IDiscountService> discountServices, Bill bill)
        {
            return discountServices
                       .Where(service => service.IsAvaliable(bill))
                       .Select(service => service.GetDiscount(bill))
                       .MaxBy(discount => discount.DiscountTotal)
                   ?? new BillDiscount(bill.Customer, bill.PriceTotal, decimal.Zero, bill.PriceTotal);
        }
    }
}