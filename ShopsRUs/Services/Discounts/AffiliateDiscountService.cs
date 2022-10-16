using System.Linq;
using ShopsRUs.Models;
using static ShopsRUs.Types.CustomerType;
using static ShopsRUs.Types.ProductType;

namespace ShopsRUs.Services.Discounts
{
    public class AffiliateDiscountService : IPercentsDiscountService
    {
        private static readonly decimal DiscountPercent = new(.1f);
        
        public bool IsAvaliable(Bill bill)
        {
            return Affiliate == bill.Customer.CustomerType;
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