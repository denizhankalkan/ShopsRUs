using System;
using System.Linq;
using ShopsRUs.Models;
using static ShopsRUs.Types.ProductType;

namespace ShopsRUs.Services.Discounts
{
    public class OverTwoYearsDiscountService : IPercentsDiscountService
    {
        private const int Years = 2;
        private static readonly decimal DiscountPercent = new(.05f);
        
        public bool IsAvaliable(Bill bill) {
            return bill.Customer.RegisteredAt.AddYears(Years) < DateTime.Now;
        }

        public BillDiscount GetDiscount(Bill bill)
        {
            var discount = bill.Products
                .Where(product => product.ProductType != Groceries)
                .Sum(product => product.Price) * DiscountPercent;
            
            return new BillDiscount(bill.Customer, bill.PriceTotal, discount, bill.PriceTotal - discount);
        }
    }
}