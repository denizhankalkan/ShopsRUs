using ShopsRUs.Models;

namespace ShopsRUs.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDiscountBillService
    {
        /// <summary>
        /// Calculate discounts for products bill
        /// </summary>
        /// <param name="bill"> products bill </param>
        /// <returns> Calculated discount </returns>
        BillDiscount CalculateDiscounts(Bill bill);
    }
}