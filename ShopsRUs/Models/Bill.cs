using System.Collections.Generic;

namespace ShopsRUs.Models
{
    
    /// <summary>
    ///  Bill
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer { get; set; }
        
        /// <summary>
        /// Products list
        /// </summary>
        public List<BillProduct> Products { get; set; }
        
        /// <summary>
        /// Total price
        /// </summary>
        public decimal PriceTotal { get; set; }

        public Bill() { }

        public Bill(Customer customer, decimal priceTotal, List<BillProduct> products)
        {
            Customer = customer;
            PriceTotal = priceTotal;
            Products = products;
        }
        
        public void ApplyDiscount(BillDiscount discount)
        {
            PriceTotal -= discount.DiscountTotal;
        }
    }
}