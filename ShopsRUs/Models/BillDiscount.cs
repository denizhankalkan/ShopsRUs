using ShopsRUs.Dto;

namespace ShopsRUs.Models
{
    public class BillDiscount
    {
        public Customer Customer { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal PriceWithDiscountTotal { get; set; }

        public BillDiscount() { }

        public BillDiscount(Customer customer, decimal priceTotal, decimal discountTotal, decimal priceWithDiscountTotal)
        {
            Customer = customer;
            PriceTotal = priceTotal;
            DiscountTotal = discountTotal;
            PriceWithDiscountTotal = priceWithDiscountTotal;
        }

        public static BillDiscount operator +(BillDiscount a, BillDiscount b)
        {
            return new BillDiscount(
                a.Customer,
                a.PriceTotal,
                a.DiscountTotal + b.DiscountTotal,
                a.PriceWithDiscountTotal - b.DiscountTotal
            );
        }

        public BillDiscountDto ToDto()
        {
            return new BillDiscountDto(Customer.ToDto(), PriceTotal, DiscountTotal, PriceWithDiscountTotal);
        }
    }
}