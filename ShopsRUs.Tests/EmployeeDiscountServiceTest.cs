using System.Collections.Generic;
using ShopsRUs.Models;
using ShopsRUs.Services.Discounts;
using Xunit;
using static System.DateTime;
using static ShopsRUs.Types.CustomerType;
using static ShopsRUs.Types.ProductType;

namespace ShopsRUs.Tests
{
    public class EmployeeDiscountServiceTest
    {
        private readonly EmployeeDiscountService _service = new EmployeeDiscountService();

        [Fact]
        public void IsAvaliable1()
        {
            // Arrange
            var bill = new Bill(
                new Customer(1L, Employee, Now), decimal.One, new List<BillProduct>
                {
                    new BillProduct("Milk", Groceries, decimal.One)
                }
            );

            // Act
            var isAvaliable = _service.IsAvaliable(bill);

            // Assert
            Assert.True(isAvaliable);
        }
        
        [Fact]
        public void IsAvaliable2()
        {
            // Arrange
            var bill = new Bill(
                new Customer(1L, Client, Now), decimal.One, new List<BillProduct>
                {
                    new BillProduct("Milk", Groceries, decimal.One)
                }
            );

            // Act
            var isAvaliable = _service.IsAvaliable(bill);

            // Assert
            Assert.False(isAvaliable);
        }
        
        [Fact]
        public void GetDiscount1()
        {
            // Arrange
            var laptopPrice = new decimal(100);
            var milkPrice = new decimal(10);
            var totalPrice = laptopPrice + milkPrice;
            
            var bill = new Bill(
                new Customer(1L, Employee, Now), totalPrice, new List<BillProduct>
                {
                    new BillProduct("Laptop", Other, laptopPrice),
                    new BillProduct("Milk", Groceries, milkPrice)
                }
            );

            // Act
            var discount = _service.GetDiscount(bill);

            // Assert
            Assert.Equal(laptopPrice * new decimal(0.3f), discount.DiscountTotal);
            Assert.Equal(totalPrice - discount.DiscountTotal, discount.PriceWithDiscountTotal);
        }
    }
}