namespace ShopsRUs.Dto
{
    public class BillDiscountDto
    {
        public CustomerDto Customer { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal PriceWithDiscountTotal { get; set; }

        public BillDiscountDto() { }

        public BillDiscountDto(CustomerDto customer, decimal priceTotal, decimal discountTotal, decimal priceWithDiscountTotal)
        {
            Customer = customer;
            PriceTotal = priceTotal;
            DiscountTotal = discountTotal;
            PriceWithDiscountTotal = priceWithDiscountTotal;
        }
    }
}